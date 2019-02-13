using Enterprise.Framework.Collections;
using Enterprise.Framework.WebApi.Security.Legacy.Common;
using Enterprise.Framework.WebApi.Security.Legacy.Services.Client.Authorization;
using System;

namespace Loja.Infrastructure.DI
{
    public class AuthorizationService : IAuthorizationServiceClient
    {
        private readonly ParsableNameValueCollection appSettings;

        public AuthorizationService(ParsableNameValueCollection appSettings)
        {
            this.appSettings = appSettings;
        }

        public AuthorizationConfig ObterConfiguracaoAutorizacao()
        {
            return new AuthorizationConfig()
            {
                UseInternalAuthorize = false,
                HostBaseAddress = HostPlataformaSeguranca(),
                RequestUri = "controleacesso/webtokens/autorizacao/AutorizarAcessoRecurso",
                UnidadeNegocio = UnidadesNegocio()
            };
        }

        private string UnidadesNegocio()
        {
            string unidadesNegocio = appSettings.TryGetAndParse<string>("IdUnidadeNegocioApi").ParsedValue;

            if (string.IsNullOrEmpty(unidadesNegocio))
                return "Corporativo";

            return unidadesNegocio;
        }

        private string HostPlataformaSeguranca()
        {
            string hostPlataformaSeguranca = appSettings.TryGetAndParse<string>("host-plataforma-seguranca").ParsedValue;

            if (string.IsNullOrEmpty(hostPlataformaSeguranca))
                throw new Exception("Host da plataforma de segurança não está definido.");

            return hostPlataformaSeguranca;
        }

        public AuthorizationResponse AutorizarAcessoRecurso(AuthorizationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
