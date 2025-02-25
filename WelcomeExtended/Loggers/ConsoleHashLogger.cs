using System.Collections.Concurrent;
using System.IO.IsolatedStorage;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    class ConsoleHashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;
        private static int _eventCounter = 0;

        public ConsoleHashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
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
            var message = formatter(state, exception);
            _logMessages[_eventCounter++] = message;

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;                
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;                
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }

            Console.WriteLine("\n- LOGGER -\n");
            var messageToBeLogged = new StringBuilder();

            //DISPLAYS ONLY THE LAST ERROR
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("\n- LOGGER -\n");
            Console.ResetColor();


            //DISPLAYS THE LAST ERROR AND ALL PREVIOUS ERRORS
            //Console.WriteLine(" Last error:");
            //messageToBeLogged.Append($"[{logLevel}]");
            //messageToBeLogged.AppendFormat(" [{0}]", _name);
            //Console.WriteLine(messageToBeLogged);
            //Console.WriteLine($" {formatter(state, exception)}");

            //if (_logMessages.Count != 1)
            //{
            //    Console.WriteLine("\n All errors:");

            //    foreach (string msg in _logMessages.Values)
            //    {
            //        Console.WriteLine($" {msg}");
            //    }
            //}

            //Console.WriteLine("\n- LOGGER -\n");
            //Console.ResetColor();


            //DISPLAYS ERROR BY ITS ID
            //Console.WriteLine(" Last error:");
            //messageToBeLogged.Append($"[{logLevel}]");
            //messageToBeLogged.AppendFormat(" [{0}]", _name);
            //Console.WriteLine(messageToBeLogged);
            //Console.WriteLine($" {formatter(state, exception)}");

            //while (true)
            //{
            //    int id;
            //    Console.WriteLine("Select error by id (or type \"exit\"): ");
            //    string input = Console.ReadLine();

            //    if (!input.Equals("exit"))
            //    {
            //        try
            //        {
            //            id = Int32.Parse(input);
            //            if (id > (_logMessages.Count - 1))
            //            {
            //                throw new FormatException();
            //            }
            //            Console.WriteLine($" {_logMessages[id]}");
            //        }
            //        catch (FormatException)
            //        {
            //            Console.WriteLine("Invalid input!");
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //Console.WriteLine("\n- LOGGER -\n");
            //Console.ResetColor();


        }
    }
}
