using Orquestrador.Application.Postagens.Loggers;
using Orquestrador.Application.Postagens.Messages;
using Orquestrador.Common;
using Orquestrador.Domain.Postagens.Messages;
using Enterprise.Framework.Log;
using Enterprise.Framework.Log.Models;
using System;
using System.Collections.Generic;

namespace Orquestrador.Application.Impl.Postagens.Loggers
{
    public class PostagemLogger : IPostagemLogger
    {
        private readonly ILog _log;

        public PostagemLogger(ILog log)
        {
            _log = log;
        }

        public void Log(string message, GerarCodigoRequest request, GerarCodigoResponse response = null, Exception ex = null)
        {
            var keys = new List<string>();
            var dataContainer = new List<ContainerItem>();

            if (request != null)
            {
                keys.Add(nameof(request.Companhia));
                dataContainer.Add(new ContainerItem(nameof(request.Companhia), request.Companhia.ToString()));

                keys.Add(nameof(request.IdUnidadeNegocio));
                dataContainer.Add(new ContainerItem(nameof(request.IdUnidadeNegocio), request.IdUnidadeNegocio.ToString()));

                keys.Add(nameof(request.IdSku));
                dataContainer.Add(new ContainerItem(nameof(request.IdSku), request.IdSku.ToString()));

                keys.Add(nameof(request.IdPedido));
                dataContainer.Add(new ContainerItem(nameof(request.IdPedido), request.IdPedido.ToString()));

                keys.Add(nameof(request.IdPedidoEntrega));
                dataContainer.Add(new ContainerItem(nameof(request.IdPedidoEntrega), request.IdPedidoEntrega.ToString()));

                keys.Add(nameof(request.Funcionario));
                dataContainer.Add(new ContainerItem(nameof(request.Funcionario), request.Funcionario));

                keys.Add(nameof(request.Protocolo));
                dataContainer.Add(new ContainerItem(nameof(request.Protocolo), request.Protocolo));
            }

            var content = new { request, response };

            if (ex != null)
                _log.Error(request.CorrelationId, ex, message, request.CorrelationId, entity: LogInfo.GerarCodigoPostagem.MainEntity, keys: keys, process: LogInfo.GerarCodigoPostagem.Description, content: content, dataContainer: dataContainer);
            else
                _log.Info(request.CorrelationId, message, request.CorrelationId, entity: LogInfo.GerarCodigoPostagem.MainEntity, keys: keys, process: LogInfo.GerarCodigoPostagem.Description, content: content, dataContainer: dataContainer);
        }

        public void Log(string message, CancelarCodigoRequest request, CancelarCodigoResponse response = null, Exception ex = null)
        {
            var keys = new List<string>();
            var dataContainer = new List<ContainerItem>();

            if (request != null)
            {
                keys.Add(nameof(request.Companhia));
                dataContainer.Add(new ContainerItem(nameof(request.Companhia), request.Companhia.ToString()));

                keys.Add(nameof(request.IdUnidadeNegocio));
                dataContainer.Add(new ContainerItem(nameof(request.IdUnidadeNegocio), request.IdUnidadeNegocio.ToString()));

                keys.Add(nameof(request.IdSku));
                dataContainer.Add(new ContainerItem(nameof(request.IdSku), request.IdSku.ToString()));

                keys.Add(nameof(request.IdPedido));
                dataContainer.Add(new ContainerItem(nameof(request.IdPedido), request.IdPedido.ToString()));

                keys.Add(nameof(request.IdPedidoEntrega));
                dataContainer.Add(new ContainerItem(nameof(request.IdPedidoEntrega), request.IdPedidoEntrega.ToString()));

                keys.Add(nameof(request.Funcionario));
                dataContainer.Add(new ContainerItem(nameof(request.Funcionario), request.Funcionario));

                keys.Add(nameof(request.Protocolo));
                dataContainer.Add(new ContainerItem(nameof(request.Protocolo), request.Protocolo));

                keys.Add(nameof(request.Tipo));
                dataContainer.Add(new ContainerItem(nameof(request.Tipo), request.Tipo));
            }

            var content = new { request, response };

            Guid correlationId = new Guid(request.GetHeader(Const.CorrelationID));

            if (ex != null)
                _log.Error(correlationId, ex, message, correlationId, entity: LogInfo.CancelarCodigoPostagem.MainEntity, keys: keys, process: LogInfo.CancelarCodigoPostagem.Description, content: content, dataContainer: dataContainer);
            else
                _log.Info(correlationId, message, correlationId, entity: LogInfo.CancelarCodigoPostagem.MainEntity, keys: keys, process: LogInfo.CancelarCodigoPostagem.Description, content: content, dataContainer: dataContainer);
        }
    }
}
