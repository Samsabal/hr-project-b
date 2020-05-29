using System;

namespace Festivity
{
    class ConsoleHelperFunctions
    {
        public static void ClearCurrentConsoleLine()
        {
            Console.CursorVisible = false;
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
            Console.CursorVisible = true;
        }

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
