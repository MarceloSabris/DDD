using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Dtos
{
    
    public class CompraElegivelDto
    {
        public int IdCompra { get; set; }
        public int IdCompraEntregaSku { get; set; }
        public int IdProdutoParceiro { get; set; }
        public string Email { get; set; }
    }
}
