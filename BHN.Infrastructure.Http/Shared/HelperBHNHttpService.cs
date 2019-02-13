using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace BHN.Infrastructure.Http.Shared
{
    public static class HelperBHNHttpService
    {
        public static HttpClient ObterHttpClientBhn(DadosBhn dadosBhn)
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(CertificadoRequisicao.Obter(dadosBhn.CertificadoCaminho, dadosBhn.CertificadoSenha));

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(dadosBhn.UrlApi)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();

            // Proceed for an invalid cerficate
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            //specify to use TLS 1.2 as default connection
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            return httpClient;
        }

        public static bool Valido(this HttpResponseMessage responseMessage, params HttpStatusCode[] statusArray)
        {
            var statusList = statusArray.ToList();
            if (!statusList.Any()) statusList = new List<HttpStatusCode>() { HttpStatusCode.OK };

            return statusList.Any(status => status == responseMessage.StatusCode);
        }

        public static string ConvertToString(this HttpResponseMessage responseMessage)
        {
            return responseMessage.Content.ReadAsStringAsync().Result;
        }

        public static string ObterEndPoint(string templateRota, params object[] parametros)
        {
            return string.Format(templateRota, parametros);
        }

        public static string TratarErrorResponse(this string response)
        {
            if (response.StartsWith("[") && response.EndsWith("]"))
            {
                response = response.Substring(1, response.Length - 2);
            }

            return response;
        }
    }
}