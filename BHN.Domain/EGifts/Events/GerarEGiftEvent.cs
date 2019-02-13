using BHN.Domain.EGifts.Models;
using Enterprise.Framework.Domain.Events;

namespace BHN.Domain.EGifts.Events
{
    public class GerarEGiftEvent : IDomainEvent
    {
        public GerarEGift EGift { get; set; }
        public string CorrelationId { get; set; }

        public GerarEGiftEvent(GerarEGift eGift, string correlationId)
        {
            EGift = eGift;
            CorrelationId = correlationId;
        }
    }
}
