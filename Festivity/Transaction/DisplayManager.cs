using System;
using System.Threading;

namespace Festivity.Transaction
{
    internal class DisplayManager
    {
        private static int TicketAmount { get; set; }
        private static int indexTicket;

        public static void Initiate(int option)
        {
            indexTicket = option;
            TicketAmount = InputReader.TicketAmount();
            Writer.Overview(TicketListBuilder.GetSelectedTicket(indexTicket), TicketAmount);
            if (InputReader.ConfirmTransaction()) { InputReader.PaymentOption(); }
        }

        public static void Complete()
        {
            ObjectSaver.WriteToDatabase(TicketListBuilder.GetSelectedTicket(indexTicket));
            Console.WriteLine("Ordered Succesfully!");
            Thread.Sleep(2000);
            Console.Clear();
            Festival.PageManager.Display(SelectedFestival.festival.FestivalID);
        }

        public static int GetTicketAmount()
        {
            return TicketAmount;
        }
    }
}