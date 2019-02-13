using BHN.Domain.Shared.CodeMessages.Models;
using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;

namespace BHN.Application.Utils
{
    public class ResponseUtil
    {
        /// <summary>
        /// Get request is null with related messages.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <returns>Response.</returns>
        public static T GetRequestIsNullResponse<T>() where T : BaseResponse, new()
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
        public static T GetResponseError<T>(Exception ex) where T : BaseResponse, new() => GetResponseError<T>(string.Empty, ex);

        /// <summary>
        /// Get error message.
        /// </summary>
        /// <typeparam name="T">A base response type.</typeparam>
        /// <param name="message">Info message.</param>
        /// <param name="ex">Exception object.</param>
        /// <returns>Response.</returns>
        public static T GetResponseError<T>(string message, Exception ex) where T : BaseResponse, new()
        {
            var exception = ex.InnerException ?? ex;
            if (exception != null)
            {
                if (!string.IsNullOrWhiteSpace(message))
                    message = $"{message}. {exception.Message}";
                else
                    message = exception.Message;
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
        public static T GetInvalidRequestResponse<T>(CodeMessage codeMessage) where T : BaseResponse, new()
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
        public static T GetInvalidRequestResponse<T>(IList<CodeMessage> codeMessages) where T : BaseResponse, new()
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
