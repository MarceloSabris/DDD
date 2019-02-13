namespace BHN.Domain.EGifts.Models
{
    public class AcaoEGift
    {
        public int IdAcaoEGift { get; set; }

        public int Numero { get; set; } // Status Code

        public string CodigoRetorno { get; set; } // Status text

        public string Descricao { get; set; }

        public string Acao { get; set; }

        public bool Desfazer { get; set; }


        public override string ToString()
        {
            return string.Format("Descrição: {0} - Ação: {1} - Desfazer: {2}", Descricao, Acao, (Desfazer ? "Sim" : "Não"));
        }
    }
}
