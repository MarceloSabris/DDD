using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Dtos
{
    public class CompraParceiroProdutoDto : CompraParceiroDto
    {
        public int Tipo { get; set; }
        public decimal ValorVendaUnidade { get; set; }
        public string SkuParceiro { get; set; }
        public int IdSku { get; set; }
    }
}
