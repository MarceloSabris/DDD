using BHN.Application.EGift.Messages;
using System.Threading.Tasks;

namespace BHN.Application.EGift.Services
{
    public interface IEGiftService
    {
        Task<GerarCompraResponse> GerarCodigo(GerarCompraRequest request);

        Task<DesfazimentoResponse> Desfazimento(DesfazimentoRequest request);
    }
}
