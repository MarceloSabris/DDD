using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Models
{
   public class Endereco
    {
        public string IdentificacaoEndereco { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string PontoReferencia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
