using Enterprise.Framework.Services.Messages;
using Orquestrador.Application.Parceiro.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Application.Parceiro.Messages
{
    [DataContract(Namespace = "http://orquestrador.api-cnova.com.br/orq/v1/pedidoparceiro")]
    public class ConsultarPedidosParceiroResponse : BaseResponse
    {
        [DataMember(Name = "ComprasParceiro")]
        public List<CompraParceiroDto> ComprasParceiro {get;set;}
    }
}
