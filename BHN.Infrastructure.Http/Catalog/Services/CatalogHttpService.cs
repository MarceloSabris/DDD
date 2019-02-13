using BHN.Domain.Catalog.Messages;
using BHN.Domain.Catalog.Services.Contracts;
using BHN.Domain.EGifts.Messages;
using BHN.Domain.Shared.Extensions;
using BHN.Infrastructure.Http.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BHN.Infrastructure.Http.Catalog.Services
{
    public class CatalogHttpService : ICatalogHttpService
    {
        private readonly DadosBhn _dadosBhn;

        public CatalogHttpService(DadosBhn dadosBhn)
        {
            _dadosBhn = dadosBhn;
        }

        public async Task<ObterCatalogoResponse> ObterCatalogo(ObterCatalogoRequest request)
        {
            var response = new ObterCatalogoResponse()
            {
                DadosCatalogo = new DadosCatalogoResponse(),
                IdProdutos = new List<string>()
            };
            
            using (var httpClient = HelperBHNHttpService.ObterHttpClientBhn(_dadosBhn))
            {
                var endpoint = HelperBHNHttpService.ObterEndPoint(this._dadosBhn.DetalhesCatalogoRota, request.IdCatalogo);
                var bhnResponse = await httpClient.GetAsync(endpoint);
                var responseString = bhnResponse.ConvertToString();

                if (bhnResponse.Valido())
                {
                    JObject bhnObjectResponse = JObject.Parse(responseString);
                    response.DadosCatalogo = new DadosCatalogoResponse()
                    {
                        IdCatalogo = bhnObjectResponse["summary"]["entityId"].ToString().ObterEntityId(),
                        Nome = bhnObjectResponse["summary"]["name"].ToString(),
                        Versao = bhnObjectResponse["summary"]["version"].ToString(),
                    };
                    var details = bhnObjectResponse["details"]["productIds"].Children().Select(s => s.ToString().ObterEntityId()).ToList();
                    response.IdProdutos = details;
                }
                else
                {                    
                    var erro = JsonConvert.DeserializeObject<BHNErrorResponse>(responseString.TratarErrorResponse());
                    throw new BHNResponseException(bhnResponse.StatusCode, erro.ErrorCode, erro.Message);
                }
            }

            return response;
        }

        public async Task<VersaoCatalogoResponse> VerificarVersao(VersaoCatalogoRequest request)
        {
            var response = new VersaoCatalogoResponse()
            {
                Catalogos = new List<DadosCatalogoResponse>()
            };

            using (var httpClient = HelperBHNHttpService.ObterHttpClientBhn(_dadosBhn))
            {
                var endpoint = this._dadosBhn.VersaoCatalogoRota;
                var bhnResponse = await httpClient.GetAsync(endpoint);
                var responseString = bhnResponse.ConvertToString();

                if (bhnResponse.Valido())
                {
                    JObject bhnObjectResponse = JObject.Parse(responseString);
                    var results = bhnObjectResponse["results"].Children().ToList();

                    foreach (JToken result in results)
                    {
                        response.Catalogos.Add(new DadosCatalogoResponse()
                        {
                            IdCatalogo = result["entityId"].ToString().ObterEntityId(),
                            Nome = result["name"].ToString(),
                            Versao = result["version"].ToString(),
                        });
                    }

                    response.Total = response.Catalogos.Count;

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
}