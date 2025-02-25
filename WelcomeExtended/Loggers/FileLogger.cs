using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;
using WelcomeExtended.Others;

namespace WelcomeExtended_.Loggers
{
    class FileLogger : ILogger
    {
        private readonly string _name;
        public FileLogger(string name)
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

            var message = formatter(state, exception);
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append(dateTime.ToString());
            messageToBeLogged.Append($":[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            messageToBeLogged.Append($" {message}");

            string file = "../../../Files/ErrorLog.txt";
            using(StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(messageToBeLogged);
            }

            var databaseLog = new DatabaseAction(Delegates.LogDatabase);
            databaseLog(messageToBeLogged.ToString());
        }
    }
}
