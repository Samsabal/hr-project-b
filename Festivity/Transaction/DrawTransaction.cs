using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Transaction
{
    class DrawTransaction
    {
        public static void Overview(int index, int amount)
        {
            Console.Clear();
            Ticket selectedTicket = CurrentTicketListBuilder.GetSelectedTicket(index);

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
