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
        public static ILogger GetLoginFileLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoginFileLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
        public static ILogger GetDatabaseLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new DatabaseLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
