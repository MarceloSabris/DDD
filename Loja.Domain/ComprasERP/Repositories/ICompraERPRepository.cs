using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.ComprasERP.Repositories
{
    public interface ICompraERPRepository
    {
        Task<IEnumerable<CompraERP>> ListarCompraERP(int idCompra, int idCompraEntregaSku, int idProdutoParceiro);

        Task<int> AlterarStatusParceiro(CompraERP compra);
    }
}
