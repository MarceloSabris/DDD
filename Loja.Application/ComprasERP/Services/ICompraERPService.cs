using Loja.Application.ComprasERP.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.ComprasERP.Services
{
    public interface ICompraERPService
    {
        Task<ListaComprasERPResponse> ListarAsync();

        Task<AlterarStatusERPResponse> AlterarStatusERPAsync(AlterarStatusERPRequest request);
    }
}
