using Enterprise.Framework.Services.Messages;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BHN.Domain.Catalog.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/catalog")]
    public class VersaoCatalogoResponse : BaseResponse
    {
        [DataMember]
        public List<DadosCatalogoResponse> Catalogos { get; set; }

        [DataMember]
        public int Total { get; set; }
    }
}