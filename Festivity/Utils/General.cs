using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Utils
{
    class General
    {
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
