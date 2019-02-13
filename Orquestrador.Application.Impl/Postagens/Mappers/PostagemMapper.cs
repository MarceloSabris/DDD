using Orquestrador.Application.Postagens.Messages;
using Orquestrador.Domain.Postagens.Models;

namespace Orquestrador.Application.Impl.Postagens.Mappers
{
    public static class PostagemMapper
    {
        public static PostagemId Map(this GerarCodigoRequest request)
        {
            return PostagemId.Criar(request.Companhia,
                request.IdUnidadeNegocio,
                request.IdSku,
                request.IdPedido,
                request.IdPedidoEntrega,
                request.Funcionario,
                request.Protocolo);
        }
    }
}