using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class Menu
    {
        private static UIElements UI = new UIElements();
        private static int Option { get; set; }

        public static void Draw(List<MenuOption> consoleOptions)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < consoleOptions.Count; i++)
            {
                if (Option == i)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine("{0}", consoleOptions[i].Name);
                if (Option == i)
                {
                    Console.ResetColor();
                }
            }
            UI.Line(); 

            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (Option != consoleOptions.Count - 1)
                {
                    Option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (Option != 0)
                {
                    Option--;
                }
            }

            // When Enter key is pressed execute selected option.
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                Console.CursorVisible = true;
                consoleOptions[Option].Select();
            }
            Console.SetCursorPosition(0, 0);
        }

        public static int OptionReset()
        {
            return Option = 0;
        }
    }
}