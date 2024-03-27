using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using RGBA.Optio.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.LoggerFiles
{
    public class Loggeri : ILogger
    {
        private readonly OptioMongoContext context;

        public Loggeri()
        {
            context = new OptioMongoContext();
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (logLevel == LogLevel.Information || logLevel == LogLevel.Error || logLevel == LogLevel.Critical)
            {
                var doc = new BsonDocument
               {
                   { "LogLevel", logLevel.ToString() },
                   { "Message", formatter(state, exception) }
            };
                context.UserLogs.InsertOne(doc);
            }
        }
    }
}
