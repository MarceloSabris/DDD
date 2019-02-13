using Loja.Application.ComprasParceiro.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.ComprasParceiro.Services
{
    public interface ICompraParceiroService
    {
        Task<ObterUltimaCompraResponse> ObterUltimaCompra(ObterUltimaCompraRequest request);               

        Task<InserirCompraResponse> InserirCompraParceiro(InserirCompraRequest request);

        Task<AlterarStatusParceiroResponse> AlterarStatusParceiro(AlterarStatusParceiroRequest request);

        Task<ListarCompraResponse> Listar(ListarComprasRequest request);
    }
}
