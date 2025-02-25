using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WelcomeExtended.Others
{
    class Delegates
    {
        public static readonly ILogger consoleLogger = LoggerHelper.GetConsoleLogger("Error");
        public static readonly ILogger fileLogger = LoggerHelper.GetFileLogger("Error");
        public static readonly ILogger LoginFileLogger = LoggerHelper.GetLoginFileLogger("Login");
        public static readonly ILogger DatabseLogger = LoggerHelper.GetDatabaseLogger("Log");

        public static void Log(string error)
        {
            consoleLogger.LogError(error);
            fileLogger.LogError(error);
        }
        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }
        public static void LogLogin(string user, string state)
        {
            string message = "Username: [" + user + "] - Login status: [" + state + "]";
            LoginFileLogger.LogInformation(message);
        }
        public static void LogDatabase(string message)
        {
            DatabseLogger.LogInformation(message);
        }
    }
}
