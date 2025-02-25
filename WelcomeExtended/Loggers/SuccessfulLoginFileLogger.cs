using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;

namespace WelcomeExtended_.Loggers
{
    class SuccessfulLoginFileLogger : ILogger
    {
        private readonly string _name;
        public SuccessfulLoginFileLogger(string name)
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

            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append(dateTime.ToString());
            messageToBeLogged.Append(":[" + _name + "] ");
            messageToBeLogged.Append(state);

            string file = "../../../Files/LoginLog.txt";
            using(StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(messageToBeLogged);
            }
        }
    }
}
