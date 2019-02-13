using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BHN.Application.Utils
{
    [DataContract(Namespace = "http://corporativo.api-cnova.com.br/Orquestradors/v1/postagens")]
    public class BaseOrquestradorRequest : BaseRequest
    {
        public string Funcionario { get; set; }
        public string Protocolo { get; set; }
        public Guid CorrelationId { get; set; }
    }
}

