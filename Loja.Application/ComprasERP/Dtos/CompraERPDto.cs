using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.ComprasERP.Dtos
{
    public class CompraERPDto
    {
		public int IdCompra { get; set; }
		public int IdCompraEntregaSku { get; set; }
		public string LogRetornoERP { get; set; }
		public DateTime? DataIntegracaoERP { get; set; }
		public int TentativasIntegracaoERP { get; set; }
		public long GerencialID { get; set; }
		public byte SequencialID { get; set; }
		public string StatusIntegracaoERP { get; set; } 
	}
}
