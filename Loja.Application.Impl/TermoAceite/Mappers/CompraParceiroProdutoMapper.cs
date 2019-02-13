
using Loja.Application.TermoAceite.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.TermoAceite.Mappers
{
    public static class CompraParceiroProdutoMapper
    {
        public static CompraParceiroProdutoDto Map(this CompraParceiroProduto entity)
        {
            if (entity == null) return null;

            return new CompraParceiroProdutoDto() {
                Ativacao=entity.Ativacao,
				DataStatusAceite = entity.DataStatusAceite,
				StatusAceite =   entity.StatusAceite,
				DataEnvioAceite =entity.DataEnvioAceite,
                DataEnvioAtivacao=entity.DataEnvioAtivacao,
                DataInclusao=entity.DataInclusao,
                DataIntegracaoParceiro=entity.DataIntegracaoParceiro,
                EmailEnvioAceito=entity.EmailEnvioAceito,
                EmailEnvioAtivacao=entity.EmailEnvioAtivacao,
                IdCompra=entity.IdCompra,
                IdCompraEntregaSku=entity.IdCompraEntregaSku,
                IdProdutoParceiro=entity.IdProdutoParceiro,
                LogRetornoParceiro=entity.LogRetornoParceiro,
                StatusIntegracaoParceiro=entity.StatusIntegracaoParceiro,
               Hash = entity.Hash,
               RequisicaoId = entity.RequisicaoId,
               TentativasIntegracao = entity.TentativasIntegracao,
               ClienteId=entity.ClienteId,
               Tipo=entity.Tipo,
               ValorVendaUnidade=entity.ValorVendaUnidade,
               SkuParceiro=entity.SkuParceiro,
               IdSku=entity.IdSku
            };
        }

        public static CompraParceiroProduto Map(this CompraParceiroProdutoDto entity)
        {
            if (entity == null) return null;

            return new CompraParceiroProduto()
            {
                Ativacao = entity.Ativacao,
				DataStatusAceite = entity.DataStatusAceite,
				StatusAceite = entity.StatusAceite,
				DataEnvioAceite = entity.DataEnvioAceite,
                DataEnvioAtivacao = entity.DataEnvioAtivacao,
                DataInclusao = entity.DataInclusao,
                DataIntegracaoParceiro = entity.DataIntegracaoParceiro,
                EmailEnvioAceito = entity.EmailEnvioAceito,
                EmailEnvioAtivacao = entity.EmailEnvioAtivacao,
                IdCompra = entity.IdCompra,
                IdCompraEntregaSku = entity.IdCompraEntregaSku,
                IdProdutoParceiro = entity.IdProdutoParceiro,
                LogRetornoParceiro = entity.LogRetornoParceiro,
                StatusIntegracaoParceiro = entity.StatusIntegracaoParceiro,
                Hash = entity.Hash,
                RequisicaoId = entity.RequisicaoId,
                TentativasIntegracao = entity.TentativasIntegracao,
                ClienteId=entity.ClienteId,
                ValorVendaUnidade=entity.ValorVendaUnidade,
                Tipo=entity.Tipo,
                SkuParceiro=entity.SkuParceiro,
                IdSku=entity.IdSku
            };
        }
    }
}
