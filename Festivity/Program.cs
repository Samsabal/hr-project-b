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
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.SetWindowSize(150, 36);
                if (!LoggedInAccount.IsLoggedIn())
                {
                    MenuFunction.Menu(new string[] { "Register", "Login", "Festivals", "Exit" });
                }
                if (LoggedInAccount.IsLoggedIn())
                {
                    if (LoggedInAccount.User.AccountType == 2)
                    {
                        MenuFunction.Menu(new string[] { "Festivals", "My Account", "My Tickets", "Logout", "Exit" });
                    }
                    if (LoggedInAccount.User.AccountType == 1)
                    {
                        MenuFunction.Menu(new string[] { "Festivals", "Register festival", "My Account", "My Tickets", "Logout", "Exit" });
                    }
                }
            }
        }
    }
}