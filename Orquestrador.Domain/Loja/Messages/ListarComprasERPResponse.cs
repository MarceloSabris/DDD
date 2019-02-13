﻿using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Loja.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class ListarComprasERPResponse : BaseResponse
    {
        [DataMember(Name = "ComprasERP")]
        public IEnumerable<CompraERPDto> ComprasERP { get; set; }
    }
}
