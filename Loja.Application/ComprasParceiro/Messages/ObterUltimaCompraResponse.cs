﻿
using Enterprise.Framework.Services.Messages;
using Loja.Application.ComprasParceiro.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.ComprasParceiro.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class ObterUltimaCompraResponse : BaseResponse
    {
        [DataMember(Name = "UltimaCompraParceiro")]
        public CompraParceiroDto CompraParceiro { get; set; }
    }
}
