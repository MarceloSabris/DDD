using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Dtos
{
    [DataContract(Name = "Email", Namespace = "http://www.suanova.com.br/email/objects/")]
    public class ChaveValorDto
    {
        [DataMember(Name = "Chave")]
        public string Chave { get; set; }

        [DataMember(Name = "Valor")]
        public string Valor { get; set; }
    }
}
