using BHN.Application.EGift.Dtos;
using BHN.Domain.EGifts.Models;
using System;

namespace BHN.Application.Impl.EGift.Mappers
{
    public static class EGiftMapper
    {
        public static GerarEGift Map(this GerarEGiftDto entity)
        {
            if (entity == null) return null;

            return new GerarEGift()
            {
                ClienteId = entity.ClienteId,
                GerarCodigoAtivacao = entity.GerarCodigoAtivacao,
                NumeroPedido = entity.NumeroPedido,
                Preco = entity.Preco,
                SKUParceiro = entity.SKUParceiro,
                RequisicaoId = entity.RequisicaoId,
                TentativasAnteriores = entity.TentativasAnteriores,
                Hash = entity.Hash
            };
        }

        public static GerarEGiftDto Map(this GerarEGift objeto)
        {
            if (objeto == null) return null;

            return new GerarEGiftDto()
            {
                Ativacao = objeto.Ativacao,
                ClienteId = objeto.ClienteId,
                DesfazimentoExecutado = objeto.DesfazimentoExecutado,
                DesfazimentoNecessario = objeto.DesfazimentoNecessario,
                GerarCodigoAtivacao = objeto.GerarCodigoAtivacao,
                Hash = objeto.Hash,
                NumeroPedido = objeto.NumeroPedido,
                Preco = objeto.Preco,
                RequisicaoId = objeto.RequisicaoId,
                SKUParceiro = objeto.SKUParceiro,
                TentativasAnteriores = objeto.TentativasAnteriores
            };
        }
        
        public static string GerarRequisicaoId(this GerarEGiftDto entity)
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}