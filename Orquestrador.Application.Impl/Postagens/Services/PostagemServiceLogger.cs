using Orquestrador.Application.Postagens.Loggers;
using Orquestrador.Application.Postagens.Messages;
using Orquestrador.Application.Postagens.Services;
using System.Threading.Tasks;

namespace Orquestrador.Application.Impl.Postagens.Services
{
    public class PostagemServiceLogger : IPostagemService
    {
        private readonly IPostagemLogger _logger;
        private readonly IPostagemService _service;

        public PostagemServiceLogger(IPostagemLogger logger,
                                     IPostagemService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<GerarCodigoResponse> GerarCodigo(GerarCodigoRequest request)
        {
            _logger.Log("Iniciando Gerar Código Postagem", request);
            GerarCodigoResponse response = await _service.GerarCodigo(request);
            _logger.Log("Iniciando Gerar Código Postagem", request, response);
            return response;
        }
    }
}
