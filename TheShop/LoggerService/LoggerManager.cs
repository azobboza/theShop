using System;

namespace TheShop.LoggerService
{
    public static class LoggerManager
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public static void LogError(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public static void LogDebug(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }
}
