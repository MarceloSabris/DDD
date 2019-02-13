using Enterprise.Framework.Services.Messages;

namespace BHN.Domain.EGifts.Messages
{
    public class GenerateEGiftHashResponse : BaseResponse
    {
        public string EntityId { get; set; }
        public string AccountId { get; set; }
        public string Status { get; set; }
        public string ActivationUrl { get; set; }
    }
}