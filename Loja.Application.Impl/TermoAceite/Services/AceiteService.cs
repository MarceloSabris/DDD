using Enterprise.Framework.Services.Messages;
using Loja.Application.Impl.ComprasParceiro.Mappers;
using Loja.Application.Impl.TermoAceite.Mappers;
using Loja.Application.TermoAceite.Messages;
using Loja.Application.TermoAceite.Services.Contracts;
using Loja.Domain.ComprasParceiro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Impl.TermoAceite.Services
{
    public class AceiteService : IAceiteService
    {
        private readonly ICompraParceiroRepository _compraParceiroRepository;

        public AceiteService(ICompraParceiroRepository compraParceiroRepository)
        {
            this._compraParceiroRepository = compraParceiroRepository;
        }

        public async Task<StatusAceiteResponse> AlterarStatusAceite(StatusAceiteRequest request)
        {
            var response = new StatusAceiteResponse();

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
                var compraParceiro = request.Map();

                string correlationId = System.Guid.NewGuid().ToString();

                var result = await compraParceiro.AlterarStatusAceite(correlationId);

                if (!result.Valido)
                {
                    response.Valido = false;
                    response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Não foi possível alterar status aceite.");
                }
                else
                {
                    response.AlterarStatus = true;
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

        public async Task<ListarCompraComAceiteResponse> ListarComAceite(ListarComprasComAceiteRequest request)
        {
            var response = new ListarCompraComAceiteResponse();
            try
            {
                var compras = await this._compraParceiroRepository.ListarComAceite();

                response.ComprasParceiro = compras.Select(c => c.Map()).ToList();
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
