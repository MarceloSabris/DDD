using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Dtos
{
    public class CompraERPDto
    {
        public int IdCompra { get; set; }
        public int IdCompraEntregaSku { get; set; }
        public string LogRetornoERP { get; set; }
        public DateTime? DataIntegracaoERP { get; set; }
        public int TentativasIntegracaoERP { get; set; }
        public long GerencialId { get; set; }
        public string StatusIntegracaoERP { get; set; }
        public byte SequencialId { get; set; }
    }
}
