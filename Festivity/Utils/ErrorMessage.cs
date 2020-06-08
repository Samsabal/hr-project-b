using System;
using System.Threading;

namespace Festivity
{
    internal class ErrorMessage
    {
        public static void WriteLine(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        public static void Write(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(errorMessage);
            Console.ResetColor();
        }

        public static void NoFilterMatchesError()
        {
            Console.Clear();
            Write("No festivals match your search conditions\n\nyou will be returned to the catalog in a couple of seconds");
            Thread.Sleep(5000);
        }
    }
}