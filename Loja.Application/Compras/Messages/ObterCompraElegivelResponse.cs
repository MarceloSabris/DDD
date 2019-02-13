using Enterprise.Framework.Services.Messages;
using Loja.Application.Compras.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.Compras.Messages
{
    [DataContract(Namespace = "http://lojabhn.api-cnova.com.br/loja/v1/compras")]
    public class ObterCompraElegivelResponse : BaseResponse
    {
        [DataMember(Name = "ComprasElegives")]
        public List<CompraDto> ComprasElegives { get; set; }
    }
}
