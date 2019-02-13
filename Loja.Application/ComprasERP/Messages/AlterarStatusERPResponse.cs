using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.ComprasERP.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/compras")]
    public class AlterarStatusERPResponse : BaseResponse
    {
    }
}
