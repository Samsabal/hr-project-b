using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TransactionManager
    {
        private static int TicketAmount { get; set; }
        private static int indexTicket;
        public static void Initiate(int option)
        {
            indexTicket = option;
            TicketAmount = TransactionReader.TicketAmountInput();
            DrawTransaction.TransactionOverview(indexTicket, TicketAmount);
            TransactionReader.ConfirmTransactionInput();
        }

        public static void TransactionComplete()
        {
            TransactionCalc.WriteToDatabase(TransactionBuilder.GetSelectedTicket(indexTicket));
            Console.WriteLine("Ordered Succesfully!");
            Thread.Sleep(2000);
            Console.Clear();
            FestivalPage.ShowFestivalPage(CatalogPage.selectedFestival);
        }

        public static int GetTicketAmount()
        {
            return TicketAmount;
        }

    }
}
