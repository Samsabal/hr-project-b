using System;

namespace Festivity.Transaction
{
    internal class ObjectSaver
    {
        public static void WriteToDatabase(Ticket ticket)
        {
            JSONTransactionList transactionList = JSONFunctionality.GetTransactions();
            DateTime now = DateTime.Now;
            string timeStamp = "" + now;

            TransactionModel transaction = new TransactionModel
            {
                TransactionID = CurrentTicketListBuilder.GetTransactionID(),
                FestivalID = (int)CatalogPage.selectedFestival,
                TicketID = ticket.TicketID,
                BuyerID = LoggedInAccount.GetID(),//(int)UserLoginPage.currentUserID,
                TicketAmount = DisplayManager.GetTicketAmount(),
                OrderDate = timeStamp
            };

            transactionList.Transactions.Add(transaction);
            JSONFunctionality.WriteTransactions(transactionList);
        }
    }
}