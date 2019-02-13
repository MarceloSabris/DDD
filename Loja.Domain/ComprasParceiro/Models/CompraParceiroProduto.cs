using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Models
{
    public class CompraParceiroProduto : CompraParceiro
    {
        public decimal ValorVendaUnidade { get; set; }
        public int Tipo { get; set; }
        public string SkuParceiro { get; set; }
        public int IdSku { get; set; }
    }
}
