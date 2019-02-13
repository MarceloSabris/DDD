using BHN.Application.Catalog.Services;
using BHN.Domain.Catalog.Messages;
using BHN.Domain.Catalog.Services.Contracts;
using BHN.Domain.EGifts.Messages;
using Enterprise.Framework.Services.Messages;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BHN.Application.Impl.Catalog.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogHttpService _httpService;

        public CatalogService(ICatalogHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ObterCatalogoResponse> ObterCatalogo(ObterCatalogoRequest request)
        {
            var response = new ObterCatalogoResponse();

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
                    var obterCatalogoResponse = await _httpService.ObterCatalogo(request);

                    obterCatalogoResponse.Valido = true;

                    return obterCatalogoResponse;
                }
            }
            catch(BHNResponseException bhnEx)
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

        public async Task<VersaoCatalogoResponse> VerificarVersao(VersaoCatalogoRequest request)
        {
            var response = new VersaoCatalogoResponse();

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
                    var verificarCatalogoResponse = await _httpService.VerificarVersao(request);

                    verificarCatalogoResponse.Valido = true;

                    return verificarCatalogoResponse;
                }

            }
            catch (HttpRequestException httpEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.Aplicacao, httpEx.Message);                
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