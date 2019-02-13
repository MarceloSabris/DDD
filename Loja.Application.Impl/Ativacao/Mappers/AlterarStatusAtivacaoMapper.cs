using Loja.Application.Ativacao.Dtos;

using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.Ativacao.Mappers
{
    public static class AlterarStatusAtivacaoMapper
    {
        public static AlterarStatusAtivacaoDto MapStatus(this CompraParceiro entity)
        {
            if (entity == null) return null;

            return new AlterarStatusAtivacaoDto() {                
                IdCompra=entity.IdCompra,
                IdCompraEntregaSku=entity.IdCompraEntregaSku,                
                DataEnvioAtivacao=entity.DataEnvioAtivacao
            };
        }

        public static CompraParceiro MapStatus(this AlterarStatusAtivacaoDto entity)
        {
            if (entity == null) return null;

            return new CompraParceiro()
            {
                IdCompra = entity.IdCompra,
                IdCompraEntregaSku = entity.IdCompraEntregaSku,
                DataEnvioAtivacao = entity.DataEnvioAtivacao
            };
        }
    }
}
