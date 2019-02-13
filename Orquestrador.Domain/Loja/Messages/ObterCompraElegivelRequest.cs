using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://lojabhn.api-cnova.com.br/loja/v1/compras")]
    public class ObterCompraElegivelRequest : BaseRequest
    {
        [DataMember(Name = "DataUltimaExecucao")]
        public DateTime? DataUltimaExecucao { get; set; }
    }
}
