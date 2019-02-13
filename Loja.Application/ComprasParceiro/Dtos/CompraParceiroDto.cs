using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.ComprasParceiro.Dtos
{
    public class CompraParceiroDto
    {
        public int IdCompra { get; set; }
        public int IdProdutoParceiro { get; set; }
        public int IdCompraEntregaSku { get; set; }
        public string Ativacao { get; set; }
        public string StatusIntegracaoParceiro { get; set; }
        public DateTime DataInclusao { get; set; }
		public string StatusAceite { get; set; }
		public string EmailEnvioAtivacao { get; set; }
        public string EmailEnvioAceito { get; set; }
        public DateTime? DataStatusAceite { get; set; }
        public DateTime? DataEnvioAceite { get; set; }
        public DateTime? DataIntegracaoParceiro { get; set; }
        public string LogRetornoParceiro { get; set; }
        public DateTime? DataEnvioAtivacao { get; set; }
        public string Hash { get; set; }
        public string RequisicaoId { get; set; }
        public int TentativasIntegracao { get; set; }
        public string ClienteId{ get; set; }
    }
}
