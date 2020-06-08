using System;

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

                if (!LoggedInAccount.IsLoggedIn())
                {
                    UI.DrawMainMenu();
                    Menu.Draw(MainMenu.MainMenuBuilder());
                }
                if (LoggedInAccount.IsLoggedIn())
                {
                    if (LoggedInAccount.User.AccountType == 2)
                    {
                        Menu.Draw(MainMenuUser.MainMenuUserBuilder());
                    }
                    if (LoggedInAccount.User.AccountType == 1)
                    {
                        Menu.Draw(MainMenuOrganiser.MainMenuOrganiserBuilder());
                    }
                }
            }
        }
    }
}