using BHN.Domain.ProdutosBHN.Messages;
using System.Threading.Tasks;

namespace BHN.Application.Produto.Services
{
    public interface IProdutoService
    {
        Task<ObterDetalhesProdutoResponse> DetalhesProduto(ObterDetalhesProdutoRequest request);
    }
}
