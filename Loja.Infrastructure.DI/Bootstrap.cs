using CorreiosWS;
using Enterprise.Framework.Collections;
using Enterprise.Framework.DI;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Log;
using Enterprise.Framework.Logging;
using Enterprise.Framework.Logging.Utils;
using Enterprise.Framework.MongoDB;
using Enterprise.Framework.SqlClient;
using Enterprise.Framework.WebApi.Security.Legacy.Services.Client.Authorization;
using Loja.Application.Ativacao.Services;
using Loja.Application.Compras.Services;
using Loja.Application.ComprasERP.Services;
using Loja.Application.ComprasParceiro.Services;
using Loja.Application.Impl.Ativacao.Services;
using Loja.Application.Impl.Compras.Services;
using Loja.Application.Impl.ComprasERP.Services;
using Loja.Application.Impl.ComprasParceiro.Services;
using Loja.Application.Impl.TermoAceite.Services;
using Loja.Application.TermoAceite.Services.Contracts;
using Loja.Domain.Compras.Repositories;
using Loja.Domain.ComprasParceiro.Events;
using Loja.Domain.ComprasParceiro.Repositories;
using Loja.Domain.ComprasParceiro.Services.Contracts;
using Loja.Domain.ComprasParceiro.Services.Implementations;

using Loja.Infrastructure.MongoDb.Common;
using Loja.Infrastructure.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Diagnostics.EventFlow;
using Microsoft.Diagnostics.EventFlow.Inputs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.ServiceModel;

namespace Loja.Infrastructure.DI
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
			var pipe = DiagnosticPipelineFactory.CreatePipeline("eventFlow.json");
			_loggerFactory = new LoggerFactory().AddEventFlow(pipe);

            var loggerService = new LoggerService(new Log<LoggerService>(_loggerFactory));

            _factory.Register<ILoggerService>(
                loggerService
             );

            _factory.Register<IResponseUtil>(
                new ResponseUtil(loggerService)
               );
            
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

			_factory.Register<ICompraRepository>(
			   new CompraRepository(new ConectionFactory(_appSettings)));

			_factory.Register<ICompraParceiroRepository>(
			  new CompraParceiroRepository(new ConectionFactory(_appSettings)));
		
			_factory.Register<ICompraERPRepository>(
			  new CompraParceiroRepository(new ConectionFactory(_appSettings)));


		}

		private void RegisterValidators()
		{
            //_factory.Register<IPostagemServiceValidator>(
            //    new PostagemServiceValidator(_factory.Create<ICodeMessageRepository>()));

          
        }

		private void RegisterServices()
		{

			_factory.Register<ICompraParceiroDomainService>(
			  new CompraParceiroDomainService(_factory.Create<Domain.ComprasParceiro.Repositories.ICompraParceiroRepository>())
		  );

			ICompraService compraService =
			   new CompraService(_factory.Create<ICompraRepository>());

			_factory.Register<ICompraService>(compraService);

			ICompraParceiroService compraParceiroService =
				new CompraParceiroService(_factory.Create<ICompraParceiroRepository>());

			_factory.Register<ICompraParceiroService>(compraParceiroService);

			IAceiteService aceiteService =
			   new AceiteService(_factory.Create<ICompraParceiroRepository>());

			_factory.Register<IAceiteService>(aceiteService);

			IAtivacaoService ativacaoService =
			   new AtivacaoService(_factory.Create<ICompraRepository>());

			_factory.Register<IAtivacaoService>(ativacaoService);

            ICompraERPService compraERPservice =
              new CompraERPService(_factory.Create<ICompraERPRepository>(),
                                    _factory.Create<IResponseUtil>());

			_factory.Register<ICompraERPService>(compraERPservice);

			_factory.Register<ICompraERPDomainServices>(
			  new CompraERPDomainServices(_factory.Create<ICompraERPRepository>())
		  );

		}

		private void RegisterEvents()
		{

			DomainEventManager.For<InserirEvent>()
							.Use<ICompraParceiroDomainService>(
			  () => _factory.Create<ICompraParceiroDomainService>()
		  );

			DomainEventManager.For<AlterarEvent>()
						   .Use<ICompraParceiroDomainService>(
			 () => _factory.Create<ICompraParceiroDomainService>()
		 );

			DomainEventManager.For<ObterUltimaEvent>()
							  .Use<ICompraParceiroDomainService>(
				() => _factory.Create<ICompraParceiroDomainService>()
			);

			DomainEventManager.For<AlterarStatusAceiteEvent>()
							 .Use<ICompraParceiroDomainService>(
			   () => _factory.Create<ICompraParceiroDomainService>()
		   );


			DomainEventManager.For<AlterarStatusParceiroEvent>()
							 .Use<ICompraParceiroDomainService>(
			   () => _factory.Create<ICompraParceiroDomainService>()
		   );


			DomainEventManager.For<AlterarStatusAtivacaoEvent>()
							 .Use<ICompraParceiroDomainService>(
			   () => _factory.Create<ICompraParceiroDomainService>()
		   );

			DomainEventManager.For<AlterarStatusERPEvent>()
						   .Use<ICompraERPDomainServices>(
			 () => _factory.Create<ICompraERPDomainServices>()
		 );
		}

	






}
}