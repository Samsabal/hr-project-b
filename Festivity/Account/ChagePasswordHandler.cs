using System;
using System.Threading;

namespace Festivity.Account
{
    internal class ChagePasswordHandler
    {
        private static string Password;

        public static void Initiate()
        {
            Console.Write("Input current password: ");
            if (UserInputIsCorrectPassword())
            {
                Console.Write("Input new password: ");
                string FirstPassword = AskUserForPasswordWithValidation();
                Console.Write("Input new password again: ");
                string SecondPassword = AskForSameUserPassword(FirstPassword);
                LoggedInModel.User.Password = SecondPassword;
                Console.Write("Password successfully changed");
                Thread.Sleep(1000);
                ConsoleHelperFunctions.ClearCurrentConsole();
            }
            else
            {
                Console.WriteLine("Invalid password, please try again.");
                Initiate();
            }
            LoggedInModel.UpdateDatabase();
        }

        private static bool UserInputIsCorrectPassword()
        {
            string userInput = Console.ReadLine();
            return userInput == LoggedInModel.User.Password;
        }

        private static string AskUserForPasswordWithValidation()
        {
            do { Password = Utils.General.InputLoop(""); }
            while (!RegexUtils.IsValidPassword(Password));
            return Password;
        }

        private static string AskForSameUserPassword(string p1)
        {
            do { Password = Utils.General.InputLoop(""); }
            while (PasswordsDoNotMatch(p1, Password));
            return Password;
        }

        private static bool PasswordsDoNotMatch(string p1, string p2)
        {
            if (p1 != p2)
            {
                Console.Write("Passwords do not match, please try again:");
                return true;
            }
            return false;
        }
    }
}