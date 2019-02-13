using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Dtos
{
   public class AlterarStatusParceiroDto
    {
        public Int32 IdCompra { get; set; }
        public Int32 IdCompraEntregaSku { get; set; }
        public string StatusIntegracaoParceiro { get; set; }
        public DateTime? DataIntegracaoParceiro { get; set; }
        public string LogRetornoParceiro { get; set; }
        public string Hash { get; set; }
        public string Ativacao { get; set; }
        public string RequisicaoId { get; set; }
        public string ClienteId { get; set; }
        public int TentativasIntegracao { get; set; }
    }
}
