using Enterprise.Framework.Services.Messages;

namespace BHN.Domain.EGifts.Messages
{
    public class DesfazimentoEGiftRequest : BaseRequest
    {
        public string RequisicaoId { get; set; }
    }
}
