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
                int accountID;
                if (users.users.Count == 0)
                {
                    accountID = 1;
                }
                else
                {
                    int item = users.users[users.users.Count - 1].accountID;
                    accountID = item + 1;
                };

                string userEmailInput()
                {
                    return "test";
                } // Tijdelijke email input functie

                int userAccountTypeInput()
                {
                    return 1;
                }

                Console.WriteLine("\nEnter firstName: ");
                var firstName = Console.ReadLine();
                Console.WriteLine("\nEnter lastName: ");
                var userName = Console.ReadLine();

                Console.WriteLine("\nEnter email: ");
                var email = userEmailInput(); // email loop functie

                Console.WriteLine("\nEnter password: ");
                var password = Console.ReadLine();

                Console.WriteLine("\nEnter accountType: ");
                var accountType = userAccountTypeInput(); //user account type functie

                Console.WriteLine("\nEnter contactPerson: ");
                var contactPerson = Console.ReadLine();

                Console.WriteLine("\nEnter phoneNumber: ");
                var phoneNumber = Console.ReadLine();

                Console.WriteLine("\nEnter companyName: ");
                var companyName = Console.ReadLine();

                Console.WriteLine("\nEnter country: ");
                var country = Console.ReadLine();

                Console.WriteLine("\nEnter city: ");
                var city = Console.ReadLine();

                Console.WriteLine("\nEnter streetName: ");
                var streetName = Console.ReadLine();

                Console.WriteLine("\nEnter streetNumber: ");
                var streetNumber = Console.ReadLine();

                Console.WriteLine("\nEnter zipCode: ");
                var zipCode = Console.ReadLine();



                UserOrganisator user = new UserOrganisator
                {
                    firstName = firstName,
                    lastName = userName,
                    email = email,
                    password = password,
                    accountType = accountType,
                    accountID = accountID,
                    contactPerson = contactPerson,
                    phoneNumber = phoneNumber,
                    companyName = companyName,
                    companyAddress = {
                        country = country,
                        city = city,
                        streetName = streetName,
                        streetNumber = streetNumber,
                        zipCode = zipCode
                    },
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
                    if (user.firstName == userName)
                    {
                        if (user.password == userPassword)
                        {
                            exists = true;
                            currentUser = user.accountID;
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


