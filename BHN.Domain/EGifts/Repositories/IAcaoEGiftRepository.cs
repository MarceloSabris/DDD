using BHN.Domain.EGifts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHN.Domain.EGifts.Repositories
{
    public interface IAcaoEGiftRepository
    {
        Task<IEnumerable<AcaoEGift>> ObterPorNumero(int numero);

        Task<IEnumerable<AcaoEGift>> ObterPorCodigoRetorno(string codigo);
    }
}
