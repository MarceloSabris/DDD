using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Infrastructure.Http.Shared
{
    public class DadosLoja
    {
        public string ApiLojaAddressHost { get; set; }
        public string RotaListarComAtivacao { get; set; }
        public string RotaObterElegiveis { get; set; }
        public string RotaInserirCompraParceiro { get; set; }
        public string RotaAlterarStatusParceiro { get; set; }
        public string RotaAlterarStatusAtivacao { get; set; }
        public string RotaListarComAceite { get; set; }
        public string RotaListarCompraParceiro { get; set; }
        public string RotaListarComprasERP { get; set; }
        public string RotaAlterarStatusERP { get; set; }

    }
}
