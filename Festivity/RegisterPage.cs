using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Festivity
{
    public class RegisterPage
    {
        public static void register_page()
        {
            register_user();
            Program.Main(new string[] { });
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

            Console.WriteLine("First name: \n");
            var firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Last name: \n");
            var userName = Console.ReadLine();
            Console.Clear();
            var email = user_email_input();
            Console.Clear();
            Console.WriteLine("Password: \n");
            var password = Console.ReadLine();
            Console.Clear();
            var accountType = user_account_type_input();
            Console.Clear();

            if (accountType == 1) // Organisator
            {
                Console.WriteLine("Company contactperson: \n");
                contactPerson = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Company phone number: \n");
                companyPhoneNumber = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Company name: \n");
                companyName = Console.ReadLine();
                Console.Clear();
            }

            if (accountType == 2) // Visitor
            {
                Console.WriteLine("Date of Birth: \n");
                birthDate = Console.ReadLine();
                Console.Clear();
                newsLetter = user_news_letter_input();
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

            Console.WriteLine("Your account has been created");
            Thread.Sleep(5000);
            write_user_to_database();

            void write_user_to_database()
            {
                User user = new User //Creates a new user object
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
                        zipCode = zipCode,
                        streetName = streetName,
                        streetNumber = streetNumber
                        },
                    birthDate = birthDate,
                    newsLetter = newsLetter,
                    phoneNumber = visitorPhoneNumber
                };

                users.users.Add(user);
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(PATH_USER, json);
                // This block of code adds the user object to the json database.\ 
            }

            string user_email_input()
            {
                Console.WriteLine("Email: \n");
                string userInput = Console.ReadLine();
                if (is_valid_email(userInput))
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

            int user_account_type_input()
            {
                int userOutput = 0;
                Console.WriteLine("Are you an Organisator or Visitor? ");
                Console.WriteLine();
                Console.WriteLine("Type 1 for Organisator");
                Console.WriteLine("Type 2 for Visitor\n");
                string userInput = Console.ReadLine();
                Console.Clear();
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
                string userInput = null;
                if (accountType == 1) //Print the organizational conditions here.
                {
                    Console.WriteLine("Do you accept the terms of use and conditions? Company Boy");
                    Console.WriteLine();
                    Console.WriteLine("Type 1 for Yes");
                    Console.WriteLine("Type 2 for No\n");
                    userInput = Console.ReadLine();
                    Console.Clear();
                }

                if (accountType == 2) //Print the user conditions here.
                {
                    Console.WriteLine("Do you accept the terms of use and conditions? Visitor Boy");
                    Console.WriteLine();
                    Console.WriteLine("Type 1 for Yes");
                    Console.WriteLine("Type 2 for No\n");
                    userInput = Console.ReadLine();
                    Console.Clear();
                }
                Console.Clear();

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
                Console.WriteLine("Do you want to recieve newsletters?");
                Console.WriteLine();
                Console.WriteLine("Type 1 for Yes");
                Console.WriteLine("Type 2 for No\n");
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
                    Console.Clear();
                    Console.WriteLine("Please try again");
                    user_account_type_input();
                };

                return userOutput;
            }

            bool is_valid_email(string email) // This method does not perform authentication to validate the email address. It determines whether its format is valid for an email address.
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    // Normalize the domain
                    email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    // Examines the domain part of the email and normalizes it.
                    string DomainMapper(Match match)
                    {
                        // Use IdnMapping class to convert Unicode domain names.
                        var idn = new IdnMapping();

                        // Pull out and process domain name (throws ArgumentException on invalid)
                        var domainName = idn.GetAscii(match.Groups[2].Value);

                        return match.Groups[1].Value + domainName;
                    }
                }
                catch (RegexMatchTimeoutException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }

                try
                {
                    return Regex.IsMatch(email,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }
        }
    }
}
