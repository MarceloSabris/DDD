
using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.ComprasParceiro.Repositories
{
	public interface ICompraERPRepository
	{
		Task<IEnumerable<CompraERP>> ListarERP();
		Task<int> AlterarERPAsync(CompraERP compraERP);
	}
}
