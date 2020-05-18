using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Festivity
{
    class LoginPage
    {
        static string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
        static JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

        public static int userLoginChoice;
        public static int currentUserId;

        public static void login_page()
        {
            userLoginChoice = 0;
            while(userLoginChoice == 0)
            {
                MenuFunction.menu(new string[] { "Login to your Account", "Forgot password" });
            } 
            if(userLoginChoice == 1)
            {
                user_login();
            }
            if(userLoginChoice == 2) 
            {
                forgot_password();
            }
        }
        public static void forgot_password()
        {
            Console.WriteLine("Enter Email1: ");
            string userEmail = Console.ReadLine();

            foreach(var user in users.users)
            {
                if (user.email == userEmail.ToLower())
                {
                    Console.WriteLine("Your password = " + user.password);
                    Console.WriteLine("Press 'Enter' to go back");
                    Console.ReadLine();
                    break;
                } else {
                    Console.Clear();
                    Console.WriteLine("Email does not exist, please try again.");
                    forgot_password();
                }

            }
        }
        public static void user_login()
        {
            bool accountExists = false;

            Console.WriteLine("Enter Email: ");
            var userEmail = Console.ReadLine();
            Console.Clear();
            Console.Write("You password please: ");
            var userPassword = Console.ReadLine();
            Console.Clear();

            foreach (var user in users.users)
            {
                if (user.email == userEmail.ToLower())
                {
                    if (user.password == userPassword)
                    {
                        accountExists = true;
                        currentUserId = user.accountID;
                        Console.WriteLine("You are logged in!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password!");
                    }
                }
            }
            if (!accountExists)
            {
                Console.WriteLine("Account exists does not exist!");
            }
        }
    }
}
