

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Loja.WebApi;
using Loja.Application.Ativacao.Services;
using Loja.Application.Ativacao.Messages;

namespace Loja.WebApi.Controllers
{
    public class CompraAtivacaoController : Controller
    {
        private readonly IAtivacaoService _service;

        public CompraAtivacaoController(IAtivacaoService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("compraativacao")]
        [ProducesResponseType(typeof(ListarComprasComAtivacaoResponse), 200)]
        public async Task<ActionResult> Get([FromQuery]ListarComprasComAtivacaoRequest request)
        {
            var response = await _service.ListarComAtivacao(request);
            return this.GetHttpResponse(response);
        }

        [HttpPut]
        [Route("compraativacao")]
        [ProducesResponseType(typeof(AlterarStatusAtivacaoResponse), 201)]
        public async Task<ActionResult> Put([FromBody]AlterarStatusAtivacaoRequest request)
        {
            var response = await _service.AlterarStatusAtivacao(request);
            return this.GetHttpResponse(response);
        }
    }
}