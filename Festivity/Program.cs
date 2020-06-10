using System;
using Festivity.Account;

namespace Festivity
{
    internal class Program
    {
        public static void Main()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                if (!LoggedInModel.IsLoggedIn())
                {
                    Menu.Draw(new MainMenu().MainMenuBuilder());
                }
                if (LoggedInModel.IsLoggedIn())
                {
                    if (LoggedInModel.User.AccountType == 2)
                    {
                        Menu.Draw(new MainMenuUser().MainMenuUserBuilder());
                    }
                    if (LoggedInModel.User.AccountType == 1)
                    {
                        Menu.Draw(new MainMenuOrganiser().MainMenuOrganiserBuilder());
                    }
                }
            } while (Menu.IsLooping);
        }
    }
}