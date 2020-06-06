using System;
using System.Collections.Generic;

namespace Festivity.Transaction
{
    internal class DrawBuyTicketPage
    {
        private static int currentFestivalId;

        public static void Draw()
        {
            currentFestivalId = CatalogPage.selectedFestival;

            TicketListBuilder.Set(currentFestivalId);

            MenuFunction.option = 0;

            while (true)
            {
                List<string> menuOptionsList = new List<string>();
                string line = "----------------------------------------------------------------------";

                // Displays the Tickets for the current Festival
                foreach (var ticket in TicketListBuilder.Get())
                {
                    Console.WriteLine(ticket.TicketName);
                    Console.WriteLine("Description: " + ticket.TicketDescription);
                    Console.WriteLine("Price: " + ticket.TicketPrice + " euros");
                    Console.WriteLine(line);
                    menuOptionsList.Add("Buy Ticket:" + ticket.TicketID);
                }

                menuOptionsList.Add("Return to Festival Page");
                menuOptionsList.Add("Exit to Main Menu");
                MenuFunction.Menu(menuOptionsList.ToArray(), TicketListBuilder.Get().ToArray());
            }
        }
    }
}