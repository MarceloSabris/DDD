using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Infrastructure.Http.Shared
{
   public class DadosUtilitario
    {
        public string HttpAddress { get; set; }
        public string RotaEnviarEmailOffline { get; set; }
        public string RotaObterDadosConfiguracao { get; set; }
        public string Authorization { get; set; }
    }
}
