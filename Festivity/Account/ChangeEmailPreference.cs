using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity.Account
{
    class ChangeEmailPreference
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


        public static void UserAccepstPreferenceChange()
        {
            Console.Clear();
            LoggedInAccount.User.NewsLetter = !LoggedInAccount.User.NewsLetter;
            Console.WriteLine("Preference successfully changed.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void UserDeclinesPreferenceChange()
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please try again.");
            Initate();
        }
    }
}
