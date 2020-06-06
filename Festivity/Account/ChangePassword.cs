using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity.Account
{
    class ChangePassword
    {
        public static void Initiate()
        {
            Console.WriteLine("Input current password: ");
            string userInput = Console.ReadLine();

            if (userInput == LoggedInAccount.User.Password)
            {
                Console.WriteLine("Input new password: ");
                string userInput1 = Console.ReadLine();
                ConsoleHelperFunctions.ClearCurrentConsoleLine();
                Console.WriteLine("Input new password again: ");
                string userInput2 = Console.ReadLine();
                Console.Clear();
                if (userInput1 == userInput2)
                {
                    LoggedInAccount.User.Password = userInput2;
                    Console.WriteLine("Password successfully changed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Passwords do not match, please try again.");
                    Thread.Sleep(1000);
                    Initiate();
                }
            }
            else
            {
                Console.WriteLine("Invalid password, please try again.");
                Thread.Sleep(1000);
                Initiate();
            }
            LoggedInAccount.UpdateDatabase();
        }
    }
}
