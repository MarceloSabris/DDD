using BHN.Domain.EGifts.Messages;
using System.Threading.Tasks;

namespace BHN.Domain.EGifts.Services
{
    public interface IEGiftHttpService
    {
        Task<GenerateEGiftHashResponse> GerarHashEGift(GenerateEGiftHashRequest request);
        Task<GenerateEGiftKeyResponse> GerarKeyEGift(GenerateEGiftKeyRequest request);
        Task<DesfazimentoEGiftResponse> DesfazimentoEGift(DesfazimentoEGiftRequest request);
    }
}
