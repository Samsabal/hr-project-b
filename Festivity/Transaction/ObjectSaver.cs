using System;

namespace Festivity.Transaction
{
    internal class ObjectSaver
    {
        private static readonly JSONTransactionList transactionList = JSONFunctionality.GetTransactions();

        public static void WriteToDatabase(Ticket ticket)
        {
            DateTime now = DateTime.Now;
            string timeStamp = "" + now;

            TransactionModel transaction = new TransactionModel
            {
                TransactionID = GetTransactionID(),
                FestivalID = (int)CatalogPage.selectedFestival,
                TicketID = ticket.TicketID,
                BuyerID = LoggedInAccount.GetID(),//(int)UserLoginPage.currentUserID,
                TicketAmount = DisplayManager.GetTicketAmount(),
                OrderDate = timeStamp
            };

            transactionList.Transactions.Add(transaction);
            JSONFunctionality.WriteTransactions(transactionList);
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