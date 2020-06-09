﻿using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class LoginMenu
    {
        public List<MenuOption> LoginBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Login to your account", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountLogin.LoginManager.InitiateLogin();
                }),
                new MenuOption("Forgot password", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountLogin.LoginManager.InitiateForgotPassword();
                }),
                new MenuOption("Return to main menu", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    MenuBuilder.Loop = false;
                })
            };
            return newMenuOptions;
        }
    }
}