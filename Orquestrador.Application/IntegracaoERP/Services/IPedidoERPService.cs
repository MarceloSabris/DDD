using Orquestrador.Application.IntegracaoERP.Messages;
using Orquestrador.Application.Parceiro.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.IntegracaoERP.Services
{
    public interface IPedidoERPService
    {
		 Task<IntegrarPedidoERPResponse> IntegrarPedidosERP(IntegrarPedidoERPRequest request); 

    }
}
