using System;
using System.Text.RegularExpressions;

namespace Festivity
{
    public class RegexUtils
    {
        public static bool NumberCheck(string value, int min, int max)
        {
            if (Int32.TryParse(value, out int result))
            {
                if (result >= min && result <= max)
                {
                    return true;
                }
                Console.WriteLine("Invalid input, please  try again");
                return false;
            }
            return false;
        }

        static private bool RegexCheck(string input, Regex regex)
        {
            if (!regex.IsMatch(input))
            {
                Console.WriteLine("Invalid Input, please try again");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidName(string name)
        {
            return RegexCheck(name, new Regex(@"\b[A-Za-z]{2,33}\b"));
        }

        public static bool isValidIBAN(string IBAN)
        /// First two characters must be 'NL'
        /// 3rd and 4th characters must be 2 numbers
        /// 5th to 8th characters must be 4 letters
        /// 9th to 18th characters must be 10 numbers
        {
            return RegexCheck(IBAN, new Regex(@"NL[0-9]{2}[A-Z]{4}[0-9]{10}"));
        }

        public static bool IsValidUserDay(string day)
        {
            return NumberCheck(day, 0, 31);
        }

        public static bool IsValidUserMonth(string month)
        {
            return NumberCheck(month, 0, 12);
        }

        public static bool IsValidUserYear(string year)
        {
            return NumberCheck(year, 1900, DateTime.Now.Year);
        }

        public static bool IsValidFestivalDay(string day)
        {
            return NumberCheck(day, 0, 31);
        }

        public static bool IsValidFestivalMonth(string month)
        {
            return NumberCheck(month, 0, 12);
        }

        public static bool IsValidFestivalYear(string year)
        {
            return NumberCheck(year, DateTime.Now.Year, 2050);
        }

        public static bool IsValidAddressName(string addressName)
        {
            return RegexCheck(addressName, new Regex(@"^[A-Za-z ]{1,60}$"));
        }

        public static bool IsValidZipCode(string zipCode)
        {
            return RegexCheck(zipCode, new Regex(@"^[0-9]{4}[A-Za-z]{2}$"));
        }

        public static bool IsValidStreetNumber(string streetNumber)
        {
            return RegexCheck(streetNumber, new Regex(@"^[0-9]{1,4}([A-Za-z]{1,2})?$"));
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return RegexCheck(phoneNumber, new Regex(@"^06\d{8}$"));
        }

        public static bool IsValidTimeFormat(string time)
        {
            return RegexCheck(time, new Regex(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$"));
        }

        public static bool IsValidDescription(string addressName)
        {
            return RegexCheck(addressName, new Regex(@"^[A-Za-z]{1,500}$"));
        }

        public static bool IsValidCancelTime(string cancelTime)
        {
            return NumberCheck(cancelTime, 0, 52);
        }

        public static bool IsValidAge(string age)
        {
            return NumberCheck(age, 0, 120);
        }

        public static bool IsValidEmail(string email)
        /// Uses Sysem class MailAddress to determine whether an email address is valid.
        {
            var isValidEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            return RegexCheck(email, isValidEmail);
        }

        public static bool IsValidPassword(string password)
        /// string must be between 8 and 15 characters long.
        /// string must contain at least one number.
        /// string must contain at least one uppercase letter.
        /// string must contain at least one lowercase letter.
        /// String must contain at least one symbol.
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(password) || !hasUpperChar.IsMatch(password) || !hasMiniMaxChars.IsMatch(password) || !hasSymbols.IsMatch(password) || !hasNumber.IsMatch(password))
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
    }
}