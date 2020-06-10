using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class MainMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> MainMenuBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Register ."), () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    UserModel user = new UserModel(){AccountID = JSONFunctions.GenerateUserID()};
                    AccountRegistration.Handler.InitiateUserRegister(user);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Log In ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Loop = true;
                    do {Menu.Draw(new LoginMenu().LoginBuilder()); }
                    while (Loop);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Festivals ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Festival.CatalogPage.CatalogMain();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Exit ."), () =>
                {
                    Environment.Exit(0);
                })
            };

            return newMenuOptions;
        }
    }
}