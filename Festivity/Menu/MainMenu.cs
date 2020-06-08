using Festivity.AccountLogin;
using Festivity.AccountRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class MainMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public static List<MenuOption> MainMenuBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Register ."), () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    UserModel user = new UserModel(){AccountID = JSONFunctionality.GenerateUserID()};
                    UserRegisterHandler.InitiateUserRegister(user);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Log In ."), () =>
                {
                    Console.Clear();
                    LoginManager.InitiateLogin();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Festivals ."), () =>
                {
                    Console.Clear();
                    CatalogPage.CatalogMain();
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
