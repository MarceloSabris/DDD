namespace BHN.Domain.EGifts.Dtos
{
    public class GerarKeyResponse
    {
        public string EntityId { get; set; }
        public string AccountNumber { get; set; }
        public string ActivationAccountNumber { get; set; }
        public string SecurityCode { get; set; }
        public string BalanceResponse { get; set; }
    }
}
