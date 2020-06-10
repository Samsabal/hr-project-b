using Festivity.Festival;
using System;
using System.Threading;

namespace Festivity.Transaction
{
    internal class Handler
    {
        private static int TicketAmount { get; set; }
        private static TicketModel selectedTicket;

        public static void Initiate(int selectedOption)
        {
            TicketAmount = Reader.TicketAmount(selectedOption);
            selectedTicket = TicketListBuilder.GetSelectedTicket(selectedOption);
            Writer.Overview(selectedTicket, TicketAmount);
            if (Reader.ConfirmTransaction()) { Reader.PaymentOption(); }
        }

        public static void Complete()
        {
            ObjectSaver.WriteToDatabase(selectedTicket);
            Console.WriteLine("Ordered Succesfully!");
            Thread.Sleep(2000);
            Console.Clear();
            FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
        }

        public static int GetTicketAmount()
        {
            return TicketAmount;
        }
    }
}