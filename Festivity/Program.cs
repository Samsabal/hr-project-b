using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace Festivity
{
    class Program
    {
    
        public static void Main(string[] args)
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            Console.SetWindowSize(150, 35);
            void homepage()
            {
                int Option = 0;
                string[] ConsoleOptions = new string[] { "Register", "Login", "Festivals", "Register festival", "Exit", "Festival Page" };

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
                        switch (option)
                        {
                            case 0: // Register option
                                Console.Clear();
                                RegisterPage.register_page();
                                Thread.Sleep(10000);
                                break;
                            case 1: // Login option
                                Console.Clear();
                                LoginPage.login_page();
                                Thread.Sleep(10000);
                                break;
                            case 2: // Festival option
                                Console.Clear();
                                //CatalogPage.catalog_main();
                                Thread.Sleep(10000);
                                break;
                            case 3: // Festival register
                                Console.Clear();
                                FestivalRegister.festival_register();
                                Thread.Sleep(10000);
                                break;
                            case 4: // Exit option
                                Environment.Exit(0);
                                break;
                            case 5:
                                Console.Clear();
                                FestivalPage.festival_page();
                                Thread.Sleep(100000);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }


            homepage();
         
        }
    }
}


