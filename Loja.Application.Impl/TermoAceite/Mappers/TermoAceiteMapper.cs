using Loja.Application.TermoAceite.Messages;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.TermoAceite.Mappers
{
    public static class TermoAceiteMapper
    {
        public static CompraParceiro Map(this StatusAceiteRequest entity)
        {
            if (entity == null) return null;

            return new CompraParceiro()
            {               
                IdCompra = entity.IdCompra,
                IdCompraEntregaSku = entity.IdCompraSKU,
                StatusAceite = entity.StatusAceite
            };
        }
    }
}
