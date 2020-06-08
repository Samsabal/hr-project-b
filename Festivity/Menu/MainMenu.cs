using Festivity.AccountLogin;
using Festivity.AccountRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class MainMenu : MenuBuilder
    {
        public static List<MenuOption> MainMenuBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Register", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    UserModel user = new UserModel(){AccountID = JSONFunctionality.GenerateUserID()};
                    UserRegisterHandler.InitiateUserRegister(user);
                }),
                new MenuOption("Login", () =>
                {
                    Console.Clear();
                    LoginManager.InitiateLogin();
                }),
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Exit", () =>
                {
                    Environment.Exit(0);
                })
            };

            return newMenuOptions;
        }
    }
}
