using Loja.Application.ComprasParceiro.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.TermoAceite.Dtos
{
   public class CompraParceiroProdutoDto : CompraParceiroDto
    {
        public int Tipo { get; set; }
        public decimal ValorVendaUnidade { get; set; }
        public string SkuParceiro { get; set; }
        public int IdSku { get; set; }
    }
}
