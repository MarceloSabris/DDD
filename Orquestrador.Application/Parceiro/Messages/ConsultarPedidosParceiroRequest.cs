using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Application.Parceiro.Messages
{
    [DataContract(Namespace = "http://orquestrador.api-cnova.com.br/orq/v1/pedidoparceiro")]
    public class ConsultarPedidosParceiroRequest : BaseRequest
    {
        [DataMember(Name = "IdCompra")]
        public int IdCompra { get; set; }

        [DataMember(Name = "IdCompraEntregaSku")]
        public int IdCompraEntregaSku { get; set; }

        [DataMember(Name = "IdProdutoParceiro")]
        public int IdProdutoParceiro { get; set; }
    }
}
