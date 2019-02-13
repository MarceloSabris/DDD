using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Framework.Logging
{
    public interface ILoggerService
    {
        void LogError(string message, string entity, string description, Exception ex = null);
        void LogInfo(string message, string entity, string description);
    }
}
