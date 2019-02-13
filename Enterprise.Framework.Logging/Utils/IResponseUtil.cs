using Enterprise.Framework.Services.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Framework.Logging.Utils
{
    public interface IResponseUtil
    {
        T GetRequestIsNullResponse<T>() where T : BaseResponse, new();
        T GetResponseError<T>(Exception ex) where T : BaseResponse, new();
        T GetResponseError<T>(object caller, Exception ex) where T : BaseResponse, new();
        T GetInvalidRequestResponse<T>(CodeMessage codeMessage) where T : BaseResponse, new();
        T GetInvalidRequestResponse<T>(IList<CodeMessage> codeMessages) where T : BaseResponse, new();
    }
}
