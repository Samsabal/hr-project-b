using System;

namespace Festivity.Utils
{
    internal class General
    {
        public static string SetStringLength(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                return input.Substring(0, maxLength - 3) + "..";
            }
            else
            {
                return input.PadRight(maxLength);
            }
        }

        public static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            return userInput;
        }

        public static bool YesOrNoCheck(ConsoleKey input)
        {
            if (input != ConsoleKey.Y && input != ConsoleKey.N)
            {
                ErrorMessage.WriteLine("Wrong input, please press 'y' or 'n'");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string InputLoopString()
        {
            string userInput;
            userInput = Console.ReadLine();
            return userInput;
        }

        public static ConsoleKey InputLoopKey()
        {
            ConsoleKey userInput;
            userInput = Console.ReadKey(true).Key;
            return userInput;
        }
    }
}