using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class MainMenu
    {
        public List<MenuOption> MainMenuBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Register", () =>
                {
                    Console.Clear();
                    UserModel user = new UserModel(){AccountID = JSONFunctions.GenerateUserID()};
                    AccountRegistration.Handler.InitiateUserRegister(user);
                }),
                new MenuOption("Login", () =>
                {
                    Console.Clear();
                    do {Menu.Draw(new LoginMenu().LoginBuilder()); }
                    while (Menu.Loop);
                }),
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    Festival.CatalogPage.CatalogMain();
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