﻿namespace Orquestrador.Domain.Parceiro.Dtos
{
    public class GerarEGiftDto
    {
        public string RequisicaoId { get; set; }
        public string ClienteId { get; set; }
        public string SKUParceiro { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Preco { get; set; }
        public bool GerarCodigoAtivacao { get; set; }
        public string Hash { get; set; }
        public int TentativasAnteriores { get; set; }
    }
}