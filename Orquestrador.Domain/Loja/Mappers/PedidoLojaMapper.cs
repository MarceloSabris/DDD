using Orquestrador.Domain.Loja.Dtos;
using Orquestrador.Domain.Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orquestrador.Domain.Loja.Mappers
{
    public static class PedidoLojaMapper
    {
        public static List<Pedido> Map(this List<CompraElegivelDto> list)
        {
            return list.Select(p => p.Map()).ToList();
        }

        public static Pedido Map(this CompraElegivelDto model)
        {
            return new Pedido()
            {
                Cliente = MapCliente(model),
                IdCompra = model.IdCompra,
                Skus = new List<Sku>()
                {
                    MapSku(model)
                }
            };
        }


        private static Cliente MapCliente(this CompraElegivelDto model)
        {
            return new Cliente()
            {
                EmailEnvioAceito = model.Email,
                EmailEnvioAtivacao = model.Email
            };
        }

        private static Sku MapSku(this CompraElegivelDto model)
        {
            return new Sku()
            {
                IdCompraEntregaSku = model.IdCompraEntregaSku,
                IdProdutoParceiro = model.IdProdutoParceiro
            };
        }


    }
}
