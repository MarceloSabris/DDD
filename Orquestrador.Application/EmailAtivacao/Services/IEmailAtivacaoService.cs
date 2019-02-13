using Orquestrador.Application.EmailAtivacao.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.EmailAtivacao.Services
{
    public interface IEmailAtivacaoService
    {
        Task<EnviarCodigoClienteResponse> EnviarCodigoCliente(EnviarCodigoClienteRequest request);
    }
}
