using System;
using System.Threading;

namespace Festivity
{
    internal class UserLoginPage
    {
        public static int userLoginChoice;
        //public static int currentUserID = 0;
        //public static int currentUserType;

        private static readonly JSONUserList userList = JSONFunctionality.GetUserList();

        public static void LoginPage()
        {
            userLoginChoice = 0;
            MenuFunction.option = 0;
            while (true)
            {
                MenuFunction.Menu(new string[] { "Login to your Account", "Forgot password", "Exit to Main Menu" });
            }
        }

        public static void ForgotPassword()
        {
            bool accountExists = false;
            Console.WriteLine("Enter Email: ");
            string userEmail = Console.ReadLine();
            Console.Clear();

            foreach (var user in userList.Users)
            {
                if (user.Email.ToLower() == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.WriteLine("Your password = " + user.Password + "\n");
                    Console.WriteLine("Press <Enter> to go back");
                    Console.ReadLine();
                }
            }
            if (!accountExists)
            {
                Console.Clear();
                Console.WriteLine("Email does not exist, please try again.");
                Thread.Sleep(1000);
                ForgotPassword();
            }
        }

        public static void UserLogin(int loginOption = 0)
        {
            bool accountExists = false;

            Console.Write("Enter Email: ");
            var userEmail = Console.ReadLine();
            Console.Clear();
            //Console.SetCursorPosition(0, 0);

            foreach (var user in userList.Users)
            {
                if (user.Email == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.Write("Password: ");
                    var userPassword = Console.ReadLine();
                    Console.Clear();

                    if (user.Password == userPassword)
                    {
                        LoggedInAccount.SetUser(user.AccountID);
                        //currentUserType = user.AccountType; Temp disabled
                        Console.WriteLine("You are logged in!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        if (loginOption == 0)
                        {
                            Program.Main(); //new string[] { }
                        }
                        loginOption = 0;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password, please try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        UserLogin();
                    }
                }
            }
            if (!accountExists)
            {
                Console.WriteLine("Account exists does not exist, please try again");
                Thread.Sleep(1000);
                Console.Clear();
                UserLogin();
            }
        }

        public static void AutomaticLogin(UserModel user)
        {
            LoggedInAccount.SetUser(user.AccountID);

            Program.Main();
        }
    }
}