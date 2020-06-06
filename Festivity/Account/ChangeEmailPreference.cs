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
            if (LoggedInAccount.User.NewsLetter == 1)
            {
                Console.WriteLine("Do you want to stop recieving Newsletters? [Y or N].");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    Console.Clear();
                    LoggedInAccount.User.NewsLetter = 0;
                    Console.WriteLine("Preference successfully changed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else if (userInput.ToLower() != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again.");
                    Initate();
                }
            }
            else if (LoggedInAccount.User.NewsLetter == 0)
            {
                Console.WriteLine("Do you want to recieve Newsletters? [Y or N]");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    Console.Clear();
                    LoggedInAccount.User.NewsLetter = 1;
                    Console.WriteLine("Preference successfully changed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else if (userInput.ToLower() != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again.");
                    Initate();
                }
            }
            LoggedInAccount.UpdateDatabase();
        }
    }
}
