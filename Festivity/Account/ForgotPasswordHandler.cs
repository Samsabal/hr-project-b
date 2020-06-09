using System;
using System.Threading;

namespace Festivity.Account
{
    internal class ForgotPasswordHandler
    {
        private static readonly JSONUserList userList = JSONFunctions.GetUserList();

        public static void Initiate()
        {
            bool accountExists = false;
            Console.WriteLine("Enter Email: "); string userEmail = Console.ReadLine();
            Console.Clear();

            foreach (var user in userList.Users)
            {
                if (user.Email.ToLower() == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.WriteLine("Your password = " + user.Password + "\n");
                    Console.WriteLine("Press <Enter> to go back");
                    Console.ReadLine();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    Program.Main();
                }
            }
            if (!accountExists)
            {
                Console.Clear();
                Console.WriteLine("Email does not exist, please try again.");
                Thread.Sleep(1000);
                Initiate();
            }
        }
    }
}