using Loja.Application.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.ComprasParceiro.Mappers
{
    public static class CompraParceiroMapper
    {
        public static CompraParceiroDto Map(this CompraParceiro entity)
        {
            if (entity == null) return null;

            return new CompraParceiroDto() {
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
               ClienteId=entity.ClienteId
            };
        }

        public static CompraParceiro Map(this CompraParceiroDto entity)
        {
            if (entity == null) return null;

            return new CompraParceiro()
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
                ClienteId=entity.ClienteId
            };
        }
    }
}
