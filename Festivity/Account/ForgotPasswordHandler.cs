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
            Console.Write("Enter Email: "); 
            
            string userEmail = Console.ReadLine();
            RegexUtils.MakesUserQuitIfCalled(userEmail);
            Console.Clear();

            foreach (var user in userList.Users)
            {
                if (user.Email.ToLower() == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.WriteLine($"Your password = {user.Password}");
                    Console.WriteLine("Press <Enter> to go back");
                    Console.ReadLine();
                    ConsoleHelperFunctions.ClearCurrentConsole();
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