using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;
using DataLayer.Database;
using Microsoft.Extensions.Logging.Abstractions;
using DataLayer.Model;

namespace WelcomeExtended_.Loggers
{
    class DatabaseLogger : ILogger
    {
        private readonly string _name;
        public DatabaseLogger(string name)
        {
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            DateTime dateTime = DateTime.Now;
            string message = formatter(state, exception);

            using (var context = new DatabaseContext())
            {
                var logEntry = new DatabaseLog
                {
                    TimeStamp = dateTime,
                    Message = message
                };

                context.Logs.Add(logEntry);
                context.SaveChanges();
            }
        }
    }
}
