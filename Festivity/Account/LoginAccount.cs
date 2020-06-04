using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity.Account
{
    class LoginAccount
    {
        private static readonly JSONUserList userList = JSONFunctionality.GetUserList();

        public static void Initiate(bool ticketLogin)
        {
            bool accountExists = false;

            Console.Write("Enter Email: "); var userEmail = Console.ReadLine();

            foreach (var user in userList.Users)
            {
                if (user.Email == userEmail.ToLower())
                {
                    accountExists = true;
                    Console.Write("Password: "); var userPassword = Console.ReadLine();

                    if (user.Password == userPassword)
                    {
                        LoggedInAccount.SetUser(user.AccountID);
                        Console.WriteLine("You are logged in!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        if (!ticketLogin)
                        {
                            Program.Main();
                        }
                        ticketLogin = true;

                    }
                    else
                    {
                        Console.WriteLine("Wrong password, please try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Initiate(ticketLogin);
                    }
                }
            }
            if (!accountExists)
            {
                Console.WriteLine("Account exists does not exist, please try again");
                Thread.Sleep(1000);
                Console.Clear();
                Initiate(ticketLogin);
            }
        }
    }
}
