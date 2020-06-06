using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class Menu
    {
        public static int option;

        public static void Draw(List<MenuOption> consoleOptions)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < consoleOptions.Count; i++)
            {
                if (option == i)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine("{0}", consoleOptions[i].Name);
                if (option == i)
                {
                    Console.ResetColor();
                }
            }

            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (option != consoleOptions.Count - 1)
                {
                    option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (option != 0)
                {
                    option--;
                }
            }

            // When Enter key is pressed execute selected option.
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                Console.CursorVisible = true;
                consoleOptions[option].Select();
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}