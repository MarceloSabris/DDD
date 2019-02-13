using Loja.Application.Ativacao.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Ativacao.Services
{
    public interface IAtivacaoService
    {
        Task<ListarComprasComAtivacaoResponse> ListarComAtivacao(ListarComprasComAtivacaoRequest request);

        Task<AlterarStatusAtivacaoResponse> AlterarStatusAtivacao(AlterarStatusAtivacaoRequest request);
    }
}
