using BHN.Application.Impl.Produto.Services;
using BHN.Domain.ProdutosBHN.Messages;
using BHN.Infrastructure.Http.Produto.Services;
using BHN.Infrastructure.Http.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BHN.UnitTest
{
    public class ProdutoServiceTest
    {
        private ProdutoService ObterService()
        {
            return new ProdutoService(new ProdutoHttpService(new DadosBhn()
            {
                CertificadoCaminho = @"C:\GIT\BHN\certificado_bhn_PREPROD.p12",
                CertificadoSenha = "LPNKNC24RZPZ3Z27FCQ2BZH2HC",
                VendedorId = "6T1XSTHG5C5643DZZ42230WX24",
                UrlApi = "https://api.certification.blackhawknetwork.com/",
                DetalhesProdutoRota = "productManagement/v1/product/{0}"
            }));
        }

        [Fact(DisplayName = "Obtem Detalhes de um Produto")]
        public async void DetalhesProduto()
        {
            /*
                    VSCHG6C00380AYCPNF69CHH0VL
                    J6DW4YPZW4FS3V4R7SR4A99H71
                    NR05F8D0AVKPL94DHT3ZXGLF9T
                    R1VPF50C18JWLXQ7XA0SC5N68V
                    6JKSY80SRPLLRVYB7TSZ6GXPXX
                    0LDPYCT1DKHTM4THQKRNLBH3WY
                    KYLDH3VVCV3HD832HXQZWNHTDD
                    VJLMZVJ13Z7ZFRCW3Y2QP95C5G
                    22FP9XNMYXWQ0WS7AVR6X5MBS5
                    CDCH25A6S6P94DVK5NN0AZYV8Q - HH
                    MNVL66QAL2NCGRMAG6NAH1CGNT
                    GQGP549HYVDT2W0Q7XP5FM5978
                    206ZKRLG3M7F33QC755HW8812D
                    MZVFC9RA7SRHYMTXD62V96XKAZ
                    350L6WMMM3PVT84J764WYKNK78
                    2QH1D633YYJJ575A18SF7FY7SV
                    RQ7VVX9CKA2MW8ZGHB9GJBXPJ1
                    Z0R27KYRJAMRYV4WLQLRZ30881
                    3CJFG7P5SX0VX8TB74TDQ2F8QR
                    S1XF19JX1237S8DX2CS2MMLYD1
                    7JD0L9Z591BH2Z8W8WXK0ZQXXJ
            */
            var request = new ObterDetalhesProdutoRequest()
            {
                IdProduto = "CDCH25A6S6P94DVK5NN0AZYV8Q"
            };

            var response = await ObterService().DetalhesProduto(request);

            Assert.True(response.Valido);
        }

        [Fact(DisplayName = "Obtem Exception ao tentar resgatar Detalhes de um Produto")]
        public async void DetalhesProdutoComException()
        {
            var request = new ObterDetalhesProdutoRequest()
            {
                IdProduto = "FAIL"
            };

            var response = await ObterService().DetalhesProduto(request);

            Assert.False(response.Valido);
        }

    }
}