using Newtonsoft.Json;
using Orquestrador.Domain.Parceiro.Messages;
using Orquestrador.Domain.Parceiro.Repositories;
using Orquestrador.Infrastructure.Http.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Infrastructure.Http.Parceiro
{
    public class BlackhawkHttpRestInvoker : IParceiroHttpRepository
    {
        private readonly DadosBhn _dadosBhn;

        public BlackhawkHttpRestInvoker(DadosBhn dadosBhn)
        {
            this._dadosBhn = dadosBhn;
        }

        public async Task<GerarCodigoResponse> GerarCodigo(GerarCodigoRequest request)
        {
            var response = new GerarCodigoResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var gerarEGiftUrl = this._dadosBhn.RotaGerarEGift;

                httpClient.BaseAddress = new Uri(this._dadosBhn.HttpAddress);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var gerarEGiftRequest = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress + gerarEGiftUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    gerarEGiftRequest.Content = content;
                    var gerarEGiftResponse = await httpClient.SendAsync(gerarEGiftRequest);

                    var responseString = await gerarEGiftResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<GerarCodigoResponse>(responseString);

                    return responseObject;
                }
            }
        }
    }
}
