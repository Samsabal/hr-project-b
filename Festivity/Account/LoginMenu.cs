using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class LoginMenu
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> LoginBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Login to your account ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountLogin.LoginHandler.InitiateLogin();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Forgot password ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountLogin.LoginHandler.InitiateForgotPassword();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Return to main menu ."), () =>
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