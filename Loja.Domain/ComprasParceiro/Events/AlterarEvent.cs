﻿
using Enterprise.Framework.Domain.Events;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.ComprasParceiro.Events
{
    public class AlterarEvent : IDomainEvent
    {
        public AlterarEvent(CompraParceiro compra, string correlationId)
        {
            Compra = compra;
            CorrelationId = correlationId;
        }

        public string CorrelationId { get; private set; }
        public CompraParceiro Compra { get; private set; }

    }

}
