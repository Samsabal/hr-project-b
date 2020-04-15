using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity
{
    class MenuFunction
    {
        public static void menu(string[] consoleOptions)
        {
            int option = 0;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("{0}.{1}", i, consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                var KeyPressed = Console.ReadKey();
                // When DownArrow key is pressed go down.
                if (KeyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (option != consoleOptions.Length - 1)
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
                    switch (consoleOptions[option])
                    {
                        case "Register": // Register option
                            Console.Clear();
                            RegisterPage.register_page();
                            Thread.Sleep(10000);
                            break;
                        case "Login": // Login option
                            Console.Clear();
                            LoginPage.login_page();
                            Thread.Sleep(10000);
                            break;
                        case "Festivals": // Festival option
                            Console.Clear();
                            CatalogPage.catalog_main();
                            Thread.Sleep(5000);
                            break;
                        case "Register Festival": // Festival register
                            Console.Clear();
                            FestivalRegister.festival_register();
                            Thread.Sleep(5000);
                            break;
                        case "Exit": // Exit option
                            Environment.Exit(0);
                            break;
                        case "Festival Page":
                            Console.Clear();
                            FestivalPage.festival_page();
                            Thread.Sleep(5000);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
