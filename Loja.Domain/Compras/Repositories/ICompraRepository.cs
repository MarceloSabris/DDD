using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Compras.Repositories
{
    public interface ICompraRepository
    {
        Task<IEnumerable<Compra>> ListarElegiveisAsync(DateTime? dataUltimaExecucao);
        
        Task<IEnumerable<CompraAtivacao>> ListarComAtivacao();
    }
}
