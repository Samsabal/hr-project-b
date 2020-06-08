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
                Console.SetWindowSize(150, 36);
                if (!LoggedInAccount.IsLoggedIn())
                {
                    UI.DrawMainMenu();
                    //UIElements.PrintUI();
                    Menu.Draw(MenuBuilder.MainMenu());
                    //UIElements.GoddelijkeDunneLijn();
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