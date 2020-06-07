using System;
using System.Threading;

namespace Festivity.Account
{
    internal class ChangeEmailPreference
    {
        public static void Initate()
        {
            Console.WriteLine("Do you want to change your Email Preference? [Y or N].");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "y")
            {
                UserAccepstPreferenceChange();
            }
            else if (userInput.ToLower() != "n")
            {
                UserDeclinesPreferenceChange();
            }
            ConsoleHelperFunctions.ClearCurrentConsole();
            LoggedInAccount.UpdateDatabase();
        }

        private static void UserAccepstPreferenceChange()
        {
            Console.Clear();
            LoggedInAccount.User.NewsLetter = !LoggedInAccount.User.NewsLetter;
            Console.WriteLine("Preference successfully changed.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        private static void UserDeclinesPreferenceChange()
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please try again.");
            Initate();
        }
    }
}