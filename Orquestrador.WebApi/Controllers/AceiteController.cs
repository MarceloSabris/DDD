using Orquestrador.Application.Postagens.Messages;
using Orquestrador.Application.Postagens.Services;
using Orquestrador.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Orquestrador.Application.Postagens.Services.Contracts;

namespace Orquestrador.WebApi.Controllers
{
    public class AceiteControler : Controller
    {
        private readonly IAceiteService _service;

        public AceiteControler(IAceiteService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Route("postagem")]
        [ProducesResponseType(typeof(AlterarStatusResponse), 200)]
        public async Task<ActionResult> Post([FromBody]StatusAceiteRequest request)
        {
            request.ProcessRequest(Request, HttpContext);

           var response = await _service.AlterarStatusAceite(request);
            return this.GetHttpResponse(response);
        }
    }
}