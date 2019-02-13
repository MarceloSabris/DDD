using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Messages
{
    [DataContract(Namespace = "http://www.suanova.com.br/email/offline/enviaremail/types/")]
    public class EnviarEmailResponse : BaseResponse
    {
        [DataMember(Name = "EmailEnviado")]
        public System.Boolean EmailEnviado { get; set; }
    }
}
