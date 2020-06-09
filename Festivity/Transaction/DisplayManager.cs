using System;
using System.Threading;

namespace Festivity.Transaction
{
    internal class DisplayManager
    {
        private static int TicketAmount { get; set; }
        private static Ticket selectedTicket;

        public static void Initiate(int selectedOption)
        {
            TicketAmount = InputReader.TicketAmount();
            selectedTicket = TicketListBuilder.GetSelectedTicket(selectedOption);
            Writer.Overview(selectedTicket, TicketAmount);
            if (InputReader.ConfirmTransaction()) { InputReader.PaymentOption(); }
        }

        public static void Complete()
        {
            ObjectSaver.WriteToDatabase(selectedTicket);
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