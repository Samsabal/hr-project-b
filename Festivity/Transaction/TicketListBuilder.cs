using System.Collections.Generic;

namespace Festivity.Transaction
{
    internal class TicketListBuilder
    {
        private static List<Ticket> TicketList { get; set; }

        public static void Set(int festivalId)
        {
            TicketList = new List<Ticket>();

            foreach (var ticket in JSONFunctionality.GetTickets().Tickets)
            {
                if (festivalId == ticket.FestivalID)
                {
                    TicketList.Add(ticket);
                }
            }
        }

        public static Ticket GetSelectedTicket(int ticketIndex)
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

        public static List<Ticket> Get()
        {
            return TicketList;
        }

        public static int GetLength()
        {
            return TicketList.ToArray().Length;
        }
    }
}