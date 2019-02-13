using Orquestrador.Application.IntegracaoERP.Messages;
using Orquestrador.Application.IntegracaoERP.Services;
using Orquestrador.Domain.Loja.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orquestrador.Domain.Loja.Mappers;
using Enterprise.Framework.Services.Messages;

namespace Orquestrador.Application.Impl.IntegracaoERP.Services
{
    public class PedidoERPService : IPedidoERPService
    {
        private readonly ILojaHttpRepository _lojaHttpRepository;
        public PedidoERPService(ILojaHttpRepository lojaHttpRepository)
        {
            this._lojaHttpRepository = lojaHttpRepository;
        }

        public async Task<IntegrarPedidoERPResponse> IntegrarPedidosERP(IntegrarPedidoERPRequest request)
        {
            var responsePedidos = new IntegrarPedidoERPResponse();
            try
            {
                var responseErp = await this._lojaHttpRepository.ListarComprasERP(new Domain.Loja.Messages.ListarComprasERPRequest());

                if (responseErp.Valido && responseErp.ComprasERP != null && responseErp.ComprasERP.Any())
                {
                    var pedidos = responseErp.ComprasERP.Map();

                    foreach (var pedido in pedidos)
                    {
                        var correlationId = Guid.NewGuid().ToString();

                        await pedido.IntegrarERP(correlationId);
                    }

                    responsePedidos.Valido = true;

                }
            }
            catch (ApplicationException appEx)
            {
                responsePedidos.Valido = false;
                responsePedidos.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                responsePedidos.Valido = false;
                responsePedidos.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return responsePedidos;
        }
    }
}
