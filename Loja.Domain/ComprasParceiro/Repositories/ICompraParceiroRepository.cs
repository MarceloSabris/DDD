using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.ComprasParceiro.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.ComprasParceiro.Repositories
{
    public interface ICompraParceiroRepository
    {
        Task<CompraParceiro> ObterPorCompraEntrega(int idCompra, int idCompraEntregaSku);

        Task<CompraParceiro> ObterUltimaRecente();

        Task<int> Inserir(CompraParceiro compra);

        Task<int> Alterar(CompraParceiro compra);

        Task<IEnumerable<CompraParceiroProduto>> ListarComAceite();

        Task<IEnumerable<CompraParceiro>> Listar(int idCompra, int idCompraEntregaSku, int idProdutoParceiro);
		
		Task<int> AlterarStatusAceiteAsync(AlterarStatusAceite compraParceiro);

        Task<int> AlterarStatusParceiro(AlterarStatusParceiro compra);

        Task<int> AlterarStatusAtivacao(AlterarStatusAtivacao compra);
    }
}
