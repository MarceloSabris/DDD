using Enterprise.Framework.Services.Messages;
using System.Runtime.Serialization;

namespace Orquestrador.Domain.Parceiro.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/egift")]
    public class GerarCodigoResponse : BaseResponse
    {
        [DataMember(Name = "Hash")]
        public string Hash { get; set; }

        [DataMember(Name = "Ativacao")]
        public string Ativacao { get; set; }

        [DataMember(Name = "RequisicaoId")]
        public string RequisicaoId { get; set; }

        [DataMember(Name = "ClienteId")]
        public string ClienteId { get; set; }
    }
}