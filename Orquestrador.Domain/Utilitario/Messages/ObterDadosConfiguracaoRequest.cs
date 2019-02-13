using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Messages
{
    

    [DataContract(Namespace = "http://www.suanova.com.br/utilitario/parametros/dadosconfiguracao/types/")]
    public class ObterDadosConfiguracaoRequest : BaseRequest
    {
        [DataMember(Name = "Nome")]
        public string Nome { get; set; }
    }
}
