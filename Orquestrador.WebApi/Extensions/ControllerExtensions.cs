using Orquestrador.Application.Utils;
using Orquestrador.Common;
using Enterprise.Framework.Services.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Orquestrador.WebApi
{
    public static class ControllerExtensions
    {
        public static ActionResult GetHttpResponse(this Controller controller, BaseResponse response)
        {
            if (response == null)
                return controller.BadRequest(response);

            if (!response.Valido)
            {
                if (!response.Mensagens.Any())
                {
                    return controller.BadRequest(response);
                }

                if (response.Mensagens.Any(m => m.Tipo == TipoMensagem.ErroValidacao || m.Tipo == TipoMensagem.Validacao))
                {
                    return controller.BadRequest(response);
                }

                if (response.Mensagens.Any(m => m.Tipo == TipoMensagem.ErroNegocio || m.Tipo == TipoMensagem.Negocio))
                {
                    return controller.Conflict(response);
                }

                if (response.Mensagens.Any(m => m.Tipo == TipoMensagem.ErroAplicacao || m.Tipo == TipoMensagem.Aplicacao))
                {
                    return controller.BadRequest(response);
                }
            }

            // Usar o id de correlação gerado pelo CorrelationIdMiddleware
            if (Guid.TryParse(controller.HttpContext.TraceIdentifier, out Guid guid))
            {
                response.Protocolo = guid;
            }

            return controller.Ok(response);
        }

        public static ActionResult Conflict(this Controller controller, BaseResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status409Conflict
            };
        }

        public static void ProcessRequest(this BaseOrquestradorRequest request, HttpRequest http, HttpContext context)
        {
            request.Protocolo = http.Headers[Const.Protocolo].ToString() == "" ? "Sem Protocolo" : http.Headers[Const.Protocolo].ToString();
            request.Funcionario = http.Headers[Const.Funcionario].ToString() == "" ? "Sem Funcionário" : http.Headers[Const.Funcionario].ToString();
            request.CorrelationId = new Guid(context.TraceIdentifier);
        }
    }
}
