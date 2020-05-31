using System;

namespace Festivity
{
    internal class Program
    {
        public static void Main()
        {
            //string[] args
            Console.Clear();
            while (true)
            {
                Console.SetWindowSize(150, 36);
                if (!LoggedInAccount.IsLoggedIn())
                {
                    MenuFunction.Menu(new string[] { "Register", "Login", "Festivals", "Exit" });
                }
                if (LoggedInAccount.IsLoggedIn())
                {
                    if (LoggedInAccount.User.AccountType == 2)
                    {
                        MenuFunction.Menu(new string[] { "Festivals", "Account", "My Festivals", "Logout", "Exit" });
                    }
                    if (LoggedInAccount.User.AccountType == 1)
                    {
                        MenuFunction.Menu(new string[] { "Festivals", "Register festival", "Account", "My Festivals", "Logout", "Exit" });
                    }
                }
            }
        }
    }
}