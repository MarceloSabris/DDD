﻿
using Enterprise.Framework.Services.Messages;
using Loja.Application.TermoAceite.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.TermoAceite.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class ListarCompraComAceiteResponse : BaseResponse
    {
        [DataMember(Name = "ComprasParceiro")]
        public IEnumerable<CompraParceiroProdutoDto> ComprasParceiro { get; set; }
    
    }
}
