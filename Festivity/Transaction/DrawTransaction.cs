using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class DrawTransaction
    {
        public static void TransactionOverview(int index, int amount)
        {
            Console.Clear();
            Ticket selectedTicket = TransactionBuilder.GetSelectedTicket(index);

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Transaction Information");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(amount + " x " + selectedTicket.TicketName);
            Console.WriteLine(selectedTicket.TicketDescription);
            Console.WriteLine("€" + selectedTicket.TicketPrice + " / Ticket");
            Console.WriteLine("Total: €" + (Convert.ToInt32(selectedTicket.TicketPrice) * amount));
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}
