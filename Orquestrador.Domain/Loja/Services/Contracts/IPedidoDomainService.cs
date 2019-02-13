using Enterprise.Framework.Domain.Events;
using Orquestrador.Domain.Loja.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Services.Contracts
{
    public interface IPedidoDomainService : IDomainEventHandle<EnviarCodigoClienteEvent>,
        IDomainEventHandle<EnfileirarEvent>, IDomainEventHandle<IntegrarParceiroEvent>,
        IDomainEventHandle<IntegrarERPEvent>
    {
    }
}
