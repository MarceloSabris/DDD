using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Ativacao.Dtos
{
    public class CompraAtivacaoDto
    {
        public int IdCompra { get; set; }
        public int IdCompraEntregaSku { get; set; }
        public int IdProdutoParceiro { get; set; }
        public string Produto { get; set; }
        public int IdSku { get; set; }
        public string TermosCondicoes { get; set; }
        public string EmailEnvioAceito { get; set; }
        public string Hash { get; set; }
        public string Ativacao { get; set; }
        public string EmailEnvioAtivacao { get; set; }
        public string RequisicaoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
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
        public int IdCliente { get; set; }
    }
}
