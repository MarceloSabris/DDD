
using Enterprise.Framework.Domain.Events;
using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Events
{
    public class AlterarStatusERPEvent : IDomainEvent
	{
		public CompraERP compraERP;
		public string correlationId;

		public AlterarStatusERPEvent(CompraERP compraERP, string correlationId)
		{
			this.compraERP = compraERP;
			this.correlationId = correlationId;
		}

		


	}
}