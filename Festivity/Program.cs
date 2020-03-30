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
                                register();
                                Thread.Sleep(10000);
                                break;
                            case 1: // Login option
                                Console.Clear();
                                login();
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

            void register()
            {
                int userID;
                if (users.users.Count == 0)
                {
                    userID = 1;
                }
                else
                {
                    int item = users.users[users.users.Count - 1].Id;
                    userID = item + 1;
                };

                Console.WriteLine("\nEnter Username: ");
                var userName = Console.ReadLine();
                Console.WriteLine("\nEnter Password: ");
                var userPassword = Console.ReadLine();

                User user = new User
                {
                    Id = userID,
                    Username = userName,
                    Password = userPassword,
                };

                users.users.Add(user);

                string json = JsonConvert.SerializeObject(users, Formatting.Indented);

                File.WriteAllText(PATH_USER, json);
            }

            void login()
            {
                int currentUser;
                bool exists = false;

                Console.WriteLine("\nEnter Username: ");
                var userName = Console.ReadLine();
                Console.WriteLine("\nEnter Password: ");
                var userPassword = Console.ReadLine();

                foreach (var user in users.users)
                {
                    if (user.Username == userName)
                    {
                        if (user.Password == userPassword)
                        {
                            exists = true;
                            currentUser = user.Id;
                            Console.WriteLine("You are logged in!");
                        }
                        else
                        {
                            Console.WriteLine("Wrong password!");
                        }
                    }
                }
                if (!exists)
                {
                    Console.WriteLine("\nAccount exists: " + exists + "!");
                }

            }
            homepage();

        }
    }
}


