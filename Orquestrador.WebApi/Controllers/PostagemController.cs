namespace Orquestrador.WebApi.Controllers
{
    //public class PostagemController : Controller
    //{
    //    private readonly IPostagemService _service;

    //    public PostagemController(IPostagemService service)
    //    {
    //        _service = service ?? throw new ArgumentNullException(nameof(service));
    //    }

    //    [HttpPost]
    //    [Route("postagem")]
    //    [ProducesResponseType(typeof(GerarCodigoResponse), 200)]
    //    public async Task<ActionResult> Post([FromBody]GerarCodigoRequest request)
    //    {
    //        request.ProcessRequest(Request, HttpContext);

    //        var response = await _service.GerarCodigo(request);
    //        return this.GetHttpResponse(response);
    //    }
    //}
}