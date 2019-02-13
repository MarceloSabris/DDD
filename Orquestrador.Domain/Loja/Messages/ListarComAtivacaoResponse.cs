using Enterprise.Framework.Services.Messages;
using Orquestrador.Domain.Loja.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Loja.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class ListarComAtivacaoResponse : BaseResponse
    {
        [DataMember(Name = "ComprasAtivacao")]
        public List<CompraAtivacaoDto> ComprasAtivacao { get; set; }
    }
}
