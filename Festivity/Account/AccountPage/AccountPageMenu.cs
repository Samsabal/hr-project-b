using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class AccountPageMenu
    {
        public List<MenuOption> Build()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Change user information", () =>
                {
                    Console.Clear();
                    AccountPage.Handler.InitateInfoChange();
                }),
                new MenuOption("Change password", () =>
                {
                    Console.Clear();
                    Account.ChagePasswordHandler.Initiate();
                }),
                new MenuOption("Exit to Main Menu", () =>
                {
                    Console.Clear();
                    Program.Main();
                }),
            };

            return newMenuOptions;
        }
    }
}