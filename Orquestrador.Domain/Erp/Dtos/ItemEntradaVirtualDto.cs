using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Erp.Dtos
{
    public class ItemEntradaVirtualDto
    {
        public long GerencialId { get; set; }

        public int IdUnidadeNegocio { get; set; }

        public string Usuario { get; set; }

        public byte Sequencial { get; set; }
    }
}
