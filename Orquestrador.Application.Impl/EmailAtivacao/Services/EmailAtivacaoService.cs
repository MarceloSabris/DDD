using Enterprise.Framework.Services.Messages;
using Orquestrador.Application.EmailAtivacao.Messages;
using Orquestrador.Application.EmailAtivacao.Services;
using Orquestrador.Domain.Loja.Mappers;
using Orquestrador.Domain.Loja.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Application.Impl.EmailAtivacao.Services
{
    public class EmailAtivacaoService : IEmailAtivacaoService
    {
        private readonly ILojaHttpRepository _lojaHttpRepository;
        public EmailAtivacaoService(ILojaHttpRepository lojaHttpRepository)
        {
            this._lojaHttpRepository = lojaHttpRepository;
        }

        public async Task<EnviarCodigoClienteResponse> EnviarCodigoCliente(EnviarCodigoClienteRequest request)
        {
            var response = new EnviarCodigoClienteResponse();
            try
            {
                var responseLoja = await this._lojaHttpRepository.ListarComAtivacao(new Domain.Loja.Messages.ListarComAtivacaoRequest());

                if (responseLoja.Valido && responseLoja.ComprasAtivacao!=null && responseLoja.ComprasAtivacao.Any())
                {
                    var pedidos = responseLoja.ComprasAtivacao.Map();

                    foreach(var pedido in pedidos)
                    {
                        var correlationId = Guid.NewGuid().ToString();

                        await pedido.EnviarCodigoCliente(correlationId);
                    }

                    response.Valido = true;

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
