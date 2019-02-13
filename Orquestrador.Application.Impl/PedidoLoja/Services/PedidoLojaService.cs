using Enterprise.Framework.Services.Messages;
using Orquestrador.Application.PedidoLoja.Messages;
using Orquestrador.Application.PedidoLoja.Services;
using Orquestrador.Domain.Loja.Mappers;
using Orquestrador.Domain.Loja.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.Impl.PedidoLoja.Services
{
    public class PedidoLojaService : IPedidoLojaService
    {
        private readonly ILojaHttpRepository _lojaHttpRepository;
        public PedidoLojaService(ILojaHttpRepository lojaHttpRepository)
        {
            this._lojaHttpRepository = lojaHttpRepository;
        }

        public async Task<EnfileirarPedidosResponse> EnfileirarPedidos(EnfileirarPedidosRequest request)
        {
            var responsePedidos = new EnfileirarPedidosResponse();
            try
            {
                var responseElegiveis = await this._lojaHttpRepository.ObterElegiveis(new Domain.Loja.Messages.ObterCompraElegivelRequest());

                if (responseElegiveis.Valido && responseElegiveis.ComprasElegives != null && responseElegiveis.ComprasElegives.Any())
                {
                    var pedidos = responseElegiveis.ComprasElegives.Map();

                    foreach (var pedido in pedidos)
                    {
                        var correlationId = Guid.NewGuid().ToString();

                        await pedido.Enfileirar(correlationId);
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
