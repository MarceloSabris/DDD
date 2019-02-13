using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Utilitario.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Messages
{
    [DataContract(Namespace = "http://www.suanova.com.br/utilitario/parametros/dadosconfiguracao/types/")]
    public class ObterDadosConfiguracaoResponse : BaseResponse
    {
        [DataMember(Name = "Configuracao")]
        public DadoConfiguracaoDto Configuracao { get; set; }
    }
}
