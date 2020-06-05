using System;

namespace Festivity
{
    class Error
    {
        public static void Write(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
