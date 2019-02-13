using BHN.Application.Catalog.Services;
using BHN.Application.Produto.Services;
using BHN.Domain.Catalog.Messages;
using BHN.Domain.Catalog.Services.Contracts;
using BHN.Domain.ProdutosBHN.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BHN.WebApi.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;
        private readonly ICatalogService _catalogService;

        public ProdutoController(IProdutoService service, ICatalogService catalogService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        [HttpGet]
        [Route("produto")]
        [ProducesResponseType(typeof(ObterDetalhesProdutoResponse), 200)]
        public async Task<ActionResult> Get(ObterDetalhesProdutoRequest request)
        {
            var response = await _service.DetalhesProduto(request);
            return this.GetHttpResponse(response);
        }

        [HttpGet]
        [Route("produtos")]
        [ProducesResponseType(typeof(ObterCatalogoResponse), 200)]
        public async Task<ActionResult> Get(ObterCatalogoRequest request)
        {
            var response = await _catalogService.ObterCatalogo(request);
            return this.GetHttpResponse(response);
        }
    }
}