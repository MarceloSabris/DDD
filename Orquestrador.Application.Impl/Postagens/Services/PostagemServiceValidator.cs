using Orquestrador.Application.Postagens.Messages;
using Orquestrador.Application.Postagens.Services;
using Orquestrador.Domain.Shared.CodeMessages.Repositories;
using System;
using System.Threading.Tasks;
using static Orquestrador.Application.Utils.ResponseUtil;

namespace Orquestrador.Application.Impl.Postagens.Services
{
    public class PostagemServiceValidator : IPostagemServiceValidator
    {
        private readonly ICodeMessageRepository _repository;
        public PostagemServiceValidator(ICodeMessageRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<GerarCodigoResponse> ValidateAsync(GerarCodigoRequest request)
        {
            var response = new GerarCodigoResponse();

            if (request == null)
                return GetRequestIsNullResponse<GerarCodigoResponse>();

            var validation = request.Validate();
            if (!validation.IsValid)
            {
                var codeMessages = await _repository.ListarAsync(validation);
                response = GetInvalidRequestResponse<GerarCodigoResponse>(codeMessages);
            }

            return response;
        }
    }
}
