using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity.TicketTable
{
    internal class Refund
    {
        private static string userInput;
        private static readonly List<string> transactionIDList = new List<string>();
        private static readonly List<string> transactionIsRefundable = new List<string>();

        public static void InitiateRefund()
        {
            JSONTransactionList OldTransactionsList = JSONFunctions.GetTransactions();
            JSONTransactionList NewTransactionsList = JSONFunctions.GetTransactions();

            do
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Drawer.DrawTable();
                userInput = Utils.General.InputLoop("\nInput Transaction ID of the order you want to refund: ");
            }
            while (!IsValidTransactionID(userInput));

            NewTransactionsList.Transactions.Clear();

            foreach (var item in OldTransactionsList.Transactions)
            {
                if (item.TransactionID != int.Parse(userInput))
                {
                    TransactionModel transaction = new TransactionModel
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
            JSONFunctions.WriteTransactions(NewTransactionsList);
            Console.WriteLine("Transaction Succesfully refunded");
            Thread.Sleep(2000);
            ConsoleHelperFunctions.ClearCurrentConsole();
        }

        private static bool IsValidTransactionID(string value)
        {
            if (Int32.TryParse(value, out int result))
            {
                for (int i = 0; i < transactionIDList.Count; i++)
                {
                    if (transactionIDList[i] == result.ToString())
                    {
                        if (transactionIsRefundable[i].ToLower() == "true")
                        {
                            transactionIDList.RemoveAt(i);
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
            for (int i = 0; i < ticketList.Count; i++)
            {
                transactionIDList.Add(ticketList[i][7]);
                transactionIsRefundable.Add(ticketList[i][3]);
            }
        }
    }
}