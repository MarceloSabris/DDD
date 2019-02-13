using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Compras.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
	    public int IdCompraEntregaSku { get; set; }
	    public int IdProdutoParceiro { get; set; }
	    public string Email { get; set; }
    }
}
