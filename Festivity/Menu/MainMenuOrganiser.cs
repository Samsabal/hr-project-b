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
                    Festival.CatalogPage.CatalogMain();
                }),
                new MenuOption("Register Festivals", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalModel festival = new FestivalModel { FestivalID = FestivalRegister.Handler.SetFestivalId(JSONFunctions.GetFestivals()), FestivalOrganiserID = Account.LoggedInModel.GetID() };
                    FestivalRegister.Handler.ActiveScreen = true;
                    FestivalRegister.Handler.InitiateFestivalRegister(festival);
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
                new MenuOption("My Festivals", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalTable.Drawer.Draw();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menu.OptionReset();
                    Account.LoggedInModel.LogOut();
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