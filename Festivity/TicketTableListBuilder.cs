using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Festivity
{
    internal static class TicketTableListBuilder
    {
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();
        private static readonly JSONTransactionList transactions = JSONFunctionality.GetTransactions();

        public static void Build()
        {
            List<List<string>> ticketList = new List<List<string>>();
            int index = 0;
            foreach (var transaction in transactions.Transactions)
            {
                if (transaction.BuyerID == UserLoginPage.currentUserID)
                {
                    List<string> tempList = new List<string>();
                    foreach (var festival in festivals.Festivals)
                    {
                        if (festival.FestivalID == transaction.FestivalID)
                        {
                            tempList.Add(festival.FestivalName);
                            tempList.Add(Convert.ToString(festival.FestivalDate.Day + "/" + festival.FestivalDate.Month + "/" + festival.FestivalDate.Year));
                            tempList.Add(festival.CheckStatus());
                        }
                    }
                    foreach (var ticket in tickets.Tickets)
                    {
                        if (ticket.TicketID == transaction.TicketID)
                        {
                            tempList.Add(ticket.TicketName);
                            tempList.Add(ticket.TicketPrice.ToString());
                        }
                    }
                    tempList.Add(transaction.OrderDate);
                    tempList.Add(Convert.ToString(transaction.TransactionID));
                    tempList.Add(Convert.ToString(transaction.TicketAmount));
                    ticketList.Add(tempList);
                    index++;
                }
            }
            if (index > 0)
            {
                RefundTicket.SetTicketIDs(ticketList);
                DrawTicketTable.SetTicketList(ticketList);
            }
        }
    }
}