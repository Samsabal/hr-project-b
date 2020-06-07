using System;

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
    }
}