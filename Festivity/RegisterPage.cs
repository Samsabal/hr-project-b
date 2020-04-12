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
    public class RegisterPage
    {
        public static void register_page()
        {
            register_user();
        }

        public static void register_user()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            Console.WriteLine("Enter firstName: ");
            var firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter lastName: ");
            var userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter email: ");
            var email = user_email_input(); // email loop functie
            Console.Clear();
            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();
            Console.Clear();
            var accountType = user_account_type_input(); //user account type functie
            Console.Clear();

            string contactPerson = null;
            string companyPhoneNumber = null;
            string companyName = null;

            string birthDate = null;
            bool newsLetter = false;
            string visitorPhoneNumber = null;

            if (accountType == 1) // Organisator
            {
                Console.WriteLine("Enter contactPerson: ");
                contactPerson = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter phoneNumber: ");
                companyPhoneNumber = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter companyName: ");
                companyName = Console.ReadLine();
                Console.Clear();
            }

            if (accountType == 2) // Visitor
            {
                Console.WriteLine("Enter birthDate: ");
                birthDate = Console.ReadLine();
                Console.Clear();
                newsLetter = user_news_letter_input();
                Console.WriteLine("Enter phoneNumber: ");
                visitorPhoneNumber = Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Enter country: ");
            var country = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter city: ");
            var city = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter streetName: ");
            var streetName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter streetNumber: ");
            var streetNumber = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter zipCode: ");
            var zipCode = Console.ReadLine();
            Console.Clear();

            user_terms_input();

            int accountID = user_account_id(users);


            User user = new User
            {
                accountType = accountType,
                accountID = accountID,
                firstName = firstName,
                lastName = userName,
                email = email,
                password = password,
                contactPerson = contactPerson,
                companyPhoneNumber = companyPhoneNumber,
                companyName = companyName,
                userAddress = {
                    country = country,
                    city = city,
                    streetName = streetName,
                    streetNumber = streetNumber,
                    zipCode = zipCode 
                },
                birthDate = birthDate,
                newsLetter = newsLetter,
                phoneNumber = visitorPhoneNumber
            };

            users.users.Add(user);

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            File.WriteAllText(PATH_USER, json);

            string user_email_input()
            {
                return Console.ReadLine();
            } // Tijdelijke email input functie

            int user_account_type_input()
            {
                int userOutput = 0;
                Console.WriteLine("Are you an Organisator or Visitor? ");
                Console.WriteLine();
                Console.WriteLine("Type 1 for Organisator");
                Console.WriteLine("Type 2 for Visitor\n");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    userOutput = 1;
                }
                else if (userInput == "2")
                {
                    userOutput = 2;
                }
                else
                {
                    Console.WriteLine("Please try again");
                    user_account_type_input();
                };

                return userOutput;
            }

            void user_terms_input()
            {
                Console.WriteLine("Do you accept the terms of use and conditions?");
                Console.WriteLine();
                Console.WriteLine("Type 1 for Yes");
                Console.WriteLine("Type 2 for No");
                string userInput = Console.ReadLine();
                if (userInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, you cannot create an account");
                    Thread.Sleep(5000);
                    Program.Main(new string[] { });
                    user_account_type_input();
                };
            }

            int user_account_id(JSONUserList users)
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

                return accountID;
            }

            bool user_news_letter_input()
            {
                bool userOutput = true;
                Console.WriteLine("\nDo you want to recieve newsletters?");
                Console.WriteLine();
                Console.WriteLine("Type 1 for Yes");
                Console.WriteLine("Type 2 for No");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    userOutput = true;
                }
                else if (userInput == "2")
                {
                    userOutput = false;
                }
                else
                {
                    Console.WriteLine("Please try again");
                    user_account_type_input();
                };

                return userOutput;
            }
        }
    }
}
