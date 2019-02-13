using Enterprise.Framework.Services.Messages;
using System.Runtime.Serialization;

namespace BHN.Application.EGift.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/egift")]
    public class DesfazimentoResponse : BaseResponse
    {
    }
}
