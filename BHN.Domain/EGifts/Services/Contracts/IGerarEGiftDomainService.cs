using BHN.Domain.EGifts.Events;
using Enterprise.Framework.Domain.Events;

namespace BHN.Domain.EGifts.Services.Contracts
{
    public interface IGerarEGiftDomainService : IDomainEventHandle<GerarEGiftEvent>
    {
    }
}