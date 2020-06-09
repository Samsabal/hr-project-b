using System;
using Festivity.Account;

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

                if (!LoggedInModel.IsLoggedIn())
                {
                    Menu.Draw(new MainMenu().MainMenuBuilder());
                }
                if (LoggedInModel.IsLoggedIn())
                {
                    if (LoggedInModel.User.AccountType == 2)
                    {
                        Menu.Draw(MainMenuUser.MainMenuUserBuilder());
                    }
                    if (LoggedInModel.User.AccountType == 1)
                    {
                        Menu.Draw(MainMenuOrganiser.MainMenuOrganiserBuilder());
                    }
                }
            }
        }
    }
}