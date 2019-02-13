using System;
using System.Collections.Generic;
using System.Text;

namespace Orquestrador.Domain.Loja.Models
{
    public class Sku
    {
        public int IdCompraEntregaSku { get; set; }
        public int IdProdutoParceiro { get; set; }
        public string Produto { get; set; }
        public int IdSku { get; set; }
        public string TermosCondicoes { get; set; }        
        public string Hash { get; set; }
        public string Ativacao { get; set; }        
        public string RequisicaoId { get; set; }
        public string ClienteId { get; set; }
        public string StatusIntegracaoParceiro { get; set; }
        public DateTime? DataIntegracaoParceiro { get; set; }
        public string LogRetornoParceiro { get; set; }
        public int TentativasIntegracao { get; set; }
        public decimal Preco { get; set; }
        public int Tipo { get; set; }
        public string SkuParceiro { get; set; }
        public long GerencialId { get; set; }
        public byte Sequencial { get; set; }
        public string StatusIntegracaoERP { get; set; }
        public DateTime? DataIntegracaoERP { get; set; }
        public string LogRetornoERP { get; set; }
        public int TentativasIntegracaoERP { get; set; }
    }
}
