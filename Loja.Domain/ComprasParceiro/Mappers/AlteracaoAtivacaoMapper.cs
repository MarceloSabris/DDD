using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Mappers
{
	internal static class AlteracaoAtivacaoMapper
    {
		internal static AlterarStatusAtivacao MapAtivacao(this CompraParceiro entity)
		{
			return new AlterarStatusAtivacao
			{
				IdCompra = entity.IdCompra,
				IdCompraEntregaSku = entity.IdCompraEntregaSku,
                DataEnvioAtivacao=entity.DataEnvioAtivacao
			};
		}

	}
}
