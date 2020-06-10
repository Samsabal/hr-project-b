using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MainMenuOrganiser : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> MainMenuOrganiserBuilder()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Festivals ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Festival.CatalogPage.CatalogMain();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Register Festivals ."), () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalModel festival = new FestivalModel { FestivalID = FestivalRegister.Handler.SetFestivalId(JSONFunctions.GetFestivals()), FestivalOrganiserID = Account.LoggedInModel.GetID() };
                    FestivalRegister.Handler.ActiveScreen = true;
                    FestivalRegister.Handler.InitiateFestivalRegister(festival);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". My Account ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Handler.DrawPage();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". My Tickets ."), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    TicketTable.Handler.Initiate();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". My Festivals ."), () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalTable.Drawer.Draw();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Logout ."), () =>
                {
                    Console.Clear();
                    UI.Header();
                    ErrorMessage.WriteLine(UI.SpaceStringInMiddle("Successfully logged out!"));
                    UI.Line();
                    Thread.Sleep(1000);
                    Menu.OptionReset();
                    Account.LoggedInModel.LogOut();
                    Program.Main();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Exit ."), () =>
                {
                    Environment.Exit(0);
                })
            };

            return newMenuOptions;
        }
    }
}