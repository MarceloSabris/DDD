using Orquestrador.Domain.Parceiro.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Domain.Parceiro.Repositories
{
    public interface IParceiroHttpRepository
    {
        Task<GerarCodigoResponse> GerarCodigo(GerarCodigoRequest request);
    }
}
