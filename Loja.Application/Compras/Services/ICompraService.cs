using Loja.Application.Compras.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Compras.Services
{
    public interface ICompraService
    {
        Task<ObterCompraElegivelResponse> ObterComprasElegiveis(ObterCompraElegivelRequest request);
    }
}
