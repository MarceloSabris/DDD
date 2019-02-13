using Enterprise.Framework.Log;
using Enterprise.Framework.Log.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Framework.Logging
{
    public  class LoggerService : ILoggerService
    {
        private readonly ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }

        public void LogError(string message, string entity, string description, Exception ex)
        {
            var correlationId = System.Guid.NewGuid();

            _log.Error(correlationId, ex, message, correlationId, entity: entity, keys: null, process: description, content: null, dataContainer: null);

        }

        public void LogInfo(string message, string entity, string description)
        {
            var correlationId = System.Guid.NewGuid();

            _log.Info(correlationId, message, correlationId, entity: entity, keys: null, process: description, content: null, dataContainer: null);
        }


    }
}
