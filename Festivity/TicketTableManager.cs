using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TicketTableManager
    {
        public static void Initiate()
        {
            TicketTableListBuilder.Build();
            DrawTicketTable.CreateTable();
            DrawTicketTable.Draw();
        }

        public static void RefundTicket()
        {

        }
    }
}
