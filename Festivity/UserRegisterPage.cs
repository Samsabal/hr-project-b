using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Festivity
{
    public class UserRegisterPage
    {
        public static int userAccountType = 0;
        public static int newsLetter = 0;
        public static int userTerms = 0;

        public static void register_page()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            string contactPerson = null;
            string companyPhoneNumber = null;
            string companyName = null;
            string companyIBAN = null;
            int userDateDay = 0;
            int userDateMonth = 0;
            int userDateYear = 0;
            string visitorPhoneNumber = null;
            string userPassword = null;
            string firstName = null;

            do
            {
                Console.Write("First name: "); firstName = Console.ReadLine();
                Console.Clear();
            } while (!RegexUtils.isValidName(firstName));

            Console.Clear();
            Console.WriteLine("Last name: \n");
            string lastName = Console.ReadLine();
            Console.Clear();
            var email = user_email_input();
            Console.Clear();

            do
            {
                Console.Write("Password: \n"); userPassword = Console.ReadLine();
                Console.Clear();
            } while (!RegexUtils.isValidPassword(userPassword));

            Console.Clear();
            user_account_type_input();

            if (userAccountType == 1) // Organisator
            {
                Console.Clear();
                Console.WriteLine("Company contactperson: \n");
                contactPerson = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Company phone number: \n");
                companyPhoneNumber = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Company name: \n");
                companyName = Console.ReadLine();
                Console.Clear();

                do
                {
                    Console.WriteLine("Company IBAN (Example: 'NL99BANK0123456789'): \n");
                    companyIBAN = Console.ReadLine();
                    Console.Clear();
                    if (RegexUtils.isValidIBAN(companyIBAN))
                    {
                        break;
                    }
                } while (true);
            }

            if (userAccountType == 2) // Visitor
            {
                Console.Clear();
                Console.WriteLine("Fill in your Date of Birth \n");
                Console.WriteLine("Day (DD): ");
                userDateDay = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Month (MM): ");
                userDateMonth = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Year (YYYY): ");
                userDateYear = int.Parse(Console.ReadLine());
                Console.Clear();
                user_newsletter_input();
                Console.Clear();
                Console.WriteLine("Phone number: \n");
                visitorPhoneNumber = Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Country: \n");
            var country = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("City: \n");
            var city = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Streetname: \n");
            var streetName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Streetnumber: \n");
            var streetNumber = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("ZipCode: \n");
            var zipCode = Console.ReadLine();
            Console.Clear();
            user_terms_input(); // User terms and conditions agreement
            int accountID = user_account_id(users);
            Console.WriteLine("Your account has been created, and you will be automatically logged in.");
            Thread.Sleep(1000);
            Console.Clear();

            write_user_to_database();

            void write_user_to_database()
            {
                User user = new User //Creates a new user object
                {
                    accountType = userAccountType,
                    accountID = accountID,
                    firstName = firstName,
                    lastName = lastName,
                    email = email,
                    password = userPassword,
                    contactPerson = contactPerson,
                    companyPhoneNumber = companyPhoneNumber,
                    companyName = companyName,
                    companyIBAN = companyIBAN,
                    userAddress = {
                        country = country,
                        city = city,
                        zipCode = zipCode,
                        streetName = streetName,
                        streetNumber = streetNumber
                        },
                    birthDate = {
                        day = userDateDay,
                        month = userDateMonth,
                        year = userDateYear
                    },
                    newsLetter = newsLetter,
                    phoneNumber = visitorPhoneNumber
                };

                UserLoginPage.currentUserType = user.accountType;
                users.users.Add(user);
                UserLoginPage.automaticLogin(user);
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(PATH_USER, json);
                // This block of code adds the user object to the json database.
            }

            string user_email_input()
            {
                Console.WriteLine("Email: \n");
                string userInput = Console.ReadLine();
                if (RegexUtils.isValidEmail(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Email invalid. Please try again");
                    user_email_input();
                }
                return "'user_email_input' return Error";
            }

            void user_newsletter_input()
            {
                MenuFunction.option = 0;
                while (newsLetter == 0)
                {
                    Console.WriteLine("Do you want to recieve a newsletter? \n");
                    MenuFunction.menu(new string[] { "Yes, I want to recieve a newsletters", "No, I don't want to recieve a newsletters" });
                }
            }

            void user_terms_input()
            {
                if (userAccountType == 1) //Print the organizational conditions here.
                {
                    while (userTerms == 0)
                    {
                        Console.WriteLine("Do you accept the terms of use and conditions?\n");
                        Console.WriteLine("'Print Terms of Conditions Organisator here'\n");
                        MenuFunction.menu(new string[] { "Yes, I accept the terms and conditions", "Exit to Main Menu" });
                    };
                }

                if (userAccountType == 2) //Print the user conditions here.
                {
                    while (userTerms == 0)
                    {
                        Console.WriteLine("Do you accept the terms of use and conditions?\n");
                        Console.WriteLine("'Print Terms of Conditions Visitor here'\n");
                        MenuFunction.menu(new string[] { "Yes, I accept the terms and conditions", "Exit to Main Menu" });
                    };
                }
                Console.Clear();
            }

            void user_account_type_input()
            {
                MenuFunction.option = 0;
                while (userAccountType == 0)
                {
                    Console.WriteLine("Are you an Organisator or Visitor? \n");
                    MenuFunction.menu(new string[] { "I am an Organisator", "I am a Visitor" });
                }
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
        }
    }
}