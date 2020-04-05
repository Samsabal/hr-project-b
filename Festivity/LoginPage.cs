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
        public static void loginPage()
        {
            userLogin();
        }
        public static void userLogin()
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            int currentUser;
            bool exists = false;

            Console.WriteLine("\nEnter Email: ");
            var userFirstName = Console.ReadLine();
            Console.WriteLine("\nEnter Password: ");
            var userPassword = Console.ReadLine();

            foreach (var user in users.users)
            {
                if (user.firstName == userFirstName)
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
                Console.WriteLine("\nAccount exists: " + exists + "!");
            }

        }
    }
}
