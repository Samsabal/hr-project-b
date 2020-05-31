using System;
using System.Threading;

namespace Festivity
{
    public class UserRegisterPage
    {
        private static int userAccountType;
        private static int newsLetter;
        private static string firstName;
        private static string lastName;
        private static string email;
        private static string userPassword;
        private static string contactPerson = null;
        private static string companyPhoneNumber = null;
        private static string companyName = null;
        private static string companyIBAN = null;
        private static string userDateDay = "0";
        private static string userDateMonth = "0";
        private static string userDateYear = "0";
        private static string visitorPhoneNumber;
        private static string country;
        private static string city;
        private static string streetName;
        private static string streetNumber;
        private static string zipCode;

        public static void CreateUser()
        {
            do { firstName = InputLoop("First name: "); }
            while (!RegexUtils.IsValidName(firstName));

            do { lastName = InputLoop("Last name: "); }
            while (!RegexUtils.IsValidName(lastName));

            do { email = InputLoop("Email: "); }
            while (!RegexUtils.IsValidEmail(email));

            do { userPassword = InputLoop("Password: "); }
            while (!RegexUtils.IsValidPassword(userPassword));

            UserAccountTypeInput();
            Console.Clear();

            if (userAccountType == 1) // Organisator
            {
                do { contactPerson = InputLoop("Company contactperson: "); }
                while (!RegexUtils.IsValidName(contactPerson));

                do { companyPhoneNumber = InputLoop("Company phone number: "); }
                while (!RegexUtils.IsValidPhoneNumber(companyPhoneNumber));

                do { companyName = InputLoop("Company name: "); }
                while (!RegexUtils.IsValidName(companyName));

                do { companyIBAN = InputLoop("Company IBAN (Example: 'NL99BANK0123456789'): "); }
                while (!RegexUtils.isValidIBAN(companyIBAN));
            }

            if (userAccountType == 2) // Visitor
            {
                do { userDateDay = InputLoop("Day of birth: "); }
                while (!RegexUtils.IsValidUserDay(userDateDay));

                do { userDateMonth = InputLoop("Month of birth: "); }
                while (!RegexUtils.IsValidUserMonth(userDateMonth));

                do { userDateYear = InputLoop("Year of birth: "); }
                while (!RegexUtils.IsValidUserYear(userDateYear));

                do { visitorPhoneNumber = InputLoop("Phone number: "); }
                while (!RegexUtils.IsValidPhoneNumber(visitorPhoneNumber));

                UserNewsletterInput();
                Console.Clear();
            }
            do { country = InputLoop("Country: "); }
            while (!RegexUtils.IsValidAddressName(country));

            do { city = InputLoop("City: "); }
            while (!RegexUtils.IsValidAddressName(city));

            do { streetName = InputLoop("Streetname: "); }
            while (!RegexUtils.IsValidAddressName(streetName));

            do { streetNumber = InputLoop("Streetnumber: "); }
            while (!RegexUtils.IsValidStreetNumber(streetNumber));

            do { zipCode = InputLoop("ZipCode: "); }
            while (!RegexUtils.IsValidZipCode(zipCode));

            int accountID = JSONFunctionality.GenerateUserID();

            Console.WriteLine("Your account has been created, and you will be automatically logged in.");
            Thread.Sleep(1000);
            Console.Clear();

            User user = new User //Creates a new user object
            {
                AccountType = userAccountType,
                AccountID = accountID,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = userPassword,
                ContactPerson = contactPerson,
                CompanyPhoneNumber = companyPhoneNumber,
                CompanyName = companyName,
                CompanyIBAN = companyIBAN,
                userAddress = {
                        Country = country,
                        City = city,
                        ZipCode = zipCode,
                        StreetName = streetName,
                        StreetNumber = streetNumber
                        },
                birthDate = {
                        Day = int.Parse(userDateDay),
                        Month = int.Parse(userDateMonth),
                        Year = int.Parse(userDateYear)
                    },
                NewsLetter = newsLetter,
                PhoneNumber = visitorPhoneNumber
            };
            WriteToJson(user);
        }

        private static void WriteToJson(User user)
        {
            JSONUserList users = JSONFunctionality.GetUsers();
            users.Users.Add(user);
            JSONFunctionality.WriteUsers(users);
            UserLoginPage.currentUserType = user.AccountType;
            UserLoginPage.AutomaticLogin(user);
        }

        private static void UserAccountTypeInput()
        {
            MenuFunction.option = 0;
            while (userAccountType == 0)
            {
                Console.WriteLine("Are you an Organisator or Visitor? \n");
                MenuFunction.Menu(new string[] { $"I am an Organisator", "I am a Visitor" });
            }
        }

        private static void UserNewsletterInput()
        {
            MenuFunction.option = 0;
            while (newsLetter == 0)
            {
                Console.WriteLine("Do you want to recieve a newsletter? \n");
                MenuFunction.Menu(new string[] { $"Yes, I want to recieve newsletters", "No, I don't want to recieve a newsletters" });
            }
        }

        public static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public static void SetAccountType(int userType)
        {
            userAccountType = userType;
        }

        public static void SetNewsLetter(int userChoice)
        {
            newsLetter = userChoice;
        }
    }
}