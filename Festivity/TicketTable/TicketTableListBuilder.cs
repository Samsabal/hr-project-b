using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal static class TicketTableListBuilder
    {
        private static List<List<string>> ticketList = new List<List<string>>();

        public static bool Build()
        {
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();
            JSONTransactionList transactions = JSONFunctionality.GetTransactions();
            JSONTicketList tickets = JSONFunctionality.GetTickets();
            ticketList.Clear();

            int index = 0;
            foreach (var transaction in transactions.Transactions)
            {
                if (transaction.BuyerID == LoggedInAccount.GetID())
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
                RefundTicket.SetTicketIDs(ticketList);
                DrawTicketTable.SetTicketList(ticketList);
                return true;
            }
            Console.WriteLine("Sorry, you don't have any Tickets");
            Thread.Sleep(3000);
            ConsoleHelperFunctions.ClearCurrentConsole();
            return false;
        }
    }
}