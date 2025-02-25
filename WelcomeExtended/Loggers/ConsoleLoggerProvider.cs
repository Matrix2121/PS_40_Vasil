using Microsoft.Extensions.Logging;
namespace WelcomeExtended.Loggers
{
    class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleHashLogger(categoryName);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
