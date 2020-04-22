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
        public static int userAccountType;

        public static void register_page()
        {
            register_user();
        }

        public static void register_user()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            string contactPerson = null;
            string companyPhoneNumber = null;
            string companyName = null;

            string birthDate = null;
            bool newsLetter = false;
            string visitorPhoneNumber = null;

            Console.WriteLine("\nEnter firstName: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("\nEnter lastName: ");
            var userName = Console.ReadLine();
            Console.WriteLine("\nEnter email: ");
            var email = user_email_input(); // email loop functie
            Console.WriteLine("\nEnter password: ");
            var password = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("\nAre you an Organisator or Visitor? ");
                Menu.menu(new string[] { "RegisterOrganisator", "RegisterVisitor" });
            }



            if (userAccountType == 1) // Organisator
            {
                Console.WriteLine("\nEnter contactPerson: ");
                contactPerson = Console.ReadLine();
                Console.WriteLine("\nEnter phoneNumber: ");
                companyPhoneNumber = Console.ReadLine();
                Console.WriteLine("\nEnter companyName: ");
                companyName = Console.ReadLine();
            }

            if (userAccountType == 2) // Visitor
            {
                Console.WriteLine("\nEnter birthDate: ");
                birthDate = Console.ReadLine();
                newsLetter = user_news_letter_input();
                Console.WriteLine("\nEnter phoneNumber: ");
                visitorPhoneNumber = Console.ReadLine();
            }

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

            int accountID = user_account_id(users);


            User user = new User
            {
                accountType = userAccountType,
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

            void user_account_type_input()
            {
                Console.WriteLine("\nAre you an Organisator or Visitor? ");
                string[] consoleOptions = new string[] { "RegisterOrganisator", "RegisterVisitor"};
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
