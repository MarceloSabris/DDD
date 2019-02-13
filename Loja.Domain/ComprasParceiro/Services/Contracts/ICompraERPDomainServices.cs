using Enterprise.Framework.Domain.Events;
using Loja.Domain.ComprasParceiro.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Services.Contracts
{
	public interface ICompraERPDomainServices : 
		IDomainEventHandle<AlterarStatusERPEvent>
    {
    }
}
