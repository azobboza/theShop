using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.LoggerService
{
    public static class LoggerManager
    {
        public static void Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public static void Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public static void Debug(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }
}
