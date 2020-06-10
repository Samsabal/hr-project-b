using System;

namespace Festivity.Transaction
{
    internal class Writer
    {
        private static UIElements UI = new UIElements("Festivals", "Transaction");
        public static void Overview(TicketModel selectedTicket, int amount)
        {
            UI.Pom(" Transaction Information");
            //Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($" {amount} x {selectedTicket.TicketName})");
            Console.WriteLine($" {selectedTicket.TicketDescription}");
            Console.WriteLine($" €{selectedTicket.TicketPrice} / Ticket");
            Console.WriteLine($" Total: €{(selectedTicket.TicketPrice * amount).ToString("F2")}");
            UI.Line();
        }
    }
}