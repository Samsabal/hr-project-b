using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class Menu
    {
        public static int option;

        public static void Draw(List<MenuOption> consoleOptions, object[] objects = null)
        {
            Console.CursorVisible = false;
            /// 1. Add your option as string in consoleOptions argument.
            /// 2. (optional) Add a second array that contains objects to display dynamic names of options in objects argument.
            /// 3. Add your extra "option" as a new case inside the switch statement with the correct function.
            if (objects == null)
            {
                {
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
                }
            }
            else if (objects[0].GetType() == typeof(Festival))
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Festival tempfestival = (Festival)objects[i];

                    Console.WriteLine("Select festival: {0}", tempfestival.FestivalName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = objects.Length; i < consoleOptions.Count; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
            }
            else if (objects[0].GetType() == typeof(Ticket))
            {
                for (int i = 0; i < TicketBuy.GetTicketListLength(); i++)
                {
                    ConsoleHelperFunctions.ClearCurrentConsoleLine();
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Ticket tempticket = (Ticket)objects[i];

                    Console.WriteLine("Buy Ticket: {0}", tempticket.TicketName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = TicketBuy.GetTicketListLength(); i < consoleOptions.Count; i++)
                {
                    ConsoleHelperFunctions.ClearCurrentConsoleLine();
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
                ConsoleHelperFunctions.ClearCurrentConsoleLine();
            }
            else
            {
                for (int i = 0; i < consoleOptions.Count; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
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