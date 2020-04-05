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

        static void Main(string[] args)
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            void homepage()
            {
                int Option = 0;
                string[] ConsoleOptions = new string[] { "Register", "Login", "Festivals", "Exit" };

                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < ConsoleOptions.Length; i++)
                    {
                        if (Option == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine("{0}.{1}", i, ConsoleOptions[i]);
                        if (Option == i)
                        {
                            Console.ResetColor();
                        }
                    }

                    var KeyPressed = Console.ReadKey();
                    // When DownArrow key is pressed go down.
                    if (KeyPressed.Key == ConsoleKey.DownArrow)
                    {
                        if (Option != ConsoleOptions.Length - 1)
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
                        switch (Option)
                        {
                            case 0: // Register option
                                Console.Clear();
                                RegisterPage.registerPage();
                                Thread.Sleep(10000);
                                break;
                            case 1: // Login option
                                Console.Clear();
                                LoginPage.loginPage();
                                Thread.Sleep(10000);
                                break;
                            case 2: // Festival option
                                Console.Clear();
                                Thread.Sleep(10000);
                                break;
                            case 3: // Exit option
                                Environment.Exit(0);
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


