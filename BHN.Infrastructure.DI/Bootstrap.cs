using BHN.Application.Catalog.Services;
using BHN.Application.EGift.Services;
using BHN.Application.Impl.Catalog.Services;
using BHN.Application.Impl.EGift.Services;
using BHN.Application.Impl.Produto.Services;
using BHN.Application.Produto.Services;
using BHN.Domain.EGifts.Events;
using BHN.Domain.EGifts.Repositories;
using BHN.Domain.EGifts.Services;
using BHN.Domain.EGifts.Services.Contracts;
using BHN.Domain.EGifts.Services.Implementations;
using BHN.Infrastructure.Http.Catalog.Services;
using BHN.Infrastructure.Http.EGift.Services;
using BHN.Infrastructure.Http.Produto.Services;
using BHN.Infrastructure.Http.Shared;
using BHN.Infrastructure.MongoDb.Common;
using BHN.Infrastructure.SqlClient;
using CorreiosWS;
using Enterprise.Framework.Collections;
using Enterprise.Framework.DI;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.MongoDB;
using Enterprise.Framework.SqlClient;
using Enterprise.Framework.WebApi.Security.Legacy.Services.Client.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.ServiceModel;

namespace BHN.Infrastructure.DI
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
            RegisterLog();
            RegisterWebApiSecurity(services);
            RegisterInfrastructure();
            RegisterRepositories();
            RegisterValidators();
            RegisterServices();
            RegisterEvents();
        }

        private void RegisterLog()
        {
            //var pipe = DiagnosticPipelineFactory.CreatePipeline("eventFlow.json");
            //_loggerFactory = new LoggerFactory().AddEventFlow(pipe);
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

            //_factory.Register<IFilialRepository>(
            //   new FilialMongoRepository(_factory.Create<IDataBaseFacade>(),
            //                             CollectionsNames.FilialCollectionName));

            //_factory.Register<IPedidoRepository>(
            //  new PedidoMongoRepository(_factory.Create<IDataBaseFacade>(),
            //                            CollectionsNames.PedidoCollectionName));

            //_factory.Register<IPedidoLogger>(
            //    new PedidoLogger(new Log<PedidoLogger>(_loggerFactory)));

            //CreateIPedidoHttpRepository();

            //_factory.Register<IPostagemRepository>(
            //    new PostagemMongoRepository(_factory.Create<IDataBaseFacade>(),
            //                                CollectionsNames.PostagemCollectionName));

            _factory.Register<IAcaoEGiftRepository>(
                new AcaoEGiftRepository(new ConectionFactory(_appSettings)));
        }

        private void RegisterValidators()
        {
            //_factory.Register<IPostagemServiceValidator>(
            //    new PostagemServiceValidator(_factory.Create<ICodeMessageRepository>()));
        }

        private void RegisterServices()
        {                  
            CreateICompraService();

            CreateIEGiftService();

            CreateICatalogService();

            CreateIProdutoService();

            _factory.Register<IEGiftHttpService>(
                new EGiftHttpService(ObterDadosBHN())
            );

            _factory.Register<IGerarEGiftDomainService>(
                new GerarEGiftDomainService(_factory.Create<IEGiftHttpService>(), _factory.Create<IAcaoEGiftRepository>())
            );
        }

        private void RegisterEvents()
        {
            DomainEventManager.For<GerarEGiftEvent>()
                                .Use<IGerarEGiftDomainService>(
                    () => _factory.Create<IGerarEGiftDomainService>()
                );
        }

        private static void CreateIPedidoHttpRepository()
        {
            var binding = new BasicHttpBinding();
            string uri = _appSettings.TryGetAndParse<string>("endpointTDCA").ParsedValue;
            var endpointAddress = new EndpointAddress(uri);

            string operador = _appSettings.TryGetAndParse<string>("AutenticacaoTDCA:Operador").ParsedValue;
            string token = _appSettings.TryGetAndParse<string>("AutenticacaoTDCA:Token").ParsedValue;
            var dadosAutenticacao = new AutenticacaoTDCA
            {
                Operador = operador,
                Token = token
            };

           
        }

        private static void CreateICorreiosHttpService()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

            string uri = _appSettings.TryGetAndParse<string>("endpointCorreios").ParsedValue;
            var endpointAddress = new EndpointAddress(uri);

            var clientWS = new logisticaReversaWSClient(binding, endpointAddress);

            clientWS.ClientCredentials.UserName.UserName =
                _appSettings.TryGetAndParse<string>("AutenticacaoCorreios:IdCorreios").ParsedValue;

            clientWS.ClientCredentials.UserName.Password =
                _appSettings.TryGetAndParse<string>("AutenticacaoCorreios:SenhaCorreios").ParsedValue;

            string cartao = _appSettings.TryGetAndParse<string>("AutenticacaoCorreios:Cartao").ParsedValue;
            string codigoAdministrativo = _appSettings.TryGetAndParse<string>("AutenticacaoCorreios:CodigoAdministrativo").ParsedValue;
            string codigoServico = _appSettings.TryGetAndParse<string>("AutenticacaoCorreios:CodigoServico").ParsedValue;
            string contrato = _appSettings.TryGetAndParse<string>("AutenticacaoCorreios:Contrato").ParsedValue;

            var dadosAutenticacao = new AutenticacaoCorreios
            {
                Cartao = cartao,
                CodigoAdministrativo = codigoAdministrativo,
                CodigoServico = codigoServico,
                Contrato = contrato
            };

      
        }

        private static void CreateIBarramentoHttpService()
        {
           
        }

        private static void CreateIPostagemService()
        {
         
        }

        private static void CreateICompraService()
        {
         
        }

        private static DadosBhn ObterDadosBHN()
        {
            string certificadoPath = _appSettings.TryGetAndParse<string>("DadosBhn:CertificadoCaminho").ParsedValue;
            string certificadoSenha = _appSettings.TryGetAndParse<string>("DadosBhn:CertificadoSenha").ParsedValue;
            string urlApi = _appSettings.TryGetAndParse<string>("DadosBhn:HttpAddress").ParsedValue;
            string gerarHashRota = _appSettings.TryGetAndParse<string>("DadosBhn:GerarHashRota").ParsedValue;
            string desfazimentoRota = _appSettings.TryGetAndParse<string>("DadosBhn:DesfazimentoHashRota").ParsedValue;
            string versaoCatalogoRota = _appSettings.TryGetAndParse<string>("DadosBhn:VersaoCatalogoRota").ParsedValue;
            string templateActivationSpot = _appSettings.TryGetAndParse<string>("DadosBhn:TemplateActivationSpot").ParsedValue;
            string identificacaoVendedor = _appSettings.TryGetAndParse<string>("DadosBhn:IdentificacaoVendedor").ParsedValue;
            string detalhesCatalogoRota = _appSettings.TryGetAndParse<string>("DadosBhn:DetalhesCatalogoRota").ParsedValue;
            string detalhesProdutoRota = _appSettings.TryGetAndParse<string>("DadosBhn:DetalhesProdutoRota").ParsedValue;
            string gerarKeyRota = _appSettings.TryGetAndParse<string>("DadosBhn:GerarKeyRota").ParsedValue;

            return new DadosBhn()
            {
                CertificadoCaminho = certificadoPath,
                CertificadoSenha = certificadoSenha,
                UrlApi = urlApi,
                GerarHashRota = gerarHashRota,
                DesfazimentoRota = desfazimentoRota,
                VersaoCatalogoRota = versaoCatalogoRota,
                TemplateActivationSpot = templateActivationSpot,
                VendedorId = identificacaoVendedor,
                DetalhesCatalogoRota = detalhesCatalogoRota,
                DetalhesProdutoRota = detalhesProdutoRota,
                GerarKeyRota = gerarKeyRota
            };
        }

        private static void CreateIEGiftService()
        {
            var dados = ObterDadosBHN();

            var egiftHttpService = new EGiftHttpService(dados);

            IEGiftService eGiftService =
                new EGiftService(egiftHttpService, _factory.Create<IAcaoEGiftRepository>());

            _factory.Register<IEGiftService>(eGiftService);            
        }

        private static void CreateICatalogService()
        {
            var dados = ObterDadosBHN();

            ICatalogService catalogService =
                new CatalogService(new CatalogHttpService(dados));

            _factory.Register<ICatalogService>(catalogService);
        }

        private static void CreateIProdutoService()
        {
            var dados = ObterDadosBHN();

            IProdutoService produtoService =
                new ProdutoService(new ProdutoHttpService(dados));

            _factory.Register<IProdutoService>(produtoService);
        }
    }
}