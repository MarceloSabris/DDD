using Enterprise.Framework.Services.Messages;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BHN.Domain.Catalog.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/catalog")]
    public class ObterCatalogoResponse : BaseResponse
    {
        [DataMember]
        public DadosCatalogoResponse DadosCatalogo { get; set; }

        [DataMember]
        public List<string> IdProdutos { get; set; }
    }
}