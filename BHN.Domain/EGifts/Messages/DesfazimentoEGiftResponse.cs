using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHN.Domain.EGifts.Messages
{
    public class DesfazimentoEGiftResponse : BaseResponse
    {
        public string TransactionStatus { get; set; }
    }
}