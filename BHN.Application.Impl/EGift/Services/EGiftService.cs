using BHN.Application.EGift.Messages;
using BHN.Application.EGift.Services;
using BHN.Application.Impl.EGift.Mappers;
using BHN.Domain.EGifts.Mappers;
using BHN.Domain.EGifts.Messages;
using BHN.Domain.EGifts.Models;
using BHN.Domain.EGifts.Repositories;
using BHN.Domain.EGifts.Services;
using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BHN.Application.Impl.EGift.Services
{
    public class EGiftService : IEGiftService
    {
        private readonly IEGiftHttpService _httpService;

        private readonly IAcaoEGiftRepository _acaoEGiftRepository;


        public EGiftService(IEGiftHttpService httpService, IAcaoEGiftRepository acaoEGiftRepository)
        {
            this._httpService = httpService;
            this._acaoEGiftRepository = acaoEGiftRepository;
        }

        public async Task<GerarCompraResponse> GerarCodigo(GerarCompraRequest request)
        {
            var response = new GerarCompraResponse();

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
                    request.GerarEGift.RequisicaoId = request.GerarEGift.RequisicaoId ?? request.GerarEGift.GerarRequisicaoId();
                    var gerarEGift = request.GerarEGift.Map();

                    if (!gerarEGift.Validar())
                    {
                        response.Valido = false;
                        response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Dados para Geração do EGift inválidos");
                        return response;
                    }

                    var result = await gerarEGift.Gerar(gerarEGift.RequisicaoId);

                    response.Valido = result.Valido;

                    if (!result.Valido)
                    {                       
                        response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Não foi possível gerar o EGift");
                    }
                    else response.EGift = gerarEGift.Map();
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
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.Message);
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }

        public async Task<DesfazimentoResponse> Desfazimento(DesfazimentoRequest request)
        {
            var response = new DesfazimentoResponse();

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
                    var desfazimentoResponse = await _httpService.DesfazimentoEGift(new DesfazimentoEGiftRequest()
                    {
                        RequisicaoId = request.RequisicaoId
                    });

                    response.Valido = true;

                    return response;
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
    }
}