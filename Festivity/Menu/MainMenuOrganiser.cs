using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MainMenuOrganiser : MenuBuilder
    {
        public static List<MenuOption> MainMenuOrganiserBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festivals", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Register Festivals", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalModel festival = new FestivalModel { FestivalID = RegisterHandler.SetFestivalId(JSONFunctionality.GetFestivals()) };
                    RegisterHandler.ActiveScreen = true;
                    RegisterHandler.InitiateFestivalRegister(festival);
                }),
                new MenuOption("My Account", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Manager.DrawPage();
                }),
                new MenuOption("My Tickets", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    TicketTableManager.Initiate();
                }),
                new MenuOption("My Festivals", () =>
                {
                    Console.Clear();
                    Festival.FestivalTableDrawer.Draw();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menu.OptionReset();
                    LoggedInAccount.LogOut();
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