﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Dtos
{
    public class AlterarStatusAtivacaoDto
    {        
        public int IdCompra { get; set; }

        public int IdCompraEntregaSku { get; set; }
        
        public DateTime? DataEnvioAtivacao { get; set; }
    }
}
