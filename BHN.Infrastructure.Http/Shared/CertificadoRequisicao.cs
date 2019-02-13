using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace BHN.Infrastructure.Http.Shared
{
    public static class CertificadoRequisicao
    {
        public static X509Certificate2 Obter(string path, string password = null)
        {
            if (File.Exists(path))
            {
                var certificado = new X509Certificate2(File.ReadAllBytes(path), password: password);
                return certificado;
            }
            throw new Exception("Certificado BHN não encontrado.");
        }
    }
}