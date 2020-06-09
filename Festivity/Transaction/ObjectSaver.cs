using Festivity.Account;
using System;

namespace Festivity.Transaction
{
    internal class ObjectSaver
    {
        private static readonly JSONTransactionList transactionList = JSONFunctions.GetTransactions();

        public static void WriteToDatabase(TicketModel ticket)
        {
            string timeStamp = "" + DateTime.Now;

            TransactionModel transaction = new TransactionModel
            {
                TransactionID = GetTransactionID(),
                FestivalID = ticket.FestivalID,
                TicketID = ticket.TicketID,
                BuyerID = LoggedInModel.GetID(),
                TicketAmount = Handler.GetTicketAmount(),
                OrderDate = timeStamp
            };

            transactionList.Transactions.Add(transaction);
            JSONFunctions.WriteTransactions(transactionList);
        }

        private static int GetTransactionID()
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
    }
}