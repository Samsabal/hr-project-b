using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Festivity
{
    class LoginPage
    {
 

        public static int userLoginChoice;
        public static int currentUserId;

        public static void login_page()
        {
            userLoginChoice = 0;
            while(true)
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
                    Console.WriteLine("Press 'Enter' to go back");
                    Console.ReadLine();
                } 
            }
            if (!accountExists)
            {
                Console.Clear();
                Console.WriteLine("Email does not exist, please try again.");
                Thread.Sleep(3000);
                forgot_password();
            }
        }
        public static void user_login()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            bool accountExists = false;

            Console.Write("Enter Email: ");
            var userEmail = Console.ReadLine();
            Console.Clear();

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
                        Console.WriteLine("You are logged in!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Program.Main(new string[] { });

                    } else {
                        Console.WriteLine("Wrong password, please try again");
                        Thread.Sleep(3000);
                        Console.Clear();
                        user_login();
                    }
                } 
            }
            if (!accountExists)
            {
                Console.WriteLine("Account exists does not exist, please try again");
                Thread.Sleep(2000);
                Console.Clear();
                user_login();
            }
        }
        public static void automaticLogin(User user)
        {
            currentUserId = user.accountID;
        }
    }
}
