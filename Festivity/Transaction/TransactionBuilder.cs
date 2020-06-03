using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TransactionBuilder
    {
        private static List<Ticket> CurrentTicketList { get; set; }
        private static readonly JSONTransactionList transactionList = JSONFunctionality.GetTransactions();

        public static void SetCurrentTicketList(int festivalId)
        {
            CurrentTicketList = new List<Ticket>();

            foreach (var ticket in JSONFunctionality.GetTickets().Tickets)
            {
                if (festivalId == ticket.FestivalID)
                {
                    CurrentTicketList.Add(ticket);
                }
            }
        }

        public static List<Ticket> GetCurrentTicketList()
        {
            return CurrentTicketList;
        }

        public static int GetTransactionID()
        {
            int transactionID;
            if (transactionList.Transactions.Count == 0)
            {
                transactionID = 1;
            }
            else
            {
                int item = transactionList.Transactions[^1].TransactionID;
                transactionID = item + 1;
            };

            return transactionID;
        }

        public static int GetTicketListLength()
        {
            return CurrentTicketList.ToArray().Length;
        }

        public static Ticket GetSelectedTicket(int option)
        {
            return GetCurrentTicketList()[option];
        }
    }
}
