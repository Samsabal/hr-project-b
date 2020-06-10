using System;
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
                    Console.Clear();
                    AccountLogin.LoginHandler.InitiateLogin();
                }),
                new MenuOption("Forgot password", () =>
                {
                    Console.Clear();
                    AccountLogin.LoginHandler.InitiateForgotPassword();
                }),
                new MenuOption("Return to main menu", () =>
                {
                    Console.Clear();
                    Program.Main();
                })
            };
            return newMenuOptions;
        }
    }
}