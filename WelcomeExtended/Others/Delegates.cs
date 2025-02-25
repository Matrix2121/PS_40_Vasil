using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WelcomeExtended.Others
{
    class Delegates
    {
        public static readonly ILogger consoleLogger = LoggerHelper.GetConsoleLogger("Error");
        public static readonly ILogger fileLogger = LoggerHelper.GetFileLogger("Error");
        public static readonly ILogger successfulLoginFileLogger = LoggerHelper.GetSuccessfulLoginFileLogger("Login");
        public static readonly ILogger unsuccessfulLoginFileLogger = LoggerHelper.GetUnsuccessfulLoginFileLogger("Login");

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
        public static void LogSuccessfulLogin(string user, bool state)
        {
            string message = "Username: [" + user + "] - Login status: [" + (state ? "Success" : "Failed") + "]";
            successfulLoginFileLogger.LogInformation(message);
        }
        public static void LogUnsuccessfulLogin(string user)
        {
            string message = "Username: [" + user + "] This user is not found";
            unsuccessfulLoginFileLogger.LogInformation(message);
        }
    }
}
