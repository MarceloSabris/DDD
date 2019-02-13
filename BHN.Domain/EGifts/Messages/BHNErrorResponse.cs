using System;
using System.Net;
using System.Runtime.Serialization;

namespace BHN.Domain.EGifts.Messages
{
    public class BHNErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

    public class BHNResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string ErrorCode { get; private set; }

        public BHNResponseException(HttpStatusCode statusCode, string errorCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        public override string ToString()
        {
            var template = "Status: ({3}) {0} - ErrorCode: {1} - Message: {2}";
            return string.Format(template, StatusCode, ErrorCode, Message, (int)StatusCode);
        }

        #region default ctors

        public BHNResponseException()
        {
        }

        public BHNResponseException(string message) : base(message)
        {
        }

        public BHNResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BHNResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion
    }
}