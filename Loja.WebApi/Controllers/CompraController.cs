using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Compras.Messages;
using Loja.Application.Compras.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebApi.Controllers
{
   
    public class CompraController : Controller
    {
        private readonly ICompraService _service;

        public CompraController(ICompraService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("compra")]
        [ProducesResponseType(typeof(ObterCompraElegivelResponse), 200)]
        public async Task<ActionResult> ObterComprasElegiveis([FromQuery]ObterCompraElegivelRequest request)
        {
            var response = await _service.ObterComprasElegiveis(request);
            return this.GetHttpResponse(response);
        }
    }
}