
using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Loja.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/compras")]
    public class AlterarStatusParceiroRequest : BaseRequest
    {
       
        [DataMember(Name = "CompraParceiro")]
        public AlterarStatusParceiroDto CompraParceiro { get; set; }

    }
}
