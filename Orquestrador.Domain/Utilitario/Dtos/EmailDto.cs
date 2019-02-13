using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Dtos
{
    [DataContract(Name = "Email", Namespace = "http://www.suanova.com.br/email/objects/")]
    public class EmailDto
    {
        [DataMember(Name = "IdEmail")]
        public System.Int32 IdEmail { get; set; }

        [DataMember(Name = "IdEmailTipo")]
        public System.Int32 IdEmailTipo { get; set; }

        [DataMember(Name = "NomeRemetente")]
        public System.String NomeRemetente { get; set; }

        [DataMember(Name = "EmailRemetente")]
        public System.String EmailRemetente { get; set; }

        [DataMember(Name = "NomeDestino")]
        public System.String NomeDestino { get; set; }

        [DataMember(Name = "EmailDestino")]
        public System.String EmailDestino { get; set; }

        [DataMember(Name = "Assunto")]
        public System.String Assunto { get; set; }

        [DataMember(Name = "IdCliente")]
        public int? IdCliente { get; set; }

        [DataMember(Name = "IdCompra")]
        public int? IdCompra { get; set; }

        [DataMember(Name = "IdSku")]
        public int? IdSku { get; set; }

        [DataMember(Name = "ChavesValor")]
        public List<ChaveValorDto> ChavesValor { get; set; }

        [DataMember(Name = "IdAdministrador")]
        public int? IdAdministrador { get; set; }
    }
}
