using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BHN.Application.EGift.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/egift")]
    public class GerarChaveRequest : BaseRequest
    {
    }
}
