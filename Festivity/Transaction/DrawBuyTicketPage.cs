using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity.Transaction
{
    internal class DrawBuyTicketPage
    {   
        private static int currentFestivalId;

        public static void Draw()
        {
            currentFestivalId = CatalogPage.selectedFestival;

            CurrentTicketListBuilder.SetCurrentTicketList(currentFestivalId);

            MenuFunction.option = 0;

            while (true)
            {
                List<string> menuOptionsList = new List<string>();
                string line = "----------------------------------------------------------------------";

                // Displays the Tickets for the current Festival
                foreach (var ticket in CurrentTicketListBuilder.GetCurrentTicketList())
                {
                    Console.WriteLine(ticket.TicketName);
                    Console.WriteLine("Description: " + ticket.TicketDescription);
                    Console.WriteLine("Price: " + ticket.TicketPrice + " euros");
                    Console.WriteLine(line);
                    menuOptionsList.Add("Buy Ticket:" + ticket.TicketID);
                }

                menuOptionsList.Add("Return to Festival Page");
                menuOptionsList.Add("Exit to Main Menu");
                MenuFunction.Menu(menuOptionsList.ToArray(), CurrentTicketListBuilder.GetCurrentTicketList().ToArray());
            }
        }
    }
}
