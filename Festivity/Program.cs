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