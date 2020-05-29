using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Festivity
{
    internal class UserAccountPage
    {
        private static string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
        private static JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

        public static void account_page()
        {
            foreach (var user in users.users)
            {
                if (UserLoginPage.currentUserId == user.accountID)
                {
                    MenuFunction.option = 0;
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your account Information: ");
                        Console.WriteLine();
                        Console.WriteLine($"    {user.firstName} {user.lastName}");
                        Console.WriteLine($"    {user.userAddress.streetName} {user.userAddress.streetNumber}");
                        Console.WriteLine($"    {user.userAddress.zipCode} {user.userAddress.city}");
                        Console.WriteLine($"    {user.email}");
                        Console.WriteLine("");
                        MenuFunction.menu(new string[] { "Change user information", "Change password", "Preference for e-mails", "Exit to Main Menu" });
                    }
                }
            }
        }

        public static void account_change_info()
        {
            foreach (var user in users.users)
            {
                if (UserLoginPage.currentUserId == user.accountID)
                {
                    Console.WriteLine();
                    Console.WriteLine("     Your account Information: ");
                    Console.WriteLine();
                    Console.WriteLine($"1.  Firstname:              {user.firstName}");
                    Console.WriteLine($"2.  Lastname:               {user.lastName}");
                    Console.WriteLine($"3.  Email:                  {user.email}");

                    if (UserLoginPage.currentUserType == 1) // Organisator
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"4.  Street address:         {user.userAddress.streetName} {user.userAddress.streetNumber}");
                        Console.WriteLine($"5.  City:                   {user.userAddress.city}");
                        Console.WriteLine($"6.  ZipCode:                {user.userAddress.zipCode}");
                        Console.WriteLine($"7.  Country:                {user.userAddress.country}");
                        Console.WriteLine("");
                        Console.WriteLine($"8.  Company name:           {user.companyName}");
                        Console.WriteLine($"9.  Company phonenumber:    {user.companyPhoneNumber}\n");
                        Console.WriteLine("");
                    }
                    if (UserLoginPage.currentUserType == 2) // Festival goer
                    {
                        Console.WriteLine($"4.  Phonenumber:            {user.phoneNumber}");
                        Console.WriteLine($"5.  Street address:         {user.userAddress.streetName} {user.userAddress.streetNumber}");
                        Console.WriteLine($"6.  City:                   {user.userAddress.city}");
                        Console.WriteLine($"7.  ZipCode:                {user.userAddress.zipCode}");
                        Console.WriteLine($"8.  Country:                {user.userAddress.country}\n");
                        Console.WriteLine("");
                    }
                    int userInput;
                    Console.Write("Enter the number and press <Enter>: ");
                    while (!int.TryParse(Console.ReadLine(), out userInput))
                    {
                        Console.Clear();
                        Console.WriteLine("You entered an invalid number");
                        Console.Write("Enter the number and press <Enter>: ");
                    }
                    if (userInput > 0 && userInput <= 8)
                    {
                        account_change_organisator(userInput);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
        }

        public static void account_email_prefference()
        {
            foreach (var user in users.users)
            {
                if (UserLoginPage.currentUserId == user.accountID)
                {
                    if (user.newsLetter == 1)
                    {
                        Console.WriteLine("Do you want to stop recieving Newsletters? [Y or N].");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "y")
                        {
                            Console.Clear();
                            user.newsLetter = 0;
                            Console.WriteLine("Preference successfully changed.");
                            Thread.Sleep(1000);
                            Console.Clear();
                        } else if (userInput.ToLower() != "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input, please try again.");
                            account_email_prefference();
                        }
                    }
                    else if (user.newsLetter == 0)
                    {
                        Console.WriteLine("Do you want to recieve Newsletters? [Y or N]");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "y")
                        {
                            Console.Clear();
                            user.newsLetter = 1;
                            Console.WriteLine("Preference successfully changed.");
                            Thread.Sleep(1000);
                        }
                        else if (userInput.ToLower() != "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input, please try again.");
                            account_email_prefference();
                        }
                    }
                }
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(PATH_USER, json);
        }

        public static void account_change_organisator(int userSelection)
        {
            string userInput;

            foreach (var user in users.users)
            {
                if (UserLoginPage.currentUserId == user.accountID)
                {
                    if (UserLoginPage.currentUserType == 1)
                    {
                        switch (userSelection)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Input new firstname: ");
                                userInput = Console.ReadLine();
                                user.firstName = userInput;
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Input new lastname: ");
                                userInput = Console.ReadLine();
                                user.lastName = userInput;
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Input new email: ");
                                userInput = Console.ReadLine();
                                user.email = userInput;
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("Input new streetname: ");
                                string userInput1 = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Input new streetnumber: ");
                                string userInput2 = Console.ReadLine();
                                user.userAddress.streetName = userInput1;
                                user.userAddress.streetNumber = userInput2;
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("Input new city: ");
                                userInput = Console.ReadLine();
                                user.userAddress.city = userInput;
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("Input new zipcode: ");
                                userInput = Console.ReadLine();
                                user.userAddress.zipCode = userInput;
                                break;

                            case 7:
                                Console.Clear();
                                Console.WriteLine("Input new country: ");
                                userInput = Console.ReadLine();
                                user.userAddress.country = userInput;
                                break;

                            case 8:
                                Console.Clear();
                                Console.WriteLine("Input new companyname: ");
                                userInput = Console.ReadLine();
                                user.companyName = userInput;
                                break;

                            case 9:
                                Console.Clear();
                                Console.WriteLine("Input new companynumber: ");
                                userInput = Console.ReadLine();
                                user.companyPhoneNumber = userInput;
                                break;

                            default:
                                break;
                        }
                    }
                    if (UserLoginPage.currentUserType == 2) // Festival Goer
                    {
                        switch (userSelection)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Input new firstname: ");
                                userInput = Console.ReadLine();
                                user.firstName = userInput;
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Input new lastname: ");
                                userInput = Console.ReadLine();
                                user.lastName = userInput;
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Input new email: ");
                                userInput = Console.ReadLine();
                                user.email = userInput;
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("Input new phoneNumber: ");
                                userInput = Console.ReadLine();
                                user.phoneNumber = userInput;
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("Input new streetname: ");
                                string userInput1 = Console.ReadLine();
                                Console.WriteLine("Input new streetnumber: ");
                                string userInput2 = Console.ReadLine();
                                user.userAddress.streetName = userInput1;
                                user.userAddress.streetNumber = userInput2;
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("Input new city: ");
                                userInput = Console.ReadLine();
                                user.userAddress.city = userInput;
                                break;

                            case 7:
                                Console.Clear();
                                Console.WriteLine("Input new zipcode: ");
                                userInput = Console.ReadLine();
                                user.userAddress.zipCode = userInput;
                                break;

                            case 8:
                                Console.Clear();
                                Console.WriteLine("Input new country: ");
                                userInput = Console.ReadLine();
                                user.userAddress.country = userInput;
                                break;

                            default:
                                break;
                        }
                    }
                    string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                    File.WriteAllText(PATH_USER, json);
                }
            }
        }

        public static void change_password()
        {
            string userInput;

            foreach (var user in users.users)
            {
                if (UserLoginPage.currentUserId == user.accountID)
                {
                    Console.WriteLine("Input current password: ");
                    userInput = Console.ReadLine();
                    Console.Clear();
                    if (userInput == user.password)
                    {
                        Console.WriteLine("Input new password: ");
                        string userInput1 = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Input new password again: ");
                        string userInput2 = Console.ReadLine();
                        Console.Clear();
                        if (userInput1 == userInput2)
                        {
                            user.password = userInput2;
                            Console.WriteLine("Password successfully changed.");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("Passwords do not match, please try again.");
                            change_password();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid password, please try again.");
                        change_password();
                    }
                }
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(PATH_USER, json);
        }
    }
}