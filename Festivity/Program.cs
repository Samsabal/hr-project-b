using System;

namespace Festivity
{
    internal class Program
    {
        public static void Main()
        {
            Console.Clear();
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                if (!LoggedInAccount.IsLoggedIn())
                {
                    Menu.Draw(MenuBuilder.MainMenu());
                }
                if (LoggedInAccount.IsLoggedIn())
                {
                    if (LoggedInAccount.User.AccountType == 2)
                    {
                        Menu.Draw(MenuBuilder.MainMenuUser());
                    }
                    if (LoggedInAccount.User.AccountType == 1)
                    {
                        Menu.Draw(MenuBuilder.MainMenuOrganiser());
                    }
                }
            }
        }
    }
}