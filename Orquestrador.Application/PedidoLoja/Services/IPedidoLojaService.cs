using Orquestrador.Application.PedidoLoja.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.PedidoLoja.Services
{
    public interface IPedidoLojaService
    {
        Task<EnfileirarPedidosResponse> EnfileirarPedidos(EnfileirarPedidosRequest request);
    }
}
