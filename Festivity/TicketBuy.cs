using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Festivity
{
    class TicketBuy
    {
        public static int ticketListLength;
        public static Ticket[] ticketArray;
        public static void ticket_buy(int festivalId)
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
            JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

            List<int> ticketList = new List<int>();
            
            // Gets all Tickets related to the current Festival
            foreach (var ticket in tickets.tickets)
            {
                foreach (var festival in festivals.festivals)
                {
                    if (festivalId == festival.festivalId)
                    {
                        ticketList.Add(ticket.ticketId);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
            }

            int[] ticketCount = ticketList.ToArray();
            ticketListLength = ticketCount.Length;

            MenuFunction.option = 0;

            List<string> menuOptionsList = new List<string>();
            List<Ticket> ticketArrayList = new List<Ticket>();

            foreach (var ticketId in ticketList)
            {
                foreach (var ticket in tickets.tickets)
                {
                    if (ticket.ticketId == ticketId)
                    {
                        ticketArrayList.Add(ticket);
                        menuOptionsList.Add("Order Ticket " + ticketId );
                    }
                }

            }
            menuOptionsList.Add("Return to Festival Page");
            menuOptionsList.Add("Exit to Main Menu");

            string[] menuOptions = menuOptionsList.ToArray();
            ticketArray = ticketArrayList.ToArray();

            while (true)
            {
                string line = "----------------------------------------------------------------------";
                // Displays the Tickets for the current Festival
                foreach (var ticketId in ticketList)
                {
                    foreach (var ticket in tickets.tickets)
                    {
                        if (ticket.ticketId == ticketId)
                        {
                            Console.WriteLine(ticket.ticketName);
                            Console.WriteLine("Description: " + ticket.ticketDescription);
                            Console.WriteLine("Price: " + ticket.ticketPrice + " euros");
                            Console.WriteLine(line);
                        }
                    }
                }
                MenuFunction.menu(menuOptions, null, ticketArray);
                Console.Clear();
            }
        }
    }
}
