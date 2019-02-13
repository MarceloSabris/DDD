
using Enterprise.Framework.Services.Messages;
using System.Runtime.Serialization;

namespace Loja.Application.TermoAceite.Messages
{
    [DataContract(Namespace = "http://corporativo.api-cnova.com.br/Orquestradors/v1/postagens")]
    public class StatusAceiteResponse : BaseResponse
    {
        public bool AlterarStatus { get; set; }
    }
}