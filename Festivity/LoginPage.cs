using Newtonsoft.Json;
using System;
using System.IO;

namespace Festivity
{
    class LoginPage
    {
        public static void login_page()
        {
            user_login();
        }
        public static void user_login()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            int currentUser;
            bool exists = false;

            Console.WriteLine("\nEnter Email: ");
            var userEmail = Console.ReadLine();
            Console.WriteLine("\nEnter Password: ");
            var userPassword = Console.ReadLine();

            foreach (var user in users.users)
            {
                if (user.email == userEmail)
                {
                    if (user.password == userPassword)
                    {
                        exists = true;
                        currentUser = user.accountID;
                        Console.WriteLine("You are logged in!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong password!");
                    }
                }
            }
            if (!exists)
            {
                Console.WriteLine("\nAccount exists does not exist!");
            }

        }
    }
}
