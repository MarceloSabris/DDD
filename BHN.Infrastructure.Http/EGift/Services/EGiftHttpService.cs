using BHN.Domain.EGifts.Dtos;
using BHN.Domain.EGifts.Mappers;
using BHN.Domain.EGifts.Messages;
using BHN.Domain.EGifts.Services;
using BHN.Domain.Shared.Extensions;
using BHN.Infrastructure.Http.Shared;
using Enterprise.Framework.Services.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BHN.Infrastructure.Http.EGift.Services
{
    public class EGiftHttpService : IEGiftHttpService
    {
        private DadosBhn _dadosBhn;
        public EGiftHttpService(DadosBhn dadosBhn)
        {
            this._dadosBhn = dadosBhn;
        }

        public async Task<GenerateEGiftHashResponse> GerarHashEGift(GenerateEGiftHashRequest request)
        {
            var response = new GenerateEGiftHashResponse();

            using (var httpClient = HelperBHNHttpService.ObterHttpClientBhn(_dadosBhn))
            {
                var formData = new
                {
                    //giftFrom = "",
                    //giftTo = "",
                    //giftMessage = "",
                    //notes = "",
                    giftAmount = request.Preco,
                    //purchaserId = this._dadosBhn.VendedorId,
                    //recipientId = this._dadosBhn.VendedorId,
                    retrievalReferenceNumber = request.NumeroPedido,
                    productConfigurationId = request.ProductConfigutationId
                };

                var endpoint = httpClient.BaseAddress + this._dadosBhn.GerarHashRota;
                var bhnRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);
                bhnRequest.Headers.Add("requestId", request.RequisicaoId);
                
                if (request.TentativasAnteriores > 0)
                {
                    bhnRequest.Headers.Add("previousAttempts", request.TentativasAnteriores.ToString());
                }

                using (var content = new StringContent(JsonConvert.SerializeObject(formData), Encoding.UTF8, "application/json"))
                {
                    bhnRequest.Content = content;

                    var log_request = string.Format("{0} {1}", bhnRequest.ToString(), bhnRequest.Content.ReadAsStringAsync().Result);

                    var bhnResponse = await httpClient.SendAsync(bhnRequest);
                    var responseString = bhnResponse.ConvertToString();

                    var log_response = string.Format("{0} {1}", bhnResponse.ToString(), responseString);

                    response.AdicionarMensagemErro(TipoMensagem.Aplicacao, log_request);
                    response.AdicionarMensagemErro(TipoMensagem.Aplicacao, log_response);

                    if (bhnResponse.Valido())
                    {
                        var responseObject = JObject.Parse(responseString);                       
                        response.EntityId = responseObject["entityId"].ToString().ObterEntityId();
                        response.AccountId = responseObject["accountId"].ToString().ObterAccountId();
                        response.Status = responseObject["status"].ToString();
                        response.ActivationUrl = string.Format(this._dadosBhn.TemplateActivationSpot, response.EntityId);

                        return response;
                    }
                    else
                    {                       
                        var erro = JsonConvert.DeserializeObject<BHNErrorResponse>(responseString.TratarErrorResponse());
                        throw new BHNResponseException(bhnResponse.StatusCode, erro.ErrorCode, erro.Message);
                    }
                }
            }

        }

        public async Task<GenerateEGiftKeyResponse> GerarKeyEGift(GenerateEGiftKeyRequest request)
        {
            var response = new GenerateEGiftKeyResponse();
            
            using (var httpClient = HelperBHNHttpService.ObterHttpClientBhn(_dadosBhn))
            {                

                var endpoint = HelperBHNHttpService.ObterEndPoint(this._dadosBhn.GerarKeyRota, request.IdCliente);
                var bhnResponse = await httpClient.GetAsync(endpoint);
                var responseString = bhnResponse.ConvertToString();

                var log_response = string.Format("{0} {1}", bhnResponse.ToString(), responseString);
                response.AdicionarMensagemErro(TipoMensagem.Aplicacao, log_response);

                if (bhnResponse.Valido())
                {
                    var responseObject = JsonConvert.DeserializeObject<GerarKeyResponse>(responseString).Map();

                    response.AccountNumber = responseObject.AccountNumber;
                    response.ActivationAccountNumber = responseObject.ActivationAccountNumber;
                    response.BalanceResponse = responseObject.BalanceResponse;
                    response.EntityId = responseObject.EntityId.ObterAccountId();
                    response.SecurityCode = responseObject.SecurityCode;

                    return response;
                }
                else
                {
                    var erro = JsonConvert.DeserializeObject<BHNErrorResponse>(responseString.TratarErrorResponse());
                    throw new BHNResponseException(bhnResponse.StatusCode, erro.ErrorCode, erro.Message);
                }
            }            
        }
    
        public async Task<DesfazimentoEGiftResponse> DesfazimentoEGift(DesfazimentoEGiftRequest request)
        {
            var response = new DesfazimentoEGiftResponse();

            using (var httpClient = HelperBHNHttpService.ObterHttpClientBhn(_dadosBhn))
            {
                var formData = new
                {
                    reversalEGiftRequestId = request.RequisicaoId
                };

                var endpoint = httpClient.BaseAddress + this._dadosBhn.DesfazimentoRota;
                var bhnRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

                using (var content = new StringContent(JsonConvert.SerializeObject(formData), Encoding.UTF8, "application/json"))
                {
                    bhnRequest.Content = content;
                    var bhnResponse = await httpClient.SendAsync(bhnRequest);
                    var responseString = bhnResponse.ConvertToString();

                    if (bhnResponse.Valido())
                    {
                        var responseObject = JsonConvert.DeserializeObject<DesfazimentoEGiftResponse>(responseString);
                        return responseObject;
                    }
                    else
                    {                        
                        var erro = JsonConvert.DeserializeObject<BHNErrorResponse>(responseString.TratarErrorResponse());
                        throw new BHNResponseException(bhnResponse.StatusCode, erro.ErrorCode, erro.Message);
                    }
                }
            }
        }
    }
}