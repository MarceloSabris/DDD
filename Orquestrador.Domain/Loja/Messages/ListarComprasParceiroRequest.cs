using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/loja/v1/compras")]
    public class ListarComprasParceiroRequest : BaseRequest
    {
        [DataMember(Name = "IdCompra")]
        public int IdCompra { get; set; }
        
        [DataMember(Name = "IdCompraEntregaSku")]
        public int IdCompraEntregaSku { get; set; }

        [DataMember(Name = "IdProdutoParceiro")]
        public int IdProdutoParceiro { get; set; }
    }
}
