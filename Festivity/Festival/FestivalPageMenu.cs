﻿using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalPageMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> FestivalPageMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();

            foreach (var ticket in Transaction.TicketListBuilder.Get())
            {
                newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Buy Ticket: " + ticket.TicketName + " ."), () =>
                {
                    if (LoggedInModel.IsLoggedIn())
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Menu.OptionReset();
                        Console.Clear();
                        Transaction.Handler.Initiate(ticket.TicketID);
                    }
                    else
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Menu.OptionReset();
                        Console.Clear();
                        AccountLogin.LoginHandler.InitiateLogin(true);
                    }
                }));
            }
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Return to Catalog ."), () =>
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Menu.OptionReset();
                Console.Clear();
                Festival.CatalogPage.CurrentCatalogNavigation = "main";
                Festival.CatalogPage.CatalogMain();
            }));
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Exit to Main Menu ."), () =>
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Menu.OptionReset();
                Console.Clear();
                Program.Main();
            }));

            return newMenuOptions;
        }
    }
}