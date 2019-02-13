using BHN.Domain.EGifts.Events;
using BHN.Domain.Shared.Extensions;
using Enterprise.Framework.Domain.BusinessResults;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Services.Messages;
using System;
using System.Threading.Tasks;

namespace BHN.Domain.EGifts.Models
{
    public class GerarEGift
    {
        public string RequisicaoId { get; set; }
        public string ClienteId { get; set; }
        public string SKUParceiro { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Preco { get; set; }
        public bool GerarCodigoAtivacao { get; set; }
        public string Hash { get; set; }
        public int TentativasAnteriores { get; set; }
        public string Ativacao { get; set; }
        public bool DesfazimentoNecessario { get; set; }
        public bool DesfazimentoExecutado { get; set; }


        public bool Validar()
        {
            return
                !string.IsNullOrEmpty(SKUParceiro)
                || !string.IsNullOrWhiteSpace(SKUParceiro)
                || Preco > 0
                ;
        }

        public async Task<BusinessResult> Gerar(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new GerarEGiftEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }
    }
}