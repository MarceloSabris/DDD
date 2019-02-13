using Enterprise.Framework.Domain.BusinessResults;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Loja.Events;
using Orquestrador.Domain.Loja.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Domain.Loja.Models
{
    public class Pedido
    {
        public int IdCompra { get; set; }
               
        public Cliente Cliente { get; set; }

        public Endereco Endereco { get; set; }

        public List<Sku> Skus { get; set; }

        public async Task<BusinessResult> EnviarCodigoCliente(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new EnviarCodigoClienteEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }


        public async Task<BusinessResult> Enfileirar(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new EnfileirarEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }

        public async Task<BusinessResult> IntegrarParceiro(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new IntegrarParceiroEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }

        public async Task<BusinessResult> IntegrarERP(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new IntegrarERPEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }
    }
}
