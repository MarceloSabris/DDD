using Enterprise.Framework.Services.Messages;

namespace BHN.Domain.EGifts.Messages
{
    public class GenerateEGiftKeyRequest : BaseRequest
    {
        public string Hash { get; set; }
        public string IdCliente { get; set; }
    }
}