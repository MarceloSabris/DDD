using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Dtos
{
    public class AlterarStatusAceite
    {
		 public Int32 IdCompra { get; set; }
		 public  Int32 IdCompraEntregaSku { get; set; }
		 public string StatusAceite { get; set; }
	}
}
