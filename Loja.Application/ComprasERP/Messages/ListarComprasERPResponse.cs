using Enterprise.Framework.Services.Messages;
using Loja.Application.ComprasERP.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.ComprasERP.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class ListaComprasERPResponse : BaseResponse
    {
        [DataMember(Name = "ComprasERP")]
        public IEnumerable<CompraERPDto> ComprasERP { get; set; }
    }
}
