using System;
using System.Threading;

namespace Festivity.AccountRegistration
{
    internal class Registration
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
        private static string userDateDay = "1";
        private static string userDateMonth = "1";
        private static string userDateYear = "1990";
        private static string visitorPhoneNumber;
        private static string country;
        private static string city;
        private static string streetName;
        private static string streetNumber;
        private static string zipCode;

        public static void CreateUser()
        {
            do { firstName = Utils.InputLoop("First name: "); }
            while (!RegexUtils.IsValidName(firstName));

            do { lastName = Utils.InputLoop("Last name: "); }
            while (!RegexUtils.IsValidName(lastName));

            do { email = Utils.InputLoop("Email: "); }
            while (!RegexUtils.IsValidEmail(email) || Utils.CheckIfEmailExists(email));

            do { userPassword = Utils.InputLoop("Password: "); }
            while (!RegexUtils.IsValidPassword(userPassword));

            UserAccountTypeInput();
            Console.Clear();

            if (userAccountType == 1) // Organisator
            {
                do { contactPerson = Utils.InputLoop("Company contactperson: "); }
                while (!RegexUtils.IsValidName(contactPerson));

                do { companyPhoneNumber = Utils.InputLoop("Company phone number: "); }
                while (!RegexUtils.IsValidPhoneNumber(companyPhoneNumber));

                do { companyName = Utils.InputLoop("Company name: "); }
                while (!RegexUtils.IsValidName(companyName));

                do { companyIBAN = Utils.InputLoop("Company IBAN (Example: 'NL99BANK0123456789'): "); }
                while (!RegexUtils.IsValidIBAN(companyIBAN));
            }

            if (userAccountType == 2) // Visitor
            {
                do { userDateDay = Utils.InputLoop("Day of birth: "); }
                while (!RegexUtils.IsValidDay(userDateDay));

                do { userDateMonth = Utils.InputLoop("Month of birth: "); }
                while (!RegexUtils.IsValidMonth(userDateMonth));

                do { userDateYear = Utils.InputLoop("Year of birth: "); }
                while (!RegexUtils.IsValidUserYear(userDateYear));

                do { visitorPhoneNumber = Utils.InputLoop("Phone number: "); }
                while (!RegexUtils.IsValidPhoneNumber(visitorPhoneNumber));

                UserNewsletterInput();
                Console.Clear();
            }
            do { country = Utils.InputLoop("Country: "); }
            while (!RegexUtils.IsValidAddressName(country));

            do { city = Utils.InputLoop("City: "); }
            while (!RegexUtils.IsValidAddressName(city));

            do { streetName = Utils.InputLoop("Streetname: "); }
            while (!RegexUtils.IsValidAddressName(streetName));

            do { streetNumber = Utils.InputLoop("Streetnumber: "); }
            while (!RegexUtils.IsValidStreetNumber(streetNumber));

            do { zipCode = Utils.InputLoop("ZipCode: "); }
            while (!RegexUtils.IsValidZipCode(zipCode));

            int accountID = JSONFunctionality.GenerateUserID();

            Console.WriteLine("Your account has been created, and you will be automatically logged in.");
            Thread.Sleep(1000);
            Console.Clear();

            DateTime birthDate = new DateTime(int.Parse(userDateYear), int.Parse(userDateMonth), int.Parse(userDateDay));

            UserModel user = new UserModel //Creates a new user object
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
                BirthDate = birthDate,
                NewsLetter = newsLetter,
                PhoneNumber = visitorPhoneNumber
            };
            ObjectSaver.Save(user);
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
                MenuFunction.Menu(new string[] { $"Yes, I want to recieve newsletters", "No, I don't want to recieve newsletters" });
            }
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