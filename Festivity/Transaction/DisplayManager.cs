using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Transaction
{
    class DisplayManager
    {
        private static int TicketAmount { get; set; }
        private static int indexTicket;
        public static void Initiate(int option)
        {
            indexTicket = option;
            InputReader.TicketAmount();
            Writer.Overview(CurrentTicketListBuilder.GetSelectedTicket(indexTicket), TicketAmount);
            if (InputReader.ConfirmTransaction()) { InputReader.PaymentOption(); }
        }

        public static void TransactionComplete()
        {
            ObjectSaver.WriteToDatabase(CurrentTicketListBuilder.GetSelectedTicket(indexTicket));
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
