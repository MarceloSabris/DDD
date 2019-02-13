using BHN.Application.EGift.Messages;
using BHN.Application.EGift.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BHN.WebApi.Controllers
{
    public class EGiftController : Controller
    {
        private readonly IEGiftService _service;

        public EGiftController(IEGiftService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost] 
        [Route("egift")]
        [ProducesResponseType(typeof(GerarCompraResponse), 200)]
        public async Task<ActionResult> Post([FromBody] GerarCompraRequest request)
        {
            var response = await _service.GerarCodigo(request);
            return this.GetHttpResponse(response);
        }
    }
}