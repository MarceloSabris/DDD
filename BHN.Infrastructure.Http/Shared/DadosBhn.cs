using System;

namespace BHN.Infrastructure.Http.Shared
{
    public class DadosBhn
    {
        public string CertificadoCaminho { get; set; }
        public string CertificadoSenha { get; set; }

        public string UrlApi { get; set; }
        public string TemplateActivationSpot { get; set; }

        public string VendedorId { get; set; }

        public string GerarHashRota { get; set; }
        public string DesfazimentoRota { get; set; }
        public string VersaoCatalogoRota { get; set; }
        public string DetalhesProdutoRota { get; set; }
        public string DetalhesCatalogoRota { get; set; }
        public string GerarKeyRota { get; set; }
    }
}