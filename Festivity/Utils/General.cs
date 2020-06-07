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
            Console.Clear();
            return userInput;
        }
    }
}
