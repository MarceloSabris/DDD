

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Loja.WebApi;
using Loja.Application.TermoAceite.Messages;
using Loja.Application.TermoAceite.Services.Contracts;

namespace Loja.WebApi.Controllers
{
    public class CompraTermoAceiteController : Controller
    {
        private readonly IAceiteService _service;

        public CompraTermoAceiteController(IAceiteService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPut]
        [Route("compratermoaceite")]
        [ProducesResponseType(typeof(StatusAceiteResponse), 200)]
        public async Task<ActionResult> Put([FromBody]StatusAceiteRequest request)
        {
            request.ProcessRequest(Request, HttpContext);

           var response = await _service.AlterarStatusAceite(request);
            return this.GetHttpResponse(response);
        }

        [HttpGet]
        [Route("compratermoaceite")]
        [ProducesResponseType(typeof(ListarCompraComAceiteResponse), 200)]
        public async Task<ActionResult> Get([FromQuery]ListarComprasComAceiteRequest request)
        {
            var response = await _service.ListarComAceite(request);
            return this.GetHttpResponse(response);
        }
    }
}