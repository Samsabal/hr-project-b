namespace Festivity.Festival
{
    class Utils
    {
        public static int TicketsLeft(int ticketId, int maxTickets)
        {
            foreach (var ticket in JSONFunctionality.GetTickets().Tickets)
            {
                if (ticket.TicketID == ticketId)
                {
                    foreach (var transaction in JSONFunctionality.GetTransactions().Transactions)
                    {
                        if (transaction.TicketID == ticket.TicketID)
                        {
                            int ticketsLeft = ticket.MaxTickets - transaction.TicketAmount;
                            return ticketsLeft;
                        }
                    }
                }
            }
            return maxTickets;
        }
    }
}
