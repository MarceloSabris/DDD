using Microsoft.AspNetCore.Mvc;
using Orquestrador.Application.Parceiro.Messages;
using Orquestrador.Application.Parceiro.Services;
using System;
using System.Threading.Tasks;

namespace Orquestrador.WebApi.Controllers
{
    public class PedidoParceiroController : Controller
    {
        private readonly IPedidoParceiroService _service;

        public PedidoParceiroController(IPedidoParceiroService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("pedidoparceiro")]
        [ProducesResponseType(typeof(ConsultarPedidosParceiroResponse), 200)]
        public async Task<ActionResult> Get([FromQuery]ConsultarPedidosParceiroRequest request)
        {
            var response = await _service.ConsultarPedidosParceiro(request);
            return this.GetHttpResponse(response);
        }
    }
}