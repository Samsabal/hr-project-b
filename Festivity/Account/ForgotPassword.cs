using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity.Account
{
    class ForgotPassword
    {
        private static readonly JSONUserList userList = JSONFunctionality.GetUserList();
        private static UIElements UI = new UIElements("LoginPage", "ForgotPassword");
        public static void Initiate()
        {
            UI.DrawMainMenu();
            
            InitateRetry();


        }

        public static void InitateRetry()
        {
            bool accountExists = false;
            Console.Write("Input the Email of your Account: ");
            //Console.Write(">>> ");
            string userEmail = Console.ReadLine();

            foreach (var user in userList.Users)
            {
                if (user.Email.ToLower() == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.WriteLine($"You password: {user.Password}");
                    Console.Write("Press <Enter> to go back");
                    //Console.Write(">>> ");
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
