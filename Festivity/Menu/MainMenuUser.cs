using Festivity.Account;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MainMenuUser : MenuBuilder
    {
        public static List<MenuOption> MainMenuUserBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festivals", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Festival.CatalogPage.CatalogMain();
                }),
                new MenuOption("My Account", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Handler.DrawPage();
                }),
                new MenuOption("My Tickets", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    TicketTable.Handler.Initiate();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menu.OptionReset();
                    LoggedInModel.LogOut();
                    Program.Main();
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