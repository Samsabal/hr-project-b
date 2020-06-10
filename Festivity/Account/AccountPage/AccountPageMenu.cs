using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class AccountPageMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> Build()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Change user information ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Handler.InitateInfoChange();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Change password ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Account.ChagePasswordHandler.Initiate();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Exit to Main Menu ."), () =>
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