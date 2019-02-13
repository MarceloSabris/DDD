using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Dtos
{
    public class AlterarStatusAtivacao
    {
		 public Int32 IdCompra { get; set; }
		 public  Int32 IdCompraEntregaSku { get; set; }
		 public DateTime? DataEnvioAtivacao { get; set; }
	}
}
