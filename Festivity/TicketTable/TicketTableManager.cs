using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TicketTableManager
    {
        public static void Initiate()
        {
            if (TicketTableListBuilder.Build())
            {
                DrawTicketTable.CreateTable();
                DrawTicketTable.Menu();
            }
        }
    }
}
