using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Mappers
{
	internal static class AlteracaoParceiroMapper
    {
		internal static AlterarStatusParceiro MapParceiro(this CompraParceiro entity)
		{
			return new AlterarStatusParceiro
			{
				IdCompra = entity.IdCompra,
				IdCompraEntregaSku = entity.IdCompraEntregaSku,
				Ativacao=entity .Ativacao,
                ClienteId=entity.ClienteId,
                DataIntegracaoParceiro=entity.DataIntegracaoParceiro,
                Hash=entity.Hash,
                LogRetornoParceiro=entity.LogRetornoParceiro,
                RequisicaoId=entity.RequisicaoId,
                StatusIntegracaoParceiro=entity.StatusIntegracaoParceiro,
                TentativasIntegracao=entity.TentativasIntegracao,
                
			};
		}

	}
}
