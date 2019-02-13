using Loja.Application.Compras.Dtos;
using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.Compras.Mappers
{
   public static  class CompraMapper
    {
        public static CompraDto Map(this Compra entity)
        {
            if (entity == null) return null;
            return new CompraDto()
            {
               Email=entity.Email,
               IdCompra=entity.IdCompra,
               IdCompraEntregaSku=entity.IdCompraEntregaSku,
               IdProdutoParceiro=entity.IdProdutoParceiro
            };
        }

        public static Compra Map(this CompraDto entity)
        {
            if (entity == null) return null;
            return new Compra()
            {
                Email = entity.Email,
                IdCompra = entity.IdCompra,
                IdCompraEntregaSku = entity.IdCompraEntregaSku,
                IdProdutoParceiro = entity.IdProdutoParceiro
            };
        }
    }
}
