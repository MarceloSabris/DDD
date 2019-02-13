using BHN.Domain.Catalog.Messages;
using System.Threading.Tasks;

namespace BHN.Application.Catalog.Services
{
    public interface ICatalogService
    {
        Task<VersaoCatalogoResponse> VerificarVersao(VersaoCatalogoRequest request);

        Task<ObterCatalogoResponse> ObterCatalogo(ObterCatalogoRequest request);

    }
}
