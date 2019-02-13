using Enterprise.Framework.Services.Messages;
using ItemVirtualWS;
using Orquestrador.Domain.Erp.Messages;
using Orquestrador.Domain.Erp.Repositories;
using Orquestrador.Infrastructure.Http.Shared;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Infrastructure.Http.Erp
{
    public class ErpHttpSoapInvoker : IErpHttpRepository
    {        
        private readonly DadosErp _dadosErp;

        public ErpHttpSoapInvoker(DadosErp dadosErp)
        {
            this._dadosErp = dadosErp;
        }


       
        public async Task<EnviarItemVirtualResponse> EnviarItemVirtual(EnviarItemVirtualRequest request)
        {
            var response = new EnviarItemVirtualResponse();
            try
            {
                var binding = new System.ServiceModel.BasicHttpBinding();
                binding.MaxBufferSize = int.MaxValue;
                binding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                binding.MaxReceivedMessageSize = int.MaxValue;
                binding.AllowCookies = true;

                var endpointAddress = new EndpointAddress(_dadosErp.EndpointErp + _dadosErp.RotaItemVirtual);

                var clientWs = new ItemVirtualClient(binding, endpointAddress);
                
                var responseWs = await clientWs.IncluirIVEAsync(new ItemVirtualEntradaDTO()
                {
                    GerencialId=request.ItemVirtual.GerencialId,
                    IdUnidadeNegocio=request.ItemVirtual.IdUnidadeNegocio,
                    Sequencial=request.ItemVirtual.Sequencial,
                    Usuario=request.ItemVirtual.Usuario
                });

                if (responseWs.Mensagens != null && responseWs.Mensagens.Length > 0)
                {
                    foreach(var msg in responseWs.Mensagens)
                        response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, msg);
                }

                response.Valido = !responseWs.Erro;
            }
            catch(Exception ex)
            {
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.Message);
                response.Valido = false;
            }

            return response;
        }
    }
}
