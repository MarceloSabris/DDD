using Enterprise.Framework.Services.Messages;

using Orquestrador.Domain.Loja.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://lojabhn.api-cnova.com.br/loja/v1/compras")]
    public class ObterCompraElegivelResponse : BaseResponse
    {
        [DataMember(Name = "ComprasElegives")]
        public List<CompraElegivelDto> ComprasElegives { get; set; }
    }
}
