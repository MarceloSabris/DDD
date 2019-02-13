using Enterprise.Framework.Services.Messages;

namespace BHN.Domain.EGifts.Messages
{
    public class GenerateEGiftHashRequest : BaseRequest
    {
        public string RequisicaoId { get; set; }
        public string VendedorId { get; set; }
        public string ClienteId { get; set; }
        public string ProductConfigutationId { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Preco { get; set; }
        public int TentativasAnteriores { get; set; }
    }
}