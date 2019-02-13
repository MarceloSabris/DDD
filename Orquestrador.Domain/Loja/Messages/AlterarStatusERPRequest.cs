using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Loja.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/compras")]
    public class AlterarStatusERPRequest : BaseRequest
    {
        
        public AlterarStatusERPRequest()
        {

        
        }
        [DataMember(Name = "CompraERP")]
        public CompraERPDto CompraERP { get; set; }

        
    }
}
