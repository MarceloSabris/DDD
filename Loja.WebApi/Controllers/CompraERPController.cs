using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.ComprasERP.Messages;
using Loja.Application.ComprasERP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebApi.Controllers
{
    public class CompraERPController : Controller
    {
        private readonly ICompraERPService _service;

        public CompraERPController(ICompraERPService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("compraerp")]
        [ProducesResponseType(typeof(ListaComprasERPResponse), 200)]
        public async Task<ActionResult> Get()
        {
            var response = await _service.ListarAsync();
            return this.GetHttpResponse(response);
        }

        [HttpPut]
        [Route("compraerp")]
        [ProducesResponseType(typeof(AlterarStatusERPResponse), 201)]
        public async Task<ActionResult> Put([FromBody]AlterarStatusERPRequest request)
        {
            var response = await _service.AlterarStatusERPAsync(request);
            return this.GetHttpResponse(response);
        }
    }
}
