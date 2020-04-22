using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity
{
    class Menu
    {
        public static void menu(string[] consoleOptions)
        {
            int option = 0;

            //while (true)
            
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
                        case "Register":
                            //Console.Clear();
                            RegisterPage.register_page();
                            Thread.Sleep(5000);
                            break;
                        case "Login":
                            //Console.Clear();
                            LoginPage.login_page();
                            Thread.Sleep(5000);
                            break;
                        case "Festivals": 
                            Console.Clear();
                            CatalogPage.catalog_main();
                            Thread.Sleep(5000);
                            break;
                        case "Register festival": // Festival register
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
                        case "RegisterOrganisator":
                            //Console.Clear();
                            //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                            RegisterPage.userAccountType = 1;
                            Thread.Sleep(5000);
                            break;
                        case "RegisterVisitor":
                            //Console.Clear();
                            //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                            RegisterPage.userAccountType = 2;
                            Thread.Sleep(5000);
                            break;
                        case "TestMenu3":
                            Console.Clear();
                            CatalogPage.catalog_main();
                            Thread.Sleep(5000);
                            break;
                        case "TestMenu4":
                            Console.Clear();
                            CatalogPage.catalog_main();
                            Thread.Sleep(5000);
                            break;
                        case "Omegalul":
                            Console.Clear();
                            CatalogPage.catalog_main();
                            Thread.Sleep(5000);
                            break;
                        default:
                            break;
                    }
                }
           
        }

    }
}

