﻿using System;
using System.Text;

namespace Festivity.Transaction
{
    internal class Writer
    {
        public static void Overview(TicketModel selectedTicket, int amount)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Transaction Information");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(amount + " x " + selectedTicket.TicketName);
            Console.WriteLine(selectedTicket.TicketDescription);
            Console.WriteLine("€" + selectedTicket.TicketPrice + " / Ticket");
            Console.WriteLine("Total: € "+ (selectedTicket.TicketPrice * amount).ToString("F2"));
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}