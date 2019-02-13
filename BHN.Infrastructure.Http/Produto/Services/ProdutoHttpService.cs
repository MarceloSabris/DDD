using BHN.Domain.EGifts.Messages;
using BHN.Domain.ProdutosBHN.Messages;
using BHN.Domain.ProdutosBHN.Services.Contracts;
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

namespace BHN.Infrastructure.Http.Produto.Services
{
    public class ProdutoHttpService : IProdutoHttpService
    {
        private DadosBhn _dadosBhn;

        public ProdutoHttpService(DadosBhn dadosBhn)
        {
            _dadosBhn = dadosBhn;
        }

        public async Task<ObterDetalhesProdutoResponse> DetalhesProduto(ObterDetalhesProdutoRequest request)
        {
            var response = new ObterDetalhesProdutoResponse()
            {
                Configuracoes = new List<ConfiguracaoProdutoResponse>()
            };

            using (var httpClient = HelperBHNHttpService.ObterHttpClientBhn(_dadosBhn))
            {
                var endpoint = HelperBHNHttpService.ObterEndPoint(this._dadosBhn.DetalhesProdutoRota, request.IdProduto);

                var bhnResponse = await httpClient.GetAsync(endpoint);
                var responseString = bhnResponse.ConvertToString();
                if (bhnResponse.Valido())
                {
                    JObject bhnObjectResponse = JObject.Parse(responseString);

                    response.IdProduto = bhnObjectResponse["entityId"].ToString().ObterEntityId();
                    response.Nome = bhnObjectResponse["summary"]["productName"].ToString();
                    response.Preco = Convert.ToDecimal(bhnObjectResponse["details"]["activationCharacteristics"]["baseValueAmount"].ToString());
                    response.PrecoMaximo = Convert.ToDecimal(bhnObjectResponse["details"]["activationCharacteristics"]["maxValueAmount"].ToString());
                    response.ConfiguracaoPadrao = bhnObjectResponse["details"]["defaultProductConfigurationId"].ToString();

                    var configurations = bhnObjectResponse["details"]["productConfigurations"].Children().ToList();
                    foreach (JToken config in configurations)
                    {
                        response.Configuracoes.Add(new ConfiguracaoProdutoResponse()
                        {
                            Id = config["configurationId"].ToString(),
                            Nome = config["configurationName"].ToString()
                        });
                    }
                }
                else
                {
                    var erro = JsonConvert.DeserializeObject<BHNErrorResponse>(responseString.TratarErrorResponse());
                    throw new BHNResponseException(bhnResponse.StatusCode, erro.ErrorCode, erro.Message);
                }
            }
            return response;
        }
    }
}
