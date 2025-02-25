using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;
using System.Xml.Linq;
using Welcome.Model;
using WelcomeExtended.Others;

namespace WelcomeExtended_.Loggers
{
    class LoginFileLogger : ILogger
    {
        private readonly string _name;
        public LoginFileLogger(string name)
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
            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(messageToBeLogged);
            }

            var databaseLog = new DatabaseAction(Delegates.LogDatabase);
            databaseLog(messageToBeLogged.ToString());
        }
    }
}
