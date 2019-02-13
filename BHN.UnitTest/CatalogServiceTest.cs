using BHN.Application.Impl.Catalog.Services;
using BHN.Domain.Catalog.Messages;
using BHN.Infrastructure.Http.Catalog.Services;
using BHN.Infrastructure.Http.Shared;
using System.Linq;
using Xunit;

namespace BHN.UnitTest
{
    public class CatalogServiceTest
    {
        private CatalogService ObterService()
        {
            return new CatalogService(new CatalogHttpService(new DadosBhn()
            {
                CertificadoCaminho = @"C:\GIT\BHN\certificado_bhn_PREPROD.p12",
                CertificadoSenha = "LPNKNC24RZPZ3Z27FCQ2BZH2HC",
                UrlApi = "https://api.certification.blackhawknetwork.com/",
                VersaoCatalogoRota = "productCatalogManagement/v1/productCatalogs",
                DetalhesCatalogoRota = "productCatalogManagement/v1/productCatalog/{0}"
            }));
        }

        [Fact(DisplayName = "Testa o Servico de Verificar Versão do Catalogo")]
        public async void TestarVersaoCatalogo()
        {
            var request = new VersaoCatalogoRequest();

            var response = await ObterService().VerificarVersao(request);

            Assert.True(response.Valido && response.Catalogos.Any());
        }

        [Fact(DisplayName = "Testa o Servico de Obter Produtos do Catalogo")]
        public async void TestarObterCatalogo()
        {
            var request = new ObterCatalogoRequest()
            {
                IdCatalogo = "1LY7A4ZK4L5KVAKXA7HF4T4SQC"
            };

            var response = await ObterService().ObterCatalogo(request);

            Assert.True(response.Valido && response.IdProdutos.Any());
        }

        [Fact(DisplayName = "Testa a falha no Servico de Obter Produtos do Catalogo")]
        public async void TestarExceptionObterCatalogo()
        {
            var request = new ObterCatalogoRequest()
            {
                IdCatalogo = "FAIL"
            };

            var response = await ObterService().ObterCatalogo(request);

            Assert.True(!response.Valido && response.Mensagens.Any());
        }
    }
}