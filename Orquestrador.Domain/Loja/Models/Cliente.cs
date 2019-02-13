using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string EmailEnvioAceito { get; set; }
        public string EmailEnvioAtivacao { get; set; }
    }
}
