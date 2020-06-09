using Festivity.Account;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity.TicketTable
{
    internal static class Builder
    {
        private static readonly List<List<string>> ticketList = new List<List<string>>();

        public static bool Build()
        {
            JSONFestivalList festivals = JSONFunctions.GetFestivals();
            JSONTransactionList transactions = JSONFunctions.GetTransactions();
            JSONTicketList tickets = JSONFunctions.GetTickets();
            ticketList.Clear();

            int index = 0;
            foreach (var transaction in transactions.Transactions)
            {
                if (transaction.BuyerID == LoggedInModel.GetID())
                {
                    List<string> tempList = new List<string>();
                    foreach (var festival in festivals.Festivals)
                    {
                        if (festival.FestivalID == transaction.FestivalID)
                        {
                            tempList.Add(festival.FestivalName);
                            tempList.Add(festival.FestivalDate.ToShortDateString());
                            tempList.Add(festival.CheckStatusTicketTable());
                            tempList.Add(festival.IsRefundable().ToString());
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
                Refund.SetTicketIDs(ticketList);
                Drawer.SetTicketList(ticketList);
                return true;
            }
            ErrorMessage.WriteLine("Sorry, you don't have any Tickets");
            Thread.Sleep(2000);
            ConsoleHelperFunctions.ClearCurrentConsole();
            return false;
        }
    }
}