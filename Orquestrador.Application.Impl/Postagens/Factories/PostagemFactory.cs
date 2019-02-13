using Orquestrador.Application.Impl.Pedidos.Mappers;
using Orquestrador.Application.Postagens.Factories;
using Orquestrador.Common;
using Orquestrador.Domain.Filiais.Models;
using Orquestrador.Domain.Filiais.Repositories;
using Orquestrador.Domain.Pedidos.Messages;
using Orquestrador.Domain.Pedidos.Models;
using Orquestrador.Domain.Pedidos.Repositories;
using Orquestrador.Domain.Postagens.Models;
using System;
using System.Threading.Tasks;

namespace Orquestrador.Application.Impl.Postagens.Factories
{
    public class PostagemFactory : IPostagemFactory
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoHttpRepository _pedidoHttpRepository;
        private readonly IFilialRepository _filialRepository;
        public PostagemFactory(IPedidoRepository pedidoRepository,
                               IPedidoHttpRepository pedidoHttpRepository,
                               IFilialRepository filialRepository)
        {
            _pedidoRepository = pedidoRepository ?? throw new ArgumentNullException(nameof(pedidoRepository));
            _filialRepository = filialRepository ?? throw new ArgumentNullException(nameof(filialRepository));
            _pedidoHttpRepository = pedidoHttpRepository ?? throw new ArgumentNullException(nameof(pedidoHttpRepository));
        }
        public async Task<Postagem> Gerar(PostagemId postagemId,string correlationId)
        {
            Pedido pedido = await ObterPedido(postagemId, correlationId);
            Filial filial = await ObterFilial(pedido.CNPJ);
            Postagem postagem = new Postagem(postagemId, pedido, filial);
            return postagem;
        }

        private async Task<Pedido> ObterPedido(PostagemId postagemId, string correlationId)
        {
            Pedido pedido = await _pedidoRepository.Obter(postagemId.IdUnidadeNegocio, postagemId.IdPedido);

            if (pedido == null)
            {
                ConsultarPedidoRequest request = postagemId.Map();
                request.AddHeader(Const.CorrelationID, correlationId);

                ConsultarPedidoResponse response = await _pedidoHttpRepository.Obter(request);                
                if (response.Valido)
                    pedido = response.Map();
                else
                    throw new ApplicationException("Pedido não encontrado.");
            }

            return pedido;
        }

        private async Task<Filial> ObterFilial(string cnpj)
        {
            Filial filial = await _filialRepository.Obter(cnpj);

            if (filial == null)
                throw new ApplicationException($"Filial não encontrada.");

            return filial;
        }
    }
}