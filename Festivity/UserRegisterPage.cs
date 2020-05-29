using System;
using System.Threading;

namespace Festivity
{
    public class UserRegisterPage
    {
        private static int userAccountType;
        private static int newsLetter;
        private static bool userTerms = false;
        private static string firstName;
        private static string lastName;
        private static string email;
        private static string userPassword;
        private static string contactPerson;
        private static string companyPhoneNumber;
        private static string companyName;
        private static string companyIBAN;
        private static string userDateDay;
        private static string userDateMonth;
        private static string userDateYear;
        private static string visitorPhoneNumber;
        private static string country;
        private static string city;
        private static string streetName;
        private static string streetNumber;
        private static string zipCode;

        public static void createUser()
        {
            do { firstName = inputLoop("First name: "); }
            while (!RegexUtils.isValidName(firstName));

            do { lastName = inputLoop("Last name: "); }
            while (!RegexUtils.isValidName(lastName));

            do { email = inputLoop("Email: "); }
            while (!RegexUtils.isValidEmail(email));

            do { userPassword = inputLoop("Password: "); }
            while (!RegexUtils.isValidPassword(userPassword));

            userAccountTypeInput();
            Console.Clear();

            if (userAccountType == 1) // Organisator
            {
                do { contactPerson = inputLoop("Company contactperson: "); }
                while (!RegexUtils.isValidName(contactPerson));

                do { companyPhoneNumber = inputLoop("Company phone number: "); }
                while (!RegexUtils.isValidPhoneNumber(companyPhoneNumber));

                do { companyName = inputLoop("Company name: "); }
                while (!RegexUtils.isValidName(companyName));

                do { companyIBAN = inputLoop("Company IBAN (Example: 'NL99BANK0123456789'): "); }
                while (!RegexUtils.isValidIBAN(companyIBAN));
            }

            if (userAccountType == 2) // Visitor
            {
                do { userDateDay = inputLoop("Day of birth: "); }
                while (!RegexUtils.isValidUserDay(userDateDay));

                do { userDateMonth = inputLoop("Month of birth: "); }
                while (!RegexUtils.isValidUserMonth(userDateMonth));

                do { userDateYear = inputLoop("Year of birth: "); }
                while (!RegexUtils.isValidUserYear(userDateYear));

                do { visitorPhoneNumber = inputLoop("Phone number: "); }
                while (!RegexUtils.isValidPhoneNumber(visitorPhoneNumber));

                userNewsletterInput();
                Console.Clear();
            }
            do { country = inputLoop("Country: "); }
            while (!RegexUtils.isValidAddressName(country));

            do { city = inputLoop("City: "); }
            while (!RegexUtils.isValidAddressName(city));

            do { streetName = inputLoop("Streetname: "); }
            while (!RegexUtils.isValidAddressName(streetName));

            do { streetNumber = inputLoop("Streetnumber: "); }
            while (!RegexUtils.isValidStreetNumber(streetNumber));

            do { zipCode = inputLoop("ZipCode: "); }
            while (!RegexUtils.isValidZipCode(zipCode));

            userTermsInput(); // User terms and conditions agreement

            int accountID = JSONData.generateUserID();

            Console.WriteLine("Your account has been created, and you will be automatically logged in.");
            Thread.Sleep(1000);
            Console.Clear();

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
                        day = int.Parse(userDateDay),
                        month = int.Parse(userDateMonth),
                        year = int.Parse(userDateYear)
                    },
                newsLetter = newsLetter,
                phoneNumber = visitorPhoneNumber
            };
            writeToJson(user);
        }

        private static void writeToJson(User user)
        {
            JSONData.writeToUserDatabase(user);
            UserLoginPage.currentUserType = user.accountType;
            UserLoginPage.automaticLogin(user);
        }

        private static void userAccountTypeInput()
        {
            MenuFunction.option = 0;
            while (userAccountType == 0)
            {
                Console.WriteLine("Are you an Organisator or Visitor? \n");
                MenuFunction.menu(new string[] { $"I am an Organisator", "I am a Visitor" });
            }
        }

        private static void userNewsletterInput()
        {
            MenuFunction.option = 0;
            while (newsLetter == 0)
            {
                string test1 = "1";
                Console.WriteLine("Do you want to recieve a newsletter? \n");
                MenuFunction.menu(new string[] { $"Yes {test1}", "No, I don't want to recieve a newsletters" });
            }
        }

        private static void userTermsInput()
        {
            if (userAccountType == 1) //Print the organizational conditions here.
            {
                while (userTerms)
                {
                    string test2 = "2";
                    Console.WriteLine("Do you accept the terms of use and conditions?\n");
                    Console.WriteLine("'Print Terms of Conditions Organisator here'\n");
                    MenuFunction.menu(new string[] { $"Yes {test2}", "Exit to Main Menu" });
                };
            }

            if (userAccountType == 2) //Print the user conditions here.
            {
                while (true)
                {
                    Console.WriteLine("Do you accept the terms of use and conditions?\n");
                    Console.WriteLine("'Print Terms of Conditions Visitor here'\n");
                    MenuFunction.menu(new string[] { "Yes, I accept the terms and conditions", "Exit to Main Menu" });
                };
            }
            Console.Clear();
        }

        public static string inputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public static void setAccountType(int userType)
        {
            userAccountType = userType;
        }

        public static void setNewsLetter(int userChoice)
        {
            newsLetter = userChoice;
        }
        public static void acceptUserTerms()
        {
            userTerms = true;

        }
    }
}