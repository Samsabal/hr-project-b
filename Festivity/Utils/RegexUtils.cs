using System;
using System.Text.RegularExpressions;

namespace Festivity
{
    /// <summary> Class containing all the Regex functions </summary>
    public class RegexUtils
    {
        /// <summary>
        /// Takes a string containing an integer and checks if it's value is between the given min
        /// and max.
        /// </summary>
        /// <param name="value"> String containing integer to be checked. </param>
        /// <param name="min"> int with minimum value to be checked for. </param>
        /// <param name="max"> int with maximum value to be checked for. </param>
        /// <returns>
        /// Returns true if the given string value is in between the given min and max.
        /// </returns>
        public static bool NumberCheck(string value, int min, int max)
        {
            if (Int32.TryParse(value, out int result))
            {
                if (result >= min && result <= max)
                {
                    return true;
                }
                ErrorMessage.WriteLine("Invalid input, please  try again");
                return false;
            }
            return false;
        }

        /// <summary> Checks if a given input conforms to the given regex. </summary>
        /// <param name="input"> String to be checked. </param>
        /// <param name="regex"> Regex to check with. </param>
        /// <returns> Returns true if the given string conforms to the given Regex. </returns>
        static private bool RegexCheck(string input, Regex regex)
        {
            if (!regex.IsMatch(input))
            {
                ErrorMessage.WriteLine("Invalid input, please  try again");
                return false;
            }
            else
            {
                return true;
            }
        }

        static private bool RegexCheckNoError(string input, Regex regex)
        {
            if (!regex.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary> Checks if string conforms to a name structure </summary>
        /// <param name="name"> Name to check </param>
        /// <returns> Returns true if name conforms to regex. </returns>
        public static bool IsValidName(string name)
        {
            return RegexCheck(name, new Regex(@"^[A-Za-z,.' -]{2,33}$"));
        }

        public static bool IsValidYesOrNo(string name)
        {
            return RegexCheck(name, new Regex(@"^[Y-y][E-e][S-s]|[N-n][O-o]$"));
        }

        public static bool EqualsYesRegex(string input)
        {
            return RegexCheckNoError(input, new Regex(@"^[Y-y][E-e][S-s]$"));
        }

        /// <summary> Checks if string conforms to an IBAN structure </summary>
        /// <param name="IBAN"> IBAN to check </param>
        /// <returns> Returns true if IBAN conforms to regex. </returns>
        public static bool IsValidIBAN(string IBAN)
        /// First two characters must be 'NL' 3rd and 4th characters must be 2 numbers 5th to 8th
        /// characters must be 4 letters 9th to 18th characters must be 10 numbers
        {
            return RegexCheck(IBAN, new Regex(@"NL[0-9]{2}[A-Z]{4}[0-9]{10}"));
        }

        /// <summary> Checks if string conforms to a day structure. </summary>
        /// <param name="day"> day to check. </param>
        /// <returns> Returns true if day is a real day. </returns>
        public static bool IsValidDay(string day)
        {
            return NumberCheck(day, 0, 31);
        }

        /// <summary> Checks if string conforms to a month structure. </summary>
        /// <param name="month"> month to check </param>
        /// <returns> Returns true if month is a real month. </returns>
        public static bool IsValidMonth(string month)
        {
            return NumberCheck(month, 0, 12);
        }

        /// <summary> Checks if string conforms to a year structure for user age. </summary>
        /// <param name="year"> year to check </param>
        /// <returns> Returns true if year is a real year between 1900 and now. </returns>
        public static bool IsValidUserYear(string year)
        {
            return NumberCheck(year, 1900, DateTime.Now.Year);
        }

        /// <summary> Checks if string conforms to a year structure for festival date. </summary>
        /// <param name="year"> year to check. </param>
        /// <returns> Returns true if year is a real year between now and 2050. </returns>
        public static bool IsValidFestivalYear(string year)
        {
            return NumberCheck(year, DateTime.Now.Year, 2050);
        }

        /// <summary> Checks if string conforms to address structure. </summary>
        /// <param name="addressName"> Address to check. </param>
        /// <returns> Returns true if addressName conforms to regex. </returns>
        public static bool IsValidAddressName(string addressName)
        {
            return RegexCheck(addressName, new Regex(@"^[A-Za-z ]{1,60}$"));
        }

        /// <summary> Checks if string conforms to zipcode structure. </summary>
        /// <param name="zipCode"> Zipcode to check. </param>
        /// <returns> Returns true if zipCode conforms to regex. </returns>
        public static bool IsValidZipCode(string zipCode)
        {
            return RegexCheck(zipCode, new Regex(@"^[0-9]{4}[A-Za-z]{2}$"));
        }

        /// <summary> Checks if string conforms to streetnumber structure. </summary>
        /// <param name="streetNumber"> Streetnumber to check. </param>
        /// <returns> Returns true if streetNumber conforms to regex. </returns>
        public static bool IsValidStreetNumber(string streetNumber)
        {
            return RegexCheck(streetNumber, new Regex(@"^[0-9]{1,4}([A-Za-z]{1,2})?$"));
        }

        /// <summary> Checks if string conforms to mobile phone number structure. </summary>
        /// <param name="phoneNumber"> Address to check. </param>
        /// <returns> Returns true if phoneNumber conforms to regex. </returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return RegexCheck(phoneNumber, new Regex(@"^06\d{8}$"));
        }

        /// <summary> Checks if string conforms to price structure. </summary>
        /// <param name="price"> Address to check. </param>
        /// <returns> Returns true if price conforms to regex. </returns>
        public static bool IsValidPrice(string price)
        {
            return RegexCheck(price, new Regex(@"^[0-9]*(\,)?[0-9]?[0-9]?$"));
        }

        /// <summary> Checks if string conforms to time structure. </summary>
        /// <param name="time"> Time to check. </param>
        /// <returns> Returns true if time conforms to regex. </returns>
        public static bool IsValidTimeFormat(string time)
        {
            return RegexCheck(time, new Regex(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$"));
        }

        /// <summary> Checks if string conforms to description structure. </summary>
        /// <param name="description"> Description to check. </param>
        /// <returns> Returns true if description conforms to regex. </returns>
        public static bool IsValidDescription(string description)
        {
            return RegexCheck(description, new Regex(@"^.{1,500}$"));
        }

        /// <summary> Checks if string conforms to cancel time structure. </summary>
        /// <param name="cancelTime"> Cancel time to check. </param>
        /// <returns> Returns true if cancel time is between 0 and 52. </returns>
        public static bool IsValidCancelTime(string cancelTime)
        {
            return NumberCheck(cancelTime, 0, 52);
        }

        /// <summary> Checks if string conforms to age rules. </summary>
        /// <param name="age"> Age to check. </param>
        /// <returns> Returns true if age is between 0 and 120. </returns>
        public static bool IsValidAge(string age)
        {
            return NumberCheck(age, 0, 120);
        }

        /// <summary> Checks if string conforms to e-mail structure. </summary>
        /// <param name="email"> E-mail to check. </param>
        /// <returns> Returns true if email conforms to regex. </returns>
        public static bool IsValidEmail(string email)
        {
            var isValidEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            return RegexCheck(email, isValidEmail);
        }

        /// <summary> Checks if string conforms to ticket amount rules. </summary>
        /// <param name="ticketAmount"> Ticket amount to check. </param>
        /// <returns> Returns true if ticketAmount is between 1 and 100000. </returns>
        public static bool IsValidMaxTickets(string ticketAmount)
        {
            return NumberCheck(ticketAmount, 1, 100000);
        }

        /// <summary> Checks if string conforms to maximum tickets per person rules. </summary>
        /// <param name="ticketAmount"> Ticket amount to check. </param>
        /// <returns> Returns true if ticketAmount is between 1 and 100. </returns>
        public static bool IsValidMaxTicketsPerPerson(string ticketAmount)
        {
            return NumberCheck(ticketAmount, 1, 100);
        }

        /// <summary> Checks if string conforms to password structure. </summary>
        /// <param name="password"> Password to check. </param>
        /// <returns> Returns true if password conforms to regex. </returns>
        public static bool IsValidPassword(string password)
        /// <summary>
        /// string must be between 8 and 15 characters long. string must contain at least one
        /// number. string must contain at least one uppercase letter. string must contain at least
        /// one lowercase letter. String must contain at least one symbol.
        /// </summary>
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(password) || !hasUpperChar.IsMatch(password) || !hasMiniMaxChars.IsMatch(password) || !hasSymbols.IsMatch(password) || !hasNumber.IsMatch(password))
            {
                ErrorMessage.WriteLine("Password should contain the following rules: ");
                ErrorMessage.WriteLine(" - Must be between 8 and 15 characters long. ");
                ErrorMessage.WriteLine(" - Must contain at least one number. . ");
                ErrorMessage.WriteLine(" - Must contain at least one uppercase letter. ");
                ErrorMessage.WriteLine(" - Must contain at least one lowercase letter. ");
                ErrorMessage.WriteLine(" - Must contain at least one symbol. ");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}