using BHN.Domain.Catalog.Messages;
using System.Threading.Tasks;

namespace BHN.Domain.Catalog.Services.Contracts
{
    public interface ICatalogHttpService
    {
        Task<VersaoCatalogoResponse> VerificarVersao(VersaoCatalogoRequest request);

        Task<ObterCatalogoResponse> ObterCatalogo(ObterCatalogoRequest request);
    }
}
