using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    static class LoggerHelper
    {
        public static ILogger GetConsoleLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new ConsoleLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
        public static ILogger GetFileLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new FileLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
        public static ILogger GetSuccessfulLoginFileLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new SuccessfulLoginFileLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
        public static ILogger GetUnsuccessfulLoginFileLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new UnsuccessfulLoginFileLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
