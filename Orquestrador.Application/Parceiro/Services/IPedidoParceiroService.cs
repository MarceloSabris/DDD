using Orquestrador.Application.Parceiro.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.Parceiro.Services
{
    public interface IPedidoParceiroService
    {
        Task<IntegrarPedidoParceiroResponse> IntegrarPedidoParceiro(IntegrarPedidoParceiroRequest request);

        Task<ConsultarPedidosParceiroResponse> ConsultarPedidosParceiro(ConsultarPedidosParceiroRequest request);
    }
}
