using Festivity.Account;
using System.Collections.Generic;

namespace Festivity.AccountPage
{
    internal class Utils
    {
        private static readonly JSONFestivalList festivals = JSONFunctions.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctions.GetTickets();
        private static readonly JSONTransactionList transactions = JSONFunctions.GetTransactions();

        public static double AmountEarned()
        {
            List<TicketModel> ticketList = new List<TicketModel>();
            double amountEarned = 0.0;

            foreach (var festival in festivals.Festivals)
            {
                if (LoggedInModel.GetID() == festival.FestivalOrganiserID)
                {
                    foreach (var ticket in tickets.Tickets)
                    {
                        if (festival.FestivalID == ticket.FestivalID)
                        {
                            ticketList.Add(ticket);
                        }
                    }
                }
            }

            foreach (var transaction in transactions.Transactions)
            {
                foreach (var organiserTicket in ticketList)
                {
                    if (organiserTicket.TicketID == transaction.TicketID)
                    {
                        amountEarned += organiserTicket.TicketPrice * transaction.TicketAmount;
                    }
                }
            }
            return amountEarned;
        }
    }
}