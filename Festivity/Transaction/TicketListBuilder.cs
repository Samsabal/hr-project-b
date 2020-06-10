using System.Collections.Generic;

namespace Festivity.Transaction
{
    internal class TicketListBuilder
    {
        private static List<TicketModel> TicketList { get; set; }

        public static void Set(int festivalId)
        {
            TicketList = new List<TicketModel>();

            foreach (var ticket in JSONFunctions.GetTickets().Tickets)
            {
                if (festivalId == ticket.FestivalID)
                {
                    TicketList.Add(ticket);
                }
            }
        }

        public static TicketModel GetSelectedTicket(int ticketIndex)
        {
            foreach (var ticket in Get())
            {
                if (ticket.TicketID == ticketIndex)
                {
                    return ticket;
                }
            }
            return Get()[0];
        }

        public static List<TicketModel> Get()
        {
            return TicketList;
        }

        public static int GetLength()
        {
            return TicketList.ToArray().Length;
        }
    }
}