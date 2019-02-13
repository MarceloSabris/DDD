using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Loja.Application.ComprasParceiro.Messages;
using Loja.Application.ComprasParceiro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebApi.Controllers
{
    
    public class CompraParceiroController : Controller
    {
        private readonly ICompraParceiroService _service;

        public CompraParceiroController(ICompraParceiroService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("compraparceiro")]
        [ProducesResponseType(typeof(ListarCompraResponse), 200)]
        public async Task<ActionResult> Get([FromQuery]ListarComprasRequest request)
        {
            var response = await _service.Listar(request);
            return this.GetHttpResponse(response);
        }

        [HttpPost]
        [Route("compraparceiro")]
        [ProducesResponseType(typeof(InserirCompraResponse), 200)]
        public async Task<ActionResult> Post([FromBody]InserirCompraRequest request)
        {
            var response = await _service.InserirCompraParceiro(request);
            return this.GetHttpResponse(response);
        }


		[HttpPut]
		[Route("compraparceiro")]
		[ProducesResponseType(typeof(AlterarStatusParceiroResponse), 201)]
		public async Task<ActionResult> Put([FromBody]AlterarStatusParceiroRequest request)
		{
			var response = await _service.AlterarStatusParceiro(request);
			return this.GetHttpResponse(response);
		}


		
	}
}