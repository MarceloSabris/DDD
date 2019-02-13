using Orquestrador.Domain.Loja.Dtos;
using Orquestrador.Domain.Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orquestrador.Domain.Loja.Mappers
{
    public static class PedidoParceiroMapper
    {
        public static List<Pedido> Map(this List<CompraParceiroProdutoDto> list)
        {
            return list.Select(p => p.Map()).ToList();
        }

        public static Pedido Map(this CompraParceiroProdutoDto model)
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


        private static Cliente MapCliente(this CompraParceiroProdutoDto model)
        {
            return new Cliente()
            {
                EmailEnvioAceito = model.EmailEnvioAceito,
                EmailEnvioAtivacao = model.EmailEnvioAtivacao,                
            };
        }

        private static Sku MapSku(this CompraParceiroProdutoDto model)
        {
            return new Sku()
            {
                IdCompraEntregaSku = model.IdCompraEntregaSku,
                IdProdutoParceiro = model.IdProdutoParceiro,
                Ativacao=model.Ativacao,
                Hash=model.Hash,
                RequisicaoId=model.RequisicaoId,
                ClienteId=model.ClienteId,
                DataIntegracaoParceiro=model.DataIntegracaoParceiro,
                LogRetornoParceiro=model.LogRetornoParceiro,
                StatusIntegracaoParceiro=model.StatusIntegracaoParceiro,
                Preco=model.ValorVendaUnidade,
                Tipo=model.Tipo,
                SkuParceiro=model.SkuParceiro,
                IdSku=model.IdSku,
                TentativasIntegracao=model.TentativasIntegracao
            };
        }
    }
}
