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

        public static void InitiateRefund()
        {
            do
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                DrawTicketTable.DrawRefund(); 
                userInput = UserRegisterPage.InputLoop("\nInput Transaction ID of ticket you want to refund: "); }
            while (!IsValidTransactionID(userInput));

            // Remove ticket here

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
