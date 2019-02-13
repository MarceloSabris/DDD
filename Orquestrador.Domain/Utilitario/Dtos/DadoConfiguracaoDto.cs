using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Dtos
{
    [DataContract(Name = "DadoConfiguracaoDto", Namespace = "http://www.suanova.com.br/utilitario/parametros/dadosconfiguracao/types/")]
    public class DadoConfiguracaoDto
    {
        [DataMember(Name = "IdDadosConfiguracao")]
        public int IdDadosConfiguracao { get; set; }

        [DataMember(Name = "Nome")]
        public string Nome { get; set; }

        [DataMember(Name = "Valor")]
        public string Valor { get; set; }
    }
}
