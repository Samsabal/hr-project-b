using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity
{
    class RefundTicket
    {
        private static string userInput;
        private static List<string> TransactionIDList = new List<string>();
        private static readonly JSONTransactionList transactions = JSONFunctionality.GetTransactions();
        
        private static JSONTransactionList newTransactions = new JSONTransactionList();
        public static List<Transaction> newTransactionList { get; set; }

        public static void InitiateRefund()
        {
            do
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                DrawTicketTable.DrawRefund(); 
                userInput = UserRegisterPage.InputLoop("\nInput Transaction ID of the order you want to refund: "); }
            while (!IsValidTransactionID(userInput));


            newTransactionList = new List<Transaction>();

            for (int i = 0; i < transactions.Transactions.Count; i++)
            {
                if(transactions.Transactions[i].TransactionID != int.Parse(userInput))
                {
                    Transaction newtransaction = new Transaction
                    {
                        TransactionID = transactions.Transactions[i].TransactionID,
                        FestivalID = transactions.Transactions[i].FestivalID,
                        TicketID = transactions.Transactions[i].TicketID,
                        BuyerID = transactions.Transactions[i].BuyerID,
                        TicketAmount = transactions.Transactions[i].TicketAmount,
                        OrderDate = transactions.Transactions[i].OrderDate
                    };

                    newTransactionList.Add(newtransaction);
                }
            }

            foreach (var transaction in newTransactionList)
            {
                newTransactions.Transactions.Add(transaction);
            }

            JSONFunctionality.WriteTransactions(newTransactions);
        }

        private static bool IsValidTransactionID(string value)
        {
            if (Int32.TryParse(value, out int result))
            {
                if (TransactionIDList.Contains(result.ToString()))
                {
                    return true;
                }
                Console.WriteLine("Transaction ID does not exist, please try again");
                Thread.Sleep(1000);
                return false;
            }
            return false;
        }

        public static void SetTicketIDs(List<List<string>> ticketList)
        {
            
            for (int i = 0; i < ticketList.Count; i ++)
            {
                TransactionIDList.Add(ticketList[i][6]);
            }
        }
    }
}
