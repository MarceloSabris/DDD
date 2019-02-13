using Enterprise.Framework.Services.Messages;

namespace BHN.Domain.EGifts.Messages
{
    public class GenerateEGiftKeyResponse : BaseResponse
    {
        public string EntityId { get; set; }
        public string AccountNumber { get; set; }
        public string ActivationAccountNumber { get; set; }
        public string SecurityCode { get; set; }
        public string BalanceResponse { get; set; }
    }
}