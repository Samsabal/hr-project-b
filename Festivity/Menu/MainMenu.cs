﻿using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class MainMenu : MenuBuilder
    {
        public List<MenuOption> MainMenuBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Register", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    UserModel user = new UserModel(){AccountID = JSONFunctions.GenerateUserID()};
                    AccountRegistration.Handler.InitiateUserRegister(user);
                }),
                new MenuOption("Login", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Loop = true;
                    do {Menu.Draw(new LoginMenu().LoginBuilder()); }
                    while (Loop);
                }),
                new MenuOption("Festivals", () =>
                {
                    Menu.OptionReset();
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