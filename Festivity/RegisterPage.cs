using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace Festivity
{
    public class RegisterPage
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
            int userDateDay = 0;
            int userDateMonth = 0;
            int userDateYear = 0;
            string visitorPhoneNumber = null;
            string userPassword = null;
            string firstName = null;

            do
            {
                Console.WriteLine("First name: \n");
                firstName = Console.ReadLine();
                Console.Clear();
                if (is_valid_name(firstName))
                {
                    break;
                }
            } while (true);

            Console.Clear();
            Console.WriteLine("Last name: \n");
            string lastName = Console.ReadLine();
            Console.Clear();
            var email = user_email_input();
            Console.Clear();
            do
            {
                Console.WriteLine("Password: \n");
                userPassword = Console.ReadLine();
                Console.Clear();
                if (is_valid_password(userPassword))
                {
                    break;
                }
            } while (true);

            Console.Clear();
            user_account_type_input();

            if (userAccountType == 1) // Organisator
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

            if (userAccountType == 2) // Visitor
            {
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
            Console.WriteLine("Your account has been created");
            Thread.Sleep(5000);
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

            bool is_valid_password(string password)
            /// string must be between 8 and 15 characters long. 
            /// string must contain at least one number. 
            /// string must contain at least one uppercase letter. 
            /// string must contain at least one lowercase letter.
            /// String must contain at least one symbol.
            {
                var input = password;
                
                if(string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Password should not be empty, please try again.\n");
                }

                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{8,15}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if ((!hasLowerChar.IsMatch(input)) || (!hasUpperChar.IsMatch(input)) || (!hasMiniMaxChars.IsMatch(input)) || (!hasSymbols.IsMatch(input)))
                {
                    Console.WriteLine("Password should contain the following rules: ");
                    Console.WriteLine(" - Must be between 8 and 15 characters long. ");
                    Console.WriteLine(" - Must contain at least one number. . ");
                    Console.WriteLine(" - Must contain at least one uppercase letter. ");
                    Console.WriteLine(" - Must contain at least one lowercase letter. ");
                    Console.WriteLine(" - Must contain at least one symbol. \n");
                    return false;
                }
                else
                {
                    return true;
                }
            }

            bool is_valid_name(string firstName)
            /// string must contain only characters. 
            /// string must be between 2 and 33 characters long. 
            {
                var input = firstName;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name should not be empty, please try again.\n");
                }

                var hasOnlyCharacter = new Regex(@"\b[A-Za-z]+\b");
                var hasMiniMaxChars = new Regex(@".{2,33}");

                if (!hasOnlyCharacter.IsMatch(input)) //Regex means only characters between 2-33 in lenght.
                {
                    Console.WriteLine("Name should contain only alphabethic characters.\n");
                    return false;
                }
                else if (!hasMiniMaxChars.IsMatch(input))
                {
                    Console.WriteLine("Name should not be lesser than 2 or greater than 33 characters .\n");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
