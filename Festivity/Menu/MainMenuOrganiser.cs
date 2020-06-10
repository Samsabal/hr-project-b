using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MainMenuOrganiser
    {
        public List<MenuOption> MainMenuOrganiserBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    Festival.CatalogPage.CatalogSetup();
                    Festival.CatalogPage.CatalogMain();
                }),
                new MenuOption("Register Festivals", () =>
                {
                    Console.Clear();
                    FestivalModel festival = new FestivalModel { FestivalID = FestivalRegister.Handler.SetFestivalId(JSONFunctions.GetFestivals()), FestivalOrganiserID = Account.LoggedInModel.GetID() };
                    FestivalRegister.Handler.ActiveScreen = true;
                    FestivalRegister.Handler.InitiateFestivalRegister(festival);
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
                new MenuOption("My Festivals", () =>
                {
                    Console.Clear();
                    FestivalTable.Drawer.Draw();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
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