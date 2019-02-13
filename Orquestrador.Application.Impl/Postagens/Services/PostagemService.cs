using Orquestrador.Application.Impl.Postagens.Mappers;
using Orquestrador.Application.Postagens.Factories;
using Orquestrador.Application.Postagens.Messages;
using Orquestrador.Application.Postagens.Services;
using Orquestrador.Common;
using Orquestrador.Domain.Postagens.Models;
using Enterprise.Framework.Domain.BusinessResults;
using Enterprise.Framework.Services.Messages;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Orquestrador.Application.Impl.Postagens.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IPostagemFactory _postagemFactory;
        private readonly IPostagemServiceValidator _validator;
        public PostagemService(IPostagemFactory postagemFactory,
                               IPostagemServiceValidator validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _postagemFactory = postagemFactory ?? throw new ArgumentNullException(nameof(postagemFactory));
        }

        public async Task<GerarCodigoResponse> GerarCodigo(GerarCodigoRequest request)
        {
            GerarCodigoResponse response = new GerarCodigoResponse();
            try
            {
                ValidationResult validationResult = request.Validate();
                if (!validationResult.IsValid)
                {
                    response.Valido = false;
                    foreach (ValidationFailure failure in validationResult.Errors)
                        response.AdicionarMensagemErro(TipoMensagem.Validacao, failure.ErrorMessage);
                }
                else
                {
                    string correlationId = request.GetHeader(Const.CorrelationID);
                    PostagemId postagemId = request.Map();
                    Postagem postagem = await _postagemFactory.Gerar(postagemId, correlationId);

                    await postagem.CancelarCodigoExistente(correlationId);
                    BusinessResult result = await postagem.CriarCodigo(correlationId);
                    if (!result.Valido)
                    {
                        response.Valido = result.Valido;
                        response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, result.Mensagens.First().Conteudo);
                    }
                    else
                    {
                        await postagem.AtualizarCodigo(correlationId);
                        response.Postagem = postagem;
                    }
                }
            }
            catch (ApplicationException appEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }
    }
}