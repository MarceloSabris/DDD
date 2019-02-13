
using Enterprise.Framework.Domain.BusinessResults;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Services.Messages;
using Loja.Domain.ComprasParceiro.Events;
using Loja.Domain.ComprasParceiro.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Compras.Models
{
    public class CompraERP
	{
		public int IdCompra { get; set; }
		public int IdCompraEntregaSku { get; set; }
		public string LogRetornoERP { get; set; }
		public DateTime? DataIntegracaoERP { get; set; }
		public int TentativasIntegracaoERP { get; set; }
		public long GerencialID { get; set; }
		public string StatusIntegracaoERP;
		public byte SequencialID { get; set; }


		public async Task<BusinessResult> AlterarStatusERP(string correlationId)
		{
			EventResult eventResult = await DomainEventManager.RaiseAsync(new AlterarStatusERPEvent(this, correlationId));
			if (!eventResult.IsValid)
				return eventResult.Map(TipoMensagem.ErroAplicacao);

			return eventResult.Map();
		}
		


	}
}