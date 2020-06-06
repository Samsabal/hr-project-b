using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Festival
{
    class Writer
    {
        public static void Festival(FestivalModel festival)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("You need to be at least " + festival.FestivalAgeRestriction + " years old in order to enter.");
            Console.WriteLine(festival.FestivalDescription);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Starts at " + festival.FestivalStartingTime + " and ends on " + festival.FestivalEndTime + ".");
            Console.WriteLine("Takes place on: " + festival.FestivalDate.Day + "-" + festival.FestivalDate.Month + "-" + festival.FestivalDate.Year);
            Console.WriteLine();
            Console.WriteLine(festival.FestivalLocation.StreetName + " " + festival.FestivalLocation.StreetNumber + ", " + festival.FestivalLocation.ZipCode);
            Console.WriteLine(festival.FestivalLocation.City + ", " + festival.FestivalLocation.Country);
            Console.WriteLine("======================================================================");
        }

        public static void Tickets()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();

            // Displays the Tickets for the current Festival
            foreach (var ticket in Transaction.CurrentTicketListBuilder.GetCurrentTicketList())
            {
                int ticketId = ticket.TicketID;
                int maxTickets = ticket.MaxTickets;
                Console.WriteLine(ticket.TicketName);
                Console.WriteLine("Description: " + ticket.TicketDescription);
                Console.WriteLine("Price: " + ticket.TicketPrice + " euros");
                Console.WriteLine("There are " + ticket.MaxTickets + " in total of which there are " + Utils.TicketsLeft(ticketId, maxTickets) + " left.");
                Console.WriteLine("----------------------------------------------------------------------");

                newMenuOptions.Add(new MenuOption("Buy Ticket:" + ticket.TicketName, () => {
                    Menu.option = 0;
                    Console.Clear();
                    Transaction.DisplayManager.Initiate(ticket.TicketID);
                }));
            }
            newMenuOptions.Add(new MenuOption("Return to Catalog:", () => {
                Console.Clear();
                CatalogPage.currentCatalogNavigation = "main";
                CatalogPage.CatalogMain();
            }));
            newMenuOptions.Add(new MenuOption("Exit to Main Menu:", () => {
                Menu.option = 0;
                Console.Clear();
                Program.Main();
            }));

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ConsoleHelperFunctions.ClearCurrentConsoleLine();
            Console.WriteLine("======================================================================");
            Menu.Draw(newMenuOptions);
        }

        public static void FestivalOrganiser(FestivalModel festival)
        {
            foreach (var user in JSONFunctionality.GetUserList().Users)
            {
                if (festival.FestivalOrganiserID == user.AccountID)
                {
                    Console.WriteLine("Organised by: " + user.CompanyName);
                }
            }
        }

    }
}
