using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

            Console.WriteLine("Email: ");
            var userEmail = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Password: ");
            var userPassword = Console.ReadLine();
            Console.Clear();

            foreach (var user in users.users)
            {
                if (user.email == userEmail.ToLower())
                {
                    if (user.password == userPassword)
                    {
                        int currentUser = user.accountID;
                        Console.WriteLine("You are logged in!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password!");
                    }
                }
                else
                {
                    Console.WriteLine("\nAccount exists does not exist!");
                }
            }

        }
    }
}
