using Festivity.Utils;
using System;

namespace Festivity.AccountRegistration
{
    internal class Reader
    {
        public static void InputFirstName(UserModel user)
        {
            do { user.FirstName = General.InputLoop(" First name: "); }
            while (!RegexUtils.IsValidName(user.FirstName));
        }

        public static void InputLastName(UserModel user)
        {
            do { user.LastName = General.InputLoop(" Last name: "); }
            while (!RegexUtils.IsValidName(user.LastName));
        }

        public static void InputEmail(UserModel user)
        {
            do { user.Email = General.InputLoop(" Email: "); }
            while (!RegexUtils.IsValidEmail(user.Email) || Handler.CheckIfEmailExists(user.Email));
        }

        public static void InputPassword(UserModel user)
        {
            do { user.Password = General.InputLoop(" Password: "); }
            while (!RegexUtils.IsValidPassword(user.Password));
        }

        public static void InputCompanyContactperson(UserModel user)
        {
            do { user.ContactPerson = General.InputLoop(" Company contactperson: "); }
            while (!RegexUtils.IsValidName(user.ContactPerson));
        }

        public static void InputCompanyPhonenumber(UserModel user)
        {
            do { user.CompanyPhoneNumber = General.InputLoop(" Company phone number: "); }
            while (!RegexUtils.IsValidPhoneNumber(user.CompanyPhoneNumber));
        }

        public static void InputCompanyName(UserModel user)
        {
            do { user.CompanyName = General.InputLoop(" Company name: "); }
            while (!RegexUtils.IsValidName(user.CompanyName));
        }

        public static void InputIBAN(UserModel user)
        {
            do { user.CompanyIBAN = General.InputLoop(" Company IBAN (Example: 'NL99BANK0123456789'): "); }
            while (!RegexUtils.IsValidIBAN(user.CompanyIBAN));
        }

        public static void InputBirthday(UserModel user)
        {
            string userDay;
            string userMonth;
            string userYear;

            do { userDay = General.InputLoop(" Day of birth: "); }
            while (!RegexUtils.IsValidDay(userDay));

            do { userMonth = General.InputLoop(" Month of birth: "); }
            while (!RegexUtils.IsValidMonth(userMonth));

            do { userYear = General.InputLoop(" Year of birth: "); }
            while (!RegexUtils.IsValidUserYear(userYear));
            try
            {
                user.BirthDate = new DateTime(int.Parse(userYear), int.Parse(userMonth), int.Parse(userDay));
            } catch (ArgumentOutOfRangeException e)
            {
                ErrorMessage.InvalidDateError();
                InputBirthday(user);
            }
        }

        public static void InputVisitorPhonenumber(UserModel user)
        {
            do { user.PhoneNumber = General.InputLoop(" Phone number: "); }
            while (!RegexUtils.IsValidPhoneNumber(user.PhoneNumber));
        }

        public static void InputCompanyPhoneNumber(UserModel user)
        {
            do { user.CompanyPhoneNumber = General.InputLoop(" Phone number: "); }
            while (!RegexUtils.IsValidPhoneNumber(user.CompanyPhoneNumber));
        }

        public static void InputAccountType(UserModel user)
        {
            string input;

            do { input = General.InputLoop(" Are you a visitor or an organiser? (visitor/organiser): "); }
            while (!RegexUtils.isValidVisitorOrOrganiser(input));

            if (Handler.IsInputVisitor(input))
            {
                user.AccountType = 2;
            }
            else { user.AccountType = 1; }
        }

        public static void InputNewsLetter(UserModel user)
        {
            string input;
            do { input = General.InputLoop(" Do you want to recieve our newsletter?(yes/no): "); }
            while (!RegexUtils.IsValidYesOrNo(input));

            user.NewsLetter = Handler.IsInputYes(input);
        }

        public static void InputUserAdress(UserModel user)
        {
            AddressModel address = new AddressModel();

            do { address.Country = General.InputLoop(" Country: "); }
            while (!RegexUtils.IsValidAddressName(address.Country));

            do { address.City = General.InputLoop(" City: "); }
            while (!RegexUtils.IsValidAddressName(address.City));

            do { address.ZipCode = General.InputLoop(" Zipcode: "); }
            while (!RegexUtils.IsValidZipCode(address.ZipCode));

            do { address.StreetName = General.InputLoop(" Streetname: "); }
            while (!RegexUtils.IsValidAddressName(address.StreetName));

            do { address.StreetNumber = General.InputLoop(" House number: "); }
            while (!RegexUtils.IsValidStreetNumber(address.StreetNumber));

            user.userAddress = address;
            ConsoleHelperFunctions.ClearCurrentConsole();
        }
    }
}