using BHN.Application.Catalog.Services;
using BHN.Domain.Catalog.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BHN.WebApi.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]         
        [Route("catalogo")]
        [ProducesResponseType(typeof(VersaoCatalogoResponse), 201)]
        public async Task<ActionResult> Get(VersaoCatalogoRequest request)
        {
            var response = await _service.VerificarVersao(request);
            return this.GetHttpResponse(response);
        }
    }
}