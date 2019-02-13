using Orquestrador.Domain.Utilitario.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Domain.Utilitario.Repositories
{
    public interface IUtilitarioHttpRepository
    {
        Task<EnviarEmailResponse> EnviarEmailOffline(EnviarEmailRequest request);
        Task<ObterDadosConfiguracaoResponse> ObterDadosConfiguracao(ObterDadosConfiguracaoRequest request);
    }
}
