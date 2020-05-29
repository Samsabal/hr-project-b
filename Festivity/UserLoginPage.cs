using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Festivity
{
    class UserLoginPage
    {
 

        public static int userLoginChoice;
        public static int currentUserId = 0;
        public static int currentUserType;

        public static void login_page()
        {
            userLoginChoice = 0;
            MenuFunction.option = 0;
            while (true)
            {
                MenuFunction.menu(new string[] { "Login to your Account", "Forgot password", "Exit to Main Menu" });
            } 
        }
        public static void forgot_password()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            bool accountExists = false;
            Console.WriteLine("Enter Email: ");
            string userEmail = Console.ReadLine();
            Console.Clear();

            foreach(var user in users.users)
            {
                if (user.email.ToLower() == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.WriteLine("Your password = " + user.password + "\n");
                    Console.WriteLine("Press <Enter> to go back");
                    Console.ReadLine();
                } 
            }
            if (!accountExists)
            {
                Console.Clear();
                Console.WriteLine("Email does not exist, please try again.");
                Thread.Sleep(1000);
                forgot_password();
            }
        }
        public static void user_login(int loginOption = 0)
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            bool accountExists = false;

            Console.Write("Enter Email: ");
            var userEmail = Console.ReadLine();
            Console.Clear();
            //Console.SetCursorPosition(0, 0);

            foreach (var user in users.users)
            {
                if (user.email == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.Write("Password: ");
                    var userPassword = Console.ReadLine();
                    Console.Clear();

                    if (user.password == userPassword)
                    {
                        currentUserId = user.accountID;
                        currentUserType = user.accountType;
                        Console.WriteLine("You are logged in!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        if (loginOption == 0)
                        {
                            Program.Main(); //new string[] { }
                        }
                        loginOption = 0;


                    } else {
                        Console.WriteLine("Wrong password, please try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        user_login();
                    }
                } 
            }
            if (!accountExists)
            {
                Console.WriteLine("Account exists does not exist, please try again");
                Thread.Sleep(1000);
                Console.Clear();
                user_login();
            }
        }
        public static void automaticLogin(User user)
        {
            currentUserId = user.accountID;
            Program.Main();
        }
    }
}
