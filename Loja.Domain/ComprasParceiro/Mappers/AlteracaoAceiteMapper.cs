using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Mappers
{
	internal static class AlteracaoAceiteMapper
	{
		internal static AlterarStatusAceite Map(this CompraParceiro entity)
		{
			return new AlterarStatusAceite
			{
				IdCompra = entity.IdCompra,
				IdCompraEntregaSku = entity.IdCompraEntregaSku,
				StatusAceite = entity.StatusAceite
			};
		}

	}
}
