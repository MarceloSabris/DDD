using Enterprise.Framework.Domain.BusinessResults;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Services.Messages;

namespace Loja.Domain.ComprasParceiro.Mappers
{
    public static class BusinessResultMapper
    {
        public static BusinessResult Map(this EventResult eventResult)
        {
            return new BusinessResult
            {
                Valido = eventResult.IsValid
            };
        }

        public static BusinessResult Map(this EventResult eventResult, TipoMensagem tipoMensagem)
        {
            BusinessResult businessResult = new BusinessResult
            {
                Valido = eventResult.IsValid
            };
            if (!eventResult.IsValid)
            {
                eventResult.Mensagens.ForEach(mensagem =>
                {
                    businessResult.Adicionar(mensagem.Code, mensagem.Content, tipoMensagem);
                });
            }
            return businessResult;
        }


    }
}
