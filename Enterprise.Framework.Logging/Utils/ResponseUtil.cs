
using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;

namespace Enterprise.Framework.Logging.Utils
{
    public class ResponseUtil : IResponseUtil
    {
        private readonly ILoggerService _loggerService;

        public ResponseUtil(ILoggerService loggerService)
        {
            this._loggerService = loggerService;
        }
        /// <summary>
        /// Get request is null with related messages.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <returns>Response.</returns>
        public  T GetRequestIsNullResponse<T>() where T : BaseResponse, new()
        {
            var respone = new T
            {
                Valido = false,
                Mensagens = new List<Mensagem>
                {
                    new Mensagem(CodeMessageConstants.StatusCode.BadRequest, "O 'request' é inválido!", TipoMensagem.Validacao)
                }
            };
            return respone;
        }

        /// <summary>
        /// Get error message.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <param name="ex">Exception object.</param>
        /// <returns>Response.</returns>
        public  T GetResponseError<T>(Exception ex) where T : BaseResponse, new() => GetResponseError<T>(null, ex);

        /// <summary>
        /// Get error message.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <param name="message">Info message.</param>
        /// <param name="ex">Exception object.</param>
        /// <returns>Response.</returns>
        public  T GetResponseError<T>(object caller, Exception ex) where T : BaseResponse, new()
        {
            var exception = ex.InnerException ?? ex;
            var message=string.Empty;

            if (exception != null)
            {
                if (!string.IsNullOrWhiteSpace(message))
                    message = $"{message}. {exception.Message}";
                else
                    message = exception.Message;
            }

            if (_loggerService != null)
            {
                var entity = (caller != null ? caller.GetType().FullName : string.Empty);
                var description = (caller != null ? caller.GetType().Name : string.Empty);
               _loggerService.LogError(message, entity, description, ex);
            }

            return new T
            {
                Valido = false,
                Mensagens = new List<Mensagem>
                {
                    new Mensagem(CodeMessageConstants.StatusCode.InternalServerError, message, TipoMensagem.ErroAplicacao)
                }
            };
        }

        /// <summary>
        /// Get invalid request response.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <param name="codeMessage">The code message.</param>
        /// <returns>Response.</returns>
        public  T GetInvalidRequestResponse<T>(CodeMessage codeMessage) where T : BaseResponse, new()
        {
            var respone = new T
            {
                Valido = false,
                Mensagens = new List<Mensagem>
                {
                    new Mensagem(codeMessage.Code, codeMessage.Message, TipoMensagem.Validacao)
                }
            };
            return respone;
        }

        /// <summary>
        /// Get invalid request response.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <param name="codeMessages">The code messages.</param>
        /// <returns>Response.</returns>
        public  T GetInvalidRequestResponse<T>(IList<CodeMessage> codeMessages) where T : BaseResponse, new()
        {
            var mensagens = new List<Mensagem>();

            foreach (var codeMessage in codeMessages)
                mensagens.Add(new Mensagem(codeMessage.Code, codeMessage.Message, TipoMensagem.Validacao));

            var respone = new T
            {
                Valido = false,
                Mensagens = mensagens
            };
            return respone;
        }
    }
}
