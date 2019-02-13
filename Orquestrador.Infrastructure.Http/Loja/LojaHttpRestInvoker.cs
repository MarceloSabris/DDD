using Newtonsoft.Json;
using Orquestrador.Domain.Loja.Messages;
using Orquestrador.Domain.Loja.Repositories;
using Orquestrador.Infrastructure.Http.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Infrastructure.Http.Loja
{
    public class LojaHttpRestInvoker : ILojaHttpRepository
    {
        private readonly DadosLoja _dadosLoja;

        public LojaHttpRestInvoker(DadosLoja dados)
        {
            this._dadosLoja = dados;
        }

        public async Task<AlterarStatusParceiroResponse> AlterarStatusParceiro(AlterarStatusParceiroRequest request)
        {

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var alterarStatusParceiroUrl = this._dadosLoja.RotaAlterarStatusParceiro;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var alterarStatusParceiroRequest = new HttpRequestMessage(HttpMethod.Put, httpClient.BaseAddress + alterarStatusParceiroUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    alterarStatusParceiroRequest.Content = content;
                    var alterarStatusParceiroResponse = await httpClient.SendAsync(alterarStatusParceiroRequest);

                    var responseString = await alterarStatusParceiroResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<AlterarStatusParceiroResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<AlterarStatusAtivacaoResponse> AlterarStatusAtivacao(AlterarStatusAtivacaoRequest request)
        {
            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var alterarStatusAtivacaoUrl = this._dadosLoja.RotaAlterarStatusAtivacao;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var alterarStatusAtivacaoRequest = new HttpRequestMessage(HttpMethod.Put, httpClient.BaseAddress + alterarStatusAtivacaoUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    alterarStatusAtivacaoRequest.Content = content;
                    var alterarStatusAtivacaoResponse = await httpClient.SendAsync(alterarStatusAtivacaoRequest);

                    var responseString = await alterarStatusAtivacaoResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<AlterarStatusAtivacaoResponse>(responseString);

                    return responseObject;
                }
            }
        }

        

        public async Task<InserirCompraParceiroResponse> InserirCompraParceiro(InserirCompraParceiroRequest request)
        {
            var response = new InserirCompraParceiroResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var inserirCompraParceiroUrl = this._dadosLoja.RotaInserirCompraParceiro;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var inserirCompraParceiroRequest = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress + inserirCompraParceiroUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    inserirCompraParceiroRequest.Content = content;
                    var inserirCompraParceiroResponse = await httpClient.SendAsync(inserirCompraParceiroRequest);

                    var responseString = await inserirCompraParceiroResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<InserirCompraParceiroResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<ListarCompraComAceiteResponse> ListarComAceite(ListarComprasComAceiteRequest request)
        {
            var response = new ListarCompraComAceiteResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var listarComAceiteUrl = this._dadosLoja.RotaListarComAceite;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var listarComAceiteRequest = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + listarComAceiteUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    listarComAceiteRequest.Content = content;
                    var listarComAceiteResponse = await httpClient.SendAsync(listarComAceiteRequest);

                    var responseString = await listarComAceiteResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ListarCompraComAceiteResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<ListarComAtivacaoResponse> ListarComAtivacao(ListarComAtivacaoRequest request)
        {
            var response = new ListarComAtivacaoResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var listarComAtivacaoUrl = this._dadosLoja.RotaListarComAtivacao;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var listarComAtivacaoRequest = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + listarComAtivacaoUrl);
                

                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    listarComAtivacaoRequest.Content = content;
                    var listarComAtivacaoResponse = await httpClient.SendAsync(listarComAtivacaoRequest);

                    var responseString = await listarComAtivacaoResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ListarComAtivacaoResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<ObterCompraElegivelResponse> ObterElegiveis(ObterCompraElegivelRequest request)
        {
            var response = new ObterCompraElegivelResponse();

            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var obterElegiveisUrl = this._dadosLoja.RotaObterElegiveis;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var obterElegiveisRequest = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + obterElegiveisUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    obterElegiveisRequest.Content = content;
                    var obterElegiveisResponse = await httpClient.SendAsync(obterElegiveisRequest);

                    var responseString = await obterElegiveisResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ObterCompraElegivelResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<ListarComprasParceiroResponse> ListarComprasParceiro(ListarComprasParceiroRequest request)
        {
            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(CertificadoRequisicao.Obter(this._dadosBhn.Certificado));

            using (var httpClient = new HttpClient(handler))
            {
                var listarUrl = this._dadosLoja.RotaListarCompraParceiro;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var listarUrlComParametros = string.Format(listarUrl, request.IdCompra, request.IdCompraEntregaSku, request.IdProdutoParceiro);

                var listarRequest = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + listarUrlComParametros);

                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    listarRequest.Content = content;
                    var listarResponse = await httpClient.SendAsync(listarRequest);

                    var responseString = await listarResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ListarComprasParceiroResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<AlterarStatusERPResponse> AlterarStatusERP(AlterarStatusERPRequest request)
        {
            var handler = new HttpClientHandler();
            

            using (var httpClient = new HttpClient(handler))
            {
                var alterarStatusERPUrl = this._dadosLoja.RotaAlterarStatusERP;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var alterarStatusERPRequest = new HttpRequestMessage(HttpMethod.Put, httpClient.BaseAddress + alterarStatusERPUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    alterarStatusERPRequest.Content = content;
                    var alterarStatusERPResponse = await httpClient.SendAsync(alterarStatusERPRequest);

                    var responseString = await alterarStatusERPResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<AlterarStatusERPResponse>(responseString);

                    return responseObject;
                }
            }
        }

        public async Task<ListarComprasERPResponse> ListarComprasERP(ListarComprasERPRequest request)
        {
            var handler = new HttpClientHandler();
            

            using (var httpClient = new HttpClient(handler))
            {
                var listarComprasERPUrl = this._dadosLoja.RotaListarComprasERP;

                httpClient.BaseAddress = new Uri(this._dadosLoja.ApiLojaAddressHost);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                var listarComprasERPRequest = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress + listarComprasERPUrl);


                using (var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
                {
                    listarComprasERPRequest.Content = content;
                    var listarComprasERPResponse = await httpClient.SendAsync(listarComprasERPRequest);

                    var responseString = await listarComprasERPResponse.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<ListarComprasERPResponse>(responseString);

                    return responseObject;
                }
            }
        }
    }
}
