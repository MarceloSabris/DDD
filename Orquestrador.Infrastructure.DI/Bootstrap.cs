using CorreiosWS;
using Enterprise.Framework.Collections;
using Enterprise.Framework.DI;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Log;
using Enterprise.Framework.MongoDB;
using Enterprise.Framework.WebApi.Security.Legacy.Services.Client.Authorization;
using ItemVirtualWS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Diagnostics.EventFlow;
using Microsoft.Diagnostics.EventFlow.Inputs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orquestrador.Application.EmailAtivacao.Services;
using Orquestrador.Application.Impl.EmailAtivacao.Services;
using Orquestrador.Application.Impl.IntegracaoERP.Services;
using Orquestrador.Application.Impl.Parceiro.Services;
using Orquestrador.Application.Impl.PedidoLoja.Services;
using Orquestrador.Application.IntegracaoERP.Services;
using Orquestrador.Application.Parceiro.Services;
using Orquestrador.Application.PedidoLoja.Services;
using Orquestrador.Domain.Erp.Repositories;
using Orquestrador.Domain.Loja.Events;
using Orquestrador.Domain.Loja.Repositories;
using Orquestrador.Domain.Loja.Services.Contracts;
using Orquestrador.Domain.Loja.Services.Implementations;
using Orquestrador.Domain.Parceiro.Repositories;
using Orquestrador.Domain.Shared.CodeMessages.Repositories;
using Orquestrador.Domain.Utilitario.Repositories;
using Orquestrador.Infrastructure.Http.Erp;
using Orquestrador.Infrastructure.Http.Loja;
using Orquestrador.Infrastructure.Http.Parceiro;
using Orquestrador.Infrastructure.Http.Shared;
using Orquestrador.Infrastructure.Http.Utilitario;
using Orquestrador.Infrastructure.MongoDb.Common;
using Orquestrador.Infrastructure.MongoDb.Shared.CodeMessages.Repositories;
using System;
using System.ServiceModel;
using TDCAWS;

namespace Orquestrador.Infrastructure.DI
{
    public class Bootstrap
    {
        private static ParsableNameValueCollection _appSettings;
        private static Factory _factory = Factory.Instance;
        private static bool _logEnabled;
        private static ILoggerFactory _loggerFactory;

        public Bootstrap(ParsableNameValueCollection appSettings)
        {
            if ((_appSettings = appSettings) == null)
                throw new ArgumentNullException("appSettings");

            _logEnabled = appSettings.TryGetAndParse<bool>("audit-log-enabled").ParsedValue;
        }

        public void Initialize(IServiceCollection services)
        {
            _factory.Register(_appSettings);
            //RegisterLog();
            RegisterWebApiSecurity(services);
            RegisterInfrastructure();
            RegisterRepositories();
            //RegisterValidators();
            RegisterServices();
            RegisterEvents();
        }

        public void Initialize()
        {
            _factory.Register(_appSettings);
           // RegisterLog();            
            RegisterInfrastructure();
            RegisterRepositories();
            //RegisterValidators();
            RegisterServices();
            RegisterEvents();
        }

        private void RegisterLog()
        {
            var pipe = DiagnosticPipelineFactory.CreatePipeline("eventFlow.json");
            _loggerFactory = new LoggerFactory().AddEventFlow(pipe);
        }

        private void RegisterWebApiSecurity(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IAuthorizationServiceClient, AuthorizationService>();
            services.AddSingleton<ParsableNameValueCollection>(_appSettings);

            services.AddHttpClient("ApiSeguranca", client =>
            {
                client.BaseAddress = new Uri(_appSettings.EnsureValue<string>("host-plataforma-seguranca"));
            });
        }

        private void RegisterInfrastructure()
        {
            _factory.Register(SimpleMongoClient.CreateFromConfig("mongoclient-", _appSettings));
            _factory.Register<IDataBaseFacade>(new DataBaseFacade(_factory.Create<SimpleMongoClient>()));
        }

        private void RegisterRepositories()
        {
            //_factory.Register<ICodeMessageRepository>(
            //    new CodeMessageRepository(_factory.Create<IDataBaseFacade>(),
            //                              CollectionsNames.CodeMessagesCollectionName));

//            CreateIPedidoHttpRepository();

            CreateILojaHttpRepository();

            CreateIUtilitarioHttpRepository();

            CreateIParceiroHttpRepository();

            CreateIErpHttpRepository();
        }

        //private void RegisterValidators()
        //{
        //    _factory.Register<IPostagemServiceValidator>(
        //        new PostagemServiceValidator(_factory.Create<ICodeMessageRepository>()));
        //}

        private void RegisterServices()
        {
            _factory.Register<IPedidoDomainService>(
                new PedidoDomainService(_factory.Create<IUtilitarioHttpRepository>(),
                                        _factory.Create<ILojaHttpRepository>(),
                                        _factory.Create<IParceiroHttpRepository>(),
                                        _factory.Create<IErpHttpRepository>())
            );

            CreateIEmailAtivacaoService();

            CreateIPedidoLojaService();

            CreateIPedidoParceiroService();

            CreateIPedidoERPService();
        }

        private void RegisterEvents()
        {
            DomainEventManager.For<EnviarCodigoClienteEvent>()
                              .Use<IPedidoDomainService>(
                () => _factory.Create<IPedidoDomainService>()
            );

            DomainEventManager.For<EnfileirarEvent>()
                             .Use<IPedidoDomainService>(
               () => _factory.Create<IPedidoDomainService>()
           );

            DomainEventManager.For<IntegrarParceiroEvent>()
                           .Use<IPedidoDomainService>(
             () => _factory.Create<IPedidoDomainService>()
         );

            DomainEventManager.For<IntegrarERPEvent>()
                         .Use<IPedidoDomainService>(
           () => _factory.Create<IPedidoDomainService>()
       );

        }

       

        private static void CreateIErpHttpRepository()
        {

            string endpointErp = _appSettings.TryGetAndParse<string>("DadosErp:EndpointErp").ParsedValue;
            string rotaItemVirtual = _appSettings.TryGetAndParse<string>("DadosErp:RotaItemVirtual").ParsedValue;
           
            var dadosErp = new DadosErp()
            {
               EndpointErp = endpointErp,
               RotaItemVirtual = rotaItemVirtual
            };

            Domain.Erp.Repositories.IErpHttpRepository erpHttpRepository =
                new ErpHttpSoapInvoker(dadosErp);
          

            _factory.Register<Domain.Erp.Repositories.IErpHttpRepository>(
               erpHttpRepository
            );
        }

        private static void CreateILojaHttpRepository()
        {    
            string apiLojaAddressHost = _appSettings.TryGetAndParse<string>("DadosLoja:HttpAddress").ParsedValue;
            string rotaListarComAtivacao = _appSettings.TryGetAndParse<string>("DadosLoja:RotaListarComAtivacao").ParsedValue;
            string rotaObterElegiveis = _appSettings.TryGetAndParse<string>("DadosLoja:RotaObterElegiveis").ParsedValue;
            string rotaInserirCompraParceiro = _appSettings.TryGetAndParse<string>("DadosLoja:RotaInserirCompraParceiro").ParsedValue;
            string rotaAlterarStatusParceiro = _appSettings.TryGetAndParse<string>("DadosLoja:RotaAlterarStatusParceiro").ParsedValue;
            string rotaAlterarStatusAtivacao = _appSettings.TryGetAndParse<string>("DadosLoja:RotaAlterarStatusAtivacao").ParsedValue;
            string rotaListarComAceite = _appSettings.TryGetAndParse<string>("DadosLoja:RotaListarComAceite").ParsedValue;
            string rotaListarCompraParceiro = _appSettings.TryGetAndParse<string>("DadosLoja:RotaListarCompraParceiro").ParsedValue;
            string rotaListarComprasERP = _appSettings.TryGetAndParse<string>("DadosLoja:RotaListarComprasERP").ParsedValue;
            string rotaAlterarStatusERP = _appSettings.TryGetAndParse<string>("DadosLoja:RotaAlterarStatusERP").ParsedValue;

            var dadosLoja = new DadosLoja()
            {
               ApiLojaAddressHost = apiLojaAddressHost,
               RotaListarComAtivacao = rotaListarComAtivacao,
               RotaObterElegiveis = rotaObterElegiveis,
               RotaInserirCompraParceiro = rotaInserirCompraParceiro,
               RotaAlterarStatusAtivacao=rotaAlterarStatusAtivacao,
               RotaAlterarStatusParceiro=rotaAlterarStatusParceiro,
               RotaListarComAceite = rotaListarComAceite,
               RotaListarCompraParceiro= rotaListarCompraParceiro,
               RotaAlterarStatusERP=rotaAlterarStatusERP,
               RotaListarComprasERP= rotaListarComprasERP
            };

            var lojaHttpRepository = new LojaHttpRestInvoker(dadosLoja);

            _factory.Register<ILojaHttpRepository>(lojaHttpRepository);
        }

        private static void CreateIParceiroHttpRepository()
        {
            string apiBhnAddressHost = _appSettings.TryGetAndParse<string>("DadosBhn:HttpAddress").ParsedValue;
            string rotaGerarEGift = _appSettings.TryGetAndParse<string>("DadosBhn:RotaGerarEGift").ParsedValue;

            var dadosBhn = new DadosBhn()
            {
                HttpAddress = apiBhnAddressHost,
                RotaGerarEGift = rotaGerarEGift
            };

            var parceiroHttpRepository = new BlackhawkHttpRestInvoker(dadosBhn);

            _factory.Register<IParceiroHttpRepository>(parceiroHttpRepository);
        }

        private static void CreateIUtilitarioHttpRepository()
        {
            string apiUtilitarioAddressHost = _appSettings.TryGetAndParse<string>("DadosUtilitario:HttpAddress").ParsedValue;
            string authorization = _appSettings.TryGetAndParse<string>("DadosUtilitario:Authorization").ParsedValue;
            string rotaEnviarEmailOffline = _appSettings.TryGetAndParse<string>("DadosUtilitario:RotaEnviarEmailOffline").ParsedValue;
            string rotaObterDadosConfiguracao = _appSettings.TryGetAndParse<string>("DadosUtilitario:RotaObterDadosConfiguracao").ParsedValue;

            var dadosUtilitario = new DadosUtilitario()
            {
               HttpAddress = apiUtilitarioAddressHost,
               Authorization = authorization,
               RotaEnviarEmailOffline = rotaEnviarEmailOffline,
               RotaObterDadosConfiguracao = rotaObterDadosConfiguracao
            };

            var utilitarioHttpRepository = new UtilitarioHttpRestInvoker(dadosUtilitario);

            _factory.Register<IUtilitarioHttpRepository>(utilitarioHttpRepository);
        }

      

        private static void CreateIEmailAtivacaoService()
        {
            IEmailAtivacaoService emailAtivacaoService =
              new EmailAtivacaoService(_factory.Create<ILojaHttpRepository>());

            _factory.Register<IEmailAtivacaoService>(
               emailAtivacaoService
              );
                      
        }

        private static void CreateIPedidoLojaService()
        {
            IPedidoLojaService pedidoLojaService =
              new PedidoLojaService(_factory.Create<ILojaHttpRepository>());

            _factory.Register<IPedidoLojaService>(
               pedidoLojaService
              );

        }

        private static void CreateIPedidoParceiroService()
        {
            IPedidoParceiroService pedidoParceiroService =
              new PedidoParceiroService(_factory.Create<ILojaHttpRepository>());

            _factory.Register<IPedidoParceiroService>(
               pedidoParceiroService
              );

        }

        private static void CreateIPedidoERPService()
        {
            IPedidoERPService pedidoERPService =
              new PedidoERPService(_factory.Create<ILojaHttpRepository>());

            _factory.Register<IPedidoERPService>(
               pedidoERPService
              );

        }
    }
}