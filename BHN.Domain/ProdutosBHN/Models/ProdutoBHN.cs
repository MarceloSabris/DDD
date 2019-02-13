namespace BHN.Domain.ProdutosBHN.Models
{
    public class ProdutoBHN
    {
        public int IdProdutoBHN { get; set; }        

        public string Sku { get; set; }
        public string ProductConfigurationId { get; set; }

        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public string InstrucoesUso { get; set; }
        public string TermosCondicoes { get; set; }
        public decimal Preco { get; set; }        

        public string VersaoCatalogo { get; set; }

        public bool Ativo { get; set; }
    }
}