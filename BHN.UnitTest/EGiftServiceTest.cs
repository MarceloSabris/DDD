using BHN.Application.EGift.Dtos;
using BHN.Application.EGift.Messages;
using BHN.Application.Impl.EGift.Services;
using BHN.Infrastructure.Http.EGift.Services;
using BHN.Infrastructure.Http.Shared;
using BHN.Infrastructure.SqlClient;
using Enterprise.Framework.Collections;
using Enterprise.Framework.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace BHN.UnitTest
{
    public class EGiftServiceTest
    {
        private EGiftService ObterService()
        {
            return new EGiftService(new EGiftHttpService(new DadosBhn()
            {
                CertificadoCaminho = @"C:\GIT\BHN\certificado_bhn_PREPROD.p12",
                CertificadoSenha = "LPNKNC24RZPZ3Z27FCQ2BZH2HC",
                VendedorId = "6T1XSTHG5C5643DZZ42230WX24",
                UrlApi = "https://api.certification.blackhawknetwork.com/",
                GerarHashRota = "eGiftProcessing/v1/generateEGift",
                DesfazimentoRota = "eGiftProcessing/v1/reverseEGift",
                TemplateActivationSpot = "https://egift.activationspot.com/egift?eid={0}&tid=44PGKM1RFPS2PZ9P9LRKTDL8Q8",
                GerarKeyRota = "accountProcessing/v1/getAccount?accountId={0}"
            }), null);
        }

        private GerarEGiftDto GerarEGiftDtoPadrao()
        {
            return new GerarEGiftDto()
            {
                ClienteId = "F7HP2Q7CPLPV8QZ88N9FN95ZCW",
                GerarCodigoAtivacao = false,
                NumeroPedido = "111122223333",
                SKUParceiro = "HHM5KXHN2PVQ9ALDQBWLN4VT94",
                Preco = 20,
                RequisicaoId = Guid.NewGuid().ToString()
            };
        }

        [Fact(DisplayName = "Testa o Servico de Gerar Hash sem Key")]
        public async void TestaGeracaoHash()
        {
            var request = new GerarCompraRequest()
            {
                GerarEGift = GerarEGiftDtoPadrao()
            };

            var response = await ObterService().GerarCodigo(request);

            Uri url;
            Assert.True(
                        Uri.TryCreate(response.EGift.Ativacao, UriKind.Absolute, out url)
                        && (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps)
                    );
        }

        [Fact(DisplayName = "Testa o Servico de Gerar Hash com Key")]
        public async void TestaGeracaoKey()
        {
            var request = new GerarCompraRequest()
            {
                GerarEGift = GerarEGiftDtoPadrao()
            };

            request.GerarEGift.GerarCodigoAtivacao = true;

            var response = await ObterService().GerarCodigo(request);

            Assert.NotNull(response.EGift.Ativacao);
        }

        [Fact(DisplayName = "Testa o Servico usando uma ProductConfigurationId inválida")]
        public async void TestaExceptionProductConfigurationInvalida()
        {
            var request = new GerarCompraRequest()
            {
                GerarEGift = GerarEGiftDtoPadrao()
            };

            request.GerarEGift.SKUParceiro = "FAIL";

            var response = await ObterService().GerarCodigo(request);

            Assert.False(response.Valido);
        }

        [Fact(DisplayName = "Testa o Serviço de Gerar uma Key com base em um Hash (retry)")]
        public async void TestaChamadaKey()
        {
            var requestHash = new GerarCompraRequest()
            {
                GerarEGift = GerarEGiftDtoPadrao()
            };

            requestHash.GerarEGift.GerarCodigoAtivacao = true;

            var responseHash = await ObterService().GerarCodigo(requestHash);

            var request = requestHash;            
            request.GerarEGift.Hash = responseHash.EGift.Hash;
            request.GerarEGift.ClienteId = responseHash.EGift.ClienteId;

            var response = await ObterService().GerarCodigo(request);

            Assert.NotNull(response.EGift.Ativacao);
        }

        [Fact(DisplayName = "Testa o Servico de Desfazimento de Hash")]
        public async void TestaDesfazimento()
        {
            var requestEGift = new GerarCompraRequest()
            {
                GerarEGift = GerarEGiftDtoPadrao()
            };

            var responseEGift = await ObterService().GerarCodigo(requestEGift);

            Assert.NotEmpty(responseEGift.EGift.RequisicaoId);

            var request = new DesfazimentoRequest()
            {
                RequisicaoId = responseEGift.EGift.RequisicaoId
            };

            var response = await ObterService().Desfazimento(request);

            Assert.True(response.Valido);
        }
    }
}