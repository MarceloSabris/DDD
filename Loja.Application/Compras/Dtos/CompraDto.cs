using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Compras.Dtos
{
    public class CompraDto
    {
        public int IdCompra { get; set; }
        public int IdCompraEntregaSku { get; set; }
        public int IdProdutoParceiro { get; set; }
        public string Email { get; set; }
    }
}
