using Orquestrador.Domain.Loja.Dtos;
using Orquestrador.Domain.Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orquestrador.Domain.Loja.Mappers
{
    public static class PedidoERPMapper
    {
        public static List<Pedido> Map(this IEnumerable<CompraERPDto> list)
        {
            return list.Select(p => p.Map()).ToList();
        }

        public static Pedido Map(this CompraERPDto model)
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


        private static Cliente MapCliente(this CompraERPDto model)
        {
            return new Cliente()
            {
                            
            };
        }

        private static Sku MapSku(this CompraERPDto model)
        {
            return new Sku()
            {
                IdCompraEntregaSku = model.IdCompraEntregaSku,
                GerencialId=model.GerencialId,
                Sequencial=model.SequencialId,
                TentativasIntegracaoERP=model.TentativasIntegracaoERP,
                DataIntegracaoERP=model.DataIntegracaoERP,
                LogRetornoERP=model.LogRetornoERP,
                StatusIntegracaoERP=model.StatusIntegracaoERP
            };
        }
    }
}
