using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalPageMenu
    {
        public List<MenuOption> FestivalPageMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();

            foreach (var ticket in Transaction.TicketListBuilder.Get())
            {
                newMenuOptions.Add(new MenuOption("Buy Ticket: " + ticket.TicketName, () =>
                {
                    if (LoggedInModel.IsLoggedIn())
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Console.Clear();
                        Transaction.Handler.Initiate(ticket.TicketID);
                    }
                    else
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Console.Clear();
                        AccountLogin.LoginHandler.InitiateLogin(true);
                    }
                }));
            }
            newMenuOptions.Add(new MenuOption("Return to Catalog", () =>
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Console.Clear();
                Festival.CatalogPage.CurrentCatalogNavigation = "main";
                Festival.CatalogPage.CatalogMain();
            }));
            newMenuOptions.Add(new MenuOption("Exit to Main Menu", () =>
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Console.Clear();
                Program.Main();
            }));

            return newMenuOptions;
        }
    }
}