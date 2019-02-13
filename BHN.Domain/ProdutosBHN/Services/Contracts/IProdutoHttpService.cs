using BHN.Domain.ProdutosBHN.Messages;
using System.Threading.Tasks;

namespace BHN.Domain.ProdutosBHN.Services.Contracts
{
    public interface IProdutoHttpService
    {
        Task<ObterDetalhesProdutoResponse> DetalhesProduto(ObterDetalhesProdutoRequest request);
    }
}
