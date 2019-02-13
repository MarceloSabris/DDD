using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Utilitario.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Messages
{
    public class EnviarEmailRequest : BaseRequest
    {
        [DataMember(Name = "Email")]
        public EmailDto Email { get; set; }
    }
}
