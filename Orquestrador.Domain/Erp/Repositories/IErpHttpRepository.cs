using Orquestrador.Domain.Erp.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Domain.Erp.Repositories
{
    public interface IErpHttpRepository
    {
        Task<EnviarItemVirtualResponse> EnviarItemVirtual(EnviarItemVirtualRequest request);
    }
}
