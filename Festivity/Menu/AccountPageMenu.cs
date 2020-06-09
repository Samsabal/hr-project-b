using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class AccountPageMenu : MenuBuilder
    {
        public static List<MenuOption> Build()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Change user information", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Manager.InitateInfoChange();
                }),
                new MenuOption("Change password", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Account.ChangePassword.Initiate();
                }),
                new MenuOption("Exit to Main Menu", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Program.Main();
                }),
            };

            return newMenuOptions;
        }
    }
}