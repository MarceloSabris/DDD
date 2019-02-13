using Enterprise.Framework.Services.Messages;
using Orquestrador.Application.Impl.Parceiro.Mappers;
using Orquestrador.Application.Parceiro.Messages;
using Orquestrador.Application.Parceiro.Services;
using Orquestrador.Domain.Loja.Mappers;
using Orquestrador.Domain.Loja.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.Impl.Parceiro.Services
{
    public class PedidoParceiroService : IPedidoParceiroService
    {
        private readonly ILojaHttpRepository _lojaHttpRepository;
        public PedidoParceiroService(ILojaHttpRepository lojaHttpRepository)
        {
            this._lojaHttpRepository = lojaHttpRepository;
        }

        public async Task<ConsultarPedidosParceiroResponse> ConsultarPedidosParceiro(ConsultarPedidosParceiroRequest request)
        {
            var responsePedidos = new ConsultarPedidosParceiroResponse();
            try
            {
                var requestComprasParceiro = new Domain.Loja.Messages.ListarComprasParceiroRequest()
                {
                    IdCompra=request.IdCompra,
                    IdCompraEntregaSku=request.IdCompraEntregaSku,
                    IdProdutoParceiro=request.IdProdutoParceiro
                };

                var responseComprasParceiro = await this._lojaHttpRepository.ListarComprasParceiro(requestComprasParceiro);

                if (responseComprasParceiro.Valido && responseComprasParceiro.ComprasParceiro != null && responseComprasParceiro.ComprasParceiro.Any())
                {                    
                    responsePedidos.ComprasParceiro = responseComprasParceiro.ComprasParceiro.MapPedidos();
                }
                responsePedidos.Valido = true;
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

        public async Task<IntegrarPedidoParceiroResponse> IntegrarPedidoParceiro(IntegrarPedidoParceiroRequest request)
        {
            var responsePedidos = new IntegrarPedidoParceiroResponse();
            try
            {
                var responseAceite = await this._lojaHttpRepository.ListarComAceite(new Domain.Loja.Messages.ListarComprasComAceiteRequest());

                if (responseAceite.Valido && responseAceite.ComprasParceiro != null && responseAceite.ComprasParceiro.Any())
                {
                    var pedidos = responseAceite.ComprasParceiro.Map();

                    foreach (var pedido in pedidos)
                    {
                        var correlationId = Guid.NewGuid().ToString();

                        await pedido.IntegrarParceiro(correlationId);
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
