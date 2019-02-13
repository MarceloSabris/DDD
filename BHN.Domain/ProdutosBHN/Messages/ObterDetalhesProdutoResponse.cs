using Enterprise.Framework.Services.Messages;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BHN.Domain.ProdutosBHN.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/catalog")]
    public class ObterDetalhesProdutoResponse : BaseResponse
    {
        [DataMember]
        public string IdProduto { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public decimal Preco { get; set; }
        [DataMember]
        public decimal PrecoMaximo { get; set; }
        [DataMember]
        public string TermosCondicoes { get; set; }
        [DataMember]
        public string TextoAtivacao { get; set; }
        [DataMember]
        public string ConfiguracaoPadrao { get; set; }
        [DataMember]
        public List<ConfiguracaoProdutoResponse> Configuracoes { get; set; }        
    }
}