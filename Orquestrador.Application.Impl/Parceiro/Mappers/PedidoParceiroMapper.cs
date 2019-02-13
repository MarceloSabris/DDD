
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orquestrador.Application.Impl.Parceiro.Mappers
{
    public static class PedidoParceiroMapper
    {
        public static List<Application.Parceiro.Dtos.CompraParceiroDto> MapPedidos(this IEnumerable<Domain.Loja.Dtos.CompraParceiroDto> list)
        {
            return list.Select(x => x.Map()).ToList();
        }

        private static Application.Parceiro.Dtos.CompraParceiroDto Map(this Domain.Loja.Dtos.CompraParceiroDto model)
        {
            return new Application.Parceiro.Dtos.CompraParceiroDto()
            {
                Ativacao = model.Ativacao,
                ClienteId = model.ClienteId,
                DataEnvioAceite=model.DataEnvioAceite,
                DataEnvioAtivacao=model.DataEnvioAtivacao,
                DataInclusao=model.DataInclusao,
                DataIntegracaoParceiro=model.DataIntegracaoParceiro,
                DataStatusAceite=model.DataStatusAceite,
                EmailEnvioAceito=model.EmailEnvioAceito,
                EmailEnvioAtivacao=model.EmailEnvioAtivacao,
                Hash=model.Hash,
                IdCompra=model.IdCompra,
                IdCompraEntregaSku=model.IdCompraEntregaSku,
                IdProdutoParceiro=model.IdProdutoParceiro,
                LogRetornoParceiro=model.LogRetornoParceiro,
                RequisicaoId=model.RequisicaoId,
                StatusAceite=model.StatusAceite,
                StatusIntegracaoParceiro=model.StatusIntegracaoParceiro,
                TentativasIntegracao=model.TentativasIntegracao
            };
        }
    }
}
