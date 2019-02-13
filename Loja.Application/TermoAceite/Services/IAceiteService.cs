using Loja.Application.TermoAceite.Messages;
using System.Threading.Tasks;

namespace Loja.Application.TermoAceite.Services.Contracts
{
    public interface IAceiteService
    {
        Task<ListarCompraComAceiteResponse> ListarComAceite(ListarComprasComAceiteRequest request);

        Task<StatusAceiteResponse> AlterarStatusAceite(StatusAceiteRequest request);
    }
}