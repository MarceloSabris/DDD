using Enterprise.Framework.Services.Messages;
using Loja.Application.Ativacao.Messages;
using Loja.Application.Ativacao.Services;
using Loja.Application.Impl.Ativacao.Mappers;

using Loja.Domain.Compras.Repositories;
using Loja.Domain.ComprasParceiro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Impl.Ativacao.Services
{
    public class AtivacaoService : IAtivacaoService
    {
        private readonly ICompraRepository _compraRepository;
        

        public AtivacaoService(ICompraRepository compraRepository)
        {
            this._compraRepository = compraRepository;
        
        }

        public async Task<AlterarStatusAtivacaoResponse> AlterarStatusAtivacao(AlterarStatusAtivacaoRequest request)
        {
            var response = new AlterarStatusAtivacaoResponse();

            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                response.Valido = false;
                foreach (var failure in validationResult.Errors)
                    response.AdicionarMensagemErro(TipoMensagem.Validacao, failure.ErrorMessage);

                return response;
            }

           
            try
            {
                var compraParceiro = request.CompraAtivacao.MapStatus();

                string correlationId = System.Guid.NewGuid().ToString();

                var result = await compraParceiro.AlterarStatusAtivacao(correlationId);

                if (!result.Valido)
                {
                    response.Valido = false;
                    response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Alterar Status Ativação não foi realizado.");
                }
                else
                {
                    response.Valido = true;
                }

            }
            catch (ApplicationException appEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }

        public async Task<ListarComprasComAtivacaoResponse> ListarComAtivacao(ListarComprasComAtivacaoRequest request)
        {
            var response = new ListarComprasComAtivacaoResponse();
            try
            {
                var compras = await this._compraRepository.ListarComAtivacao();

                response.ComprasAtivacao = compras.Select(c => c.Map()).ToList();
                response.Valido = true;

            }
            catch (ApplicationException appEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }
    }
}
