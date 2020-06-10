using System;
using Festivity.Account;

namespace Festivity
{
    internal class Program
    {
        private static UIElements UI = new UIElements();
        public static void Main()
        {
            Console.Clear();
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                if (!LoggedInModel.IsLoggedIn())
                {
                    UI.DrawMainMenu();
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
            }
        }
    }
}