using System;
using System.Threading;

namespace Festivity.Account
{
    internal class ForgotPasswordHandler
    {
        private static readonly JSONUserList userList = JSONFunctions.GetUserList();
        private static UIElements UI = new UIElements("LoginPage", "ForgotPassword");

        public static void Initiate()
        {
            UI.DrawMainMenu();
            
            InitateRetry();


        }

        public static void InitateRetry()
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
                ErrorMessage.WriteLine("Email does not exist, please try again.");
                InitateRetry();
            }
        }
    }
}