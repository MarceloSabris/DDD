using BHN.Domain.ProdutosBHN.Models;
using System.Threading.Tasks;

namespace BHN.Domain.ProdutosBHN.Repositories
{
    public interface IProdutoBHNRepository
    {
        Task<ProdutoBHN> Obter(string sku);
    }
}
