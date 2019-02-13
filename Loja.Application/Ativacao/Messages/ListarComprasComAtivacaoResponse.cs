
using Enterprise.Framework.Services.Messages;
using Loja.Application.Ativacao.Dtos;
using Loja.Application.ComprasParceiro.Dtos;

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.Ativacao.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class ListarComprasComAtivacaoResponse : BaseResponse
    {
        [DataMember(Name = "ComprasAtivacao")]
        public IEnumerable<CompraAtivacaoDto> ComprasAtivacao { get; set; }
    
    }
}
