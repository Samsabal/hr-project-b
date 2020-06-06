using System;

namespace Festivity
{
    /// <summary>
    /// Class containing functions for extended functionality of the console.
    /// </summary>
    internal class ConsoleHelperFunctions
    {
        /// <summary>
        /// Fills the current line in the console with whitespace.
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            Console.CursorVisible = false;
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Fills all lines in the console with whitespace.
        /// </summary>
        public static void ClearCurrentConsole()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                ClearCurrentConsoleLine();
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}