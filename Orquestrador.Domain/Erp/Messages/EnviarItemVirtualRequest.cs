using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Erp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Erp.Messages
{
    public class EnviarItemVirtualRequest : BaseRequest
    {
        public ItemEntradaVirtualDto ItemVirtual { get; set; }
    }
}
