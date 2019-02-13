using Loja.Application.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.ComprasParceiro.Mappers
{
    public static class AlterarStatusParceiroMapper
    {
        public static AlterarStatusParceiroDto MapStatus(this CompraParceiro entity)
        {
            if (entity == null) return null;

            return new AlterarStatusParceiroDto() {
                Ativacao=entity.Ativacao,				
                DataIntegracaoParceiro=entity.DataIntegracaoParceiro,                
                IdCompra=entity.IdCompra,
                IdCompraEntregaSku=entity.IdCompraEntregaSku,                
                LogRetornoParceiro=entity.LogRetornoParceiro,
                StatusIntegracaoParceiro=entity.StatusIntegracaoParceiro,
               Hash = entity.Hash,
               RequisicaoId = entity.RequisicaoId,
               TentativasIntegracao = entity.TentativasIntegracao,
               ClienteId=entity.ClienteId
            };
        }

        public static CompraParceiro MapStatus(this AlterarStatusParceiroDto entity)
        {
            if (entity == null) return null;

            return new CompraParceiro()
            {
                Ativacao = entity.Ativacao,
                DataIntegracaoParceiro = entity.DataIntegracaoParceiro,
                IdCompra = entity.IdCompra,
                IdCompraEntregaSku = entity.IdCompraEntregaSku,
                LogRetornoParceiro = entity.LogRetornoParceiro,
                StatusIntegracaoParceiro = entity.StatusIntegracaoParceiro,
                Hash = entity.Hash,
                RequisicaoId = entity.RequisicaoId,
                TentativasIntegracao = entity.TentativasIntegracao,
                ClienteId = entity.ClienteId
            };
        }
    }
}
