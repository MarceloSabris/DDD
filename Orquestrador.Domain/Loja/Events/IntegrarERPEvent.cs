using Enterprise.Framework.Domain.Events;
using Orquestrador.Domain.Loja.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Events
{
   public  class IntegrarERPEvent : IDomainEvent
    {
        public IntegrarERPEvent(Pedido pedido, string correlationId)
        {
            Pedido = pedido;
            CorrelationId = correlationId;
        }

        public string CorrelationId { get; private set; }
        public Pedido Pedido { get; private set; }
    }
}
