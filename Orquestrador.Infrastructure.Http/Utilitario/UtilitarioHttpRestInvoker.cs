using Newtonsoft.Json;
using Orquestrador.Domain.Utilitario.Messages;
using Orquestrador.Domain.Utilitario.Repositories;
using Orquestrador.Infrastructure.Http.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Infrastructure.Http.Utilitario
{
    public class UtilitarioHttpRestInvoker : IUtilitarioHttpRepository
    {
        private readonly DadosUtilitario _dadosUtilitario;

        public UtilitarioHttpRestInvoker(DadosUtilitario dados)
        {
            this._dadosUtilitario = dados;
        }

        public async Task<EnviarEmailResponse> EnviarEmailOffline(EnviarEmailRequest request)
        {
            var response = new EnviarEmailResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var enviarEmailUrl = this._dadosUtilitario.RotaEnviarEmailOffline;
                            
                httpClient.BaseAddress = new Uri(this._dadosUtilitario.HttpAddress);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var enviarEmailRequest = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress + enviarEmailUrl);
                enviarEmailRequest.Headers.TryAddWithoutValidation("Authorization", this._dadosUtilitario.Authorization);
                //enviarEmailRequest.Headers.Add("X-SecurityAccess", "External");

                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    enviarEmailRequest.Content = content;
                    var enviarEmailResponse = await httpClient.SendAsync(enviarEmailRequest);

                    var responseString = await enviarEmailResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<EnviarEmailResponse>(responseString);

                    return responseObject;
                }
            }
            
        }

        public async Task<ObterDadosConfiguracaoResponse> ObterDadosConfiguracao(ObterDadosConfiguracaoRequest request)
        {
            var response = new ObterDadosConfiguracaoResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var obterDadosConfiguracaoUrl = this._dadosUtilitario.RotaObterDadosConfiguracao;
                
                httpClient.BaseAddress = new Uri(this._dadosUtilitario.HttpAddress);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var obterConfiguracaoRequest = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + string.Format(obterDadosConfiguracaoUrl,request.Nome));
                obterConfiguracaoRequest.Headers.TryAddWithoutValidation("Authorization", this._dadosUtilitario.Authorization);
                //obterConfiguracaoRequest.Headers.Add("X-SecurityAccess", "External");

                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    obterConfiguracaoRequest.Content = content;
                    var obterConfiguracaoResponse = await httpClient.SendAsync(obterConfiguracaoRequest);

                    var responseString = await obterConfiguracaoResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ObterDadosConfiguracaoResponse>(responseString);

                    return responseObject;
                }
            }
        }

    }
}
