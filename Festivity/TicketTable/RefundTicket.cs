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
        private static List<string> TransactionIsRefundable = new List<string>();


        public static void InitiateRefund()
        {
            JSONTransactionList OldTransactionsList = JSONFunctionality.GetTransactions();
            JSONTransactionList NewTransactionsList = JSONFunctionality.GetTransactions();

            do
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                DrawTicketTable.Draw(); 
                userInput = UserRegisterPage.InputLoop("\nInput Transaction ID of the order you want to refund: "); }
            while (!IsValidTransactionID(userInput));

            NewTransactionsList.Transactions.Clear();

            foreach (var item in OldTransactionsList.Transactions)
            {
                if (item.TransactionID != int.Parse(userInput))
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionID = item.TransactionID,
                        FestivalID = item.FestivalID,
                        TicketID = item.TicketID,
                        BuyerID = item.BuyerID,
                        TicketAmount = item.TicketAmount,
                        OrderDate = item.OrderDate
                    };
                    NewTransactionsList.Transactions.Add(transaction);
                }
            }
            JSONFunctionality.WriteTransactions(NewTransactionsList);
            Console.WriteLine("Ticket Succesfully refunded");
            Thread.Sleep(2000);
        }

        private static bool IsValidTransactionID(string value)
        {
            if (Int32.TryParse(value, out int result))
            {
                for (int i = 0; i < TransactionIDList.Count; i++)
                {
                    if (TransactionIDList[i] == result.ToString())
                    {
                        if(TransactionIsRefundable[i].ToLower() == "true")
                        {
                            TransactionIDList.RemoveAt(i);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Ticket is not refundable.");
                            Thread.Sleep(2000);
                            return false;
                        }

                    }
                }
                Console.WriteLine("Transaction ID does not exist, please try again");
                Thread.Sleep(2000);
                return false;
            }
            Console.WriteLine("Invalid input, please try again");
            Thread.Sleep(2000);
            return false;
        }

        public static void SetTicketIDs(List<List<string>> ticketList)
        {
            
            for (int i = 0; i < ticketList.Count; i ++)
            {
                TransactionIDList.Add(ticketList[i][7]);
                TransactionIsRefundable.Add(ticketList[i][3]);
            }
        }
    }
}
