using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TransactionCalc
    {
        public static void WriteToDatabase(Ticket ticket)
        {
            JSONTransactionList transactionList = JSONFunctionality.GetTransactions();
            DateTime now = DateTime.Now;
            string timeStamp = "" + now;

            Transaction transaction = new Transaction
            {
                TransactionID = TransactionBuilder.GetTransactionID(),
                FestivalID = (int)CatalogPage.selectedFestival,
                TicketID = ticket.TicketID,
                BuyerID = LoggedInAccount.GetID(),//(int)UserLoginPage.currentUserID, 
                TicketAmount = TransactionManager.GetTicketAmount(),
                OrderDate = timeStamp
            };

            transactionList.Transactions.Add(transaction);
            JSONFunctionality.WriteTransactions(transactionList);
        }
    }
}
