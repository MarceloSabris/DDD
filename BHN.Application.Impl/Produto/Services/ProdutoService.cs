using BHN.Application.Produto.Services;
using BHN.Domain.EGifts.Messages;
using BHN.Domain.ProdutosBHN.Messages;
using BHN.Domain.ProdutosBHN.Services.Contracts;
using Enterprise.Framework.Services.Messages;
using System;
using System.Threading.Tasks;

namespace BHN.Application.Impl.Produto.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoHttpService _httpService;

        public ProdutoService(IProdutoHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ObterDetalhesProdutoResponse> DetalhesProduto(ObterDetalhesProdutoRequest request)
        {
            var response = new ObterDetalhesProdutoResponse();

            try
            {
                var validationResult = request.Validate();
                if (!validationResult.IsValid)
                {
                    response.Valido = false;
                    foreach (var failure in validationResult.Errors)
                        response.AdicionarMensagemErro(TipoMensagem.Validacao, failure.ErrorMessage);
                }
                else
                {
                    var produtoRequest = await this._httpService.DetalhesProduto(request);
                    return produtoRequest;
                }
            }
            catch (BHNResponseException bhnEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.Aplicacao, bhnEx.ToString());
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
