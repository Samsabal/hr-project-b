using Festivity.Account;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MainMenuUser
    {
        public List<MenuOption> MainMenuUserBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    Festival.CatalogPage.CatalogMain();
                }),
                new MenuOption("My Account", () =>
                {
                    Console.Clear();
                    AccountPage.Handler.DrawPage();
                }),
                new MenuOption("My Tickets", () =>
                {
                    Console.Clear();
                    TicketTable.Handler.Initiate();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
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