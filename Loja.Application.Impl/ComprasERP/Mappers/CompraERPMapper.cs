
using Loja.Application.ComprasERP.Dtos;
using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Loja.Application.Impl.ComprasERP.Mappers
{
	static class CompraERPMapper
	{


		public static CompraERPDto Map(this CompraERP entity)
		{
			if (entity == null) return null;
			return new CompraERPDto()
			{
				IdCompra = entity.IdCompra,
				IdCompraEntregaSku = entity.IdCompraEntregaSku,
				GerencialID = entity.GerencialID,
				DataIntegracaoERP = entity.DataIntegracaoERP,
				LogRetornoERP = entity.LogRetornoERP,
				StatusIntegracaoERP = entity.StatusIntegracaoERP,
				TentativasIntegracaoERP = entity.TentativasIntegracaoERP,
				SequencialID = entity.SequencialID
			};
		}

		public static CompraERP MapStatus(this CompraERPDto entity)
		{
			if (entity == null) return null;

			return new CompraERP()
			{
				IdCompra = entity.IdCompra,
				DataIntegracaoERP = entity.DataIntegracaoERP,
				StatusIntegracaoERP = entity.StatusIntegracaoERP,
				GerencialID = entity.GerencialID,
				IdCompraEntregaSku = entity.IdCompraEntregaSku,
				LogRetornoERP = entity.LogRetornoERP,
				TentativasIntegracaoERP = entity.TentativasIntegracaoERP, 
				SequencialID = entity.SequencialID
			};
		}


	}
}