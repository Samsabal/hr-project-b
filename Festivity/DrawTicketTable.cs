using BetterConsoleTables;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class DrawTicketTable
    {
        /// <summary>
        /// Source: https://github.com/douglasg14b/BetterConsoleTables
        /// </summary>

        private static List<List<string>> TicketList;

        public static void CreateTable()
        {
            Table ticketTable = new Table("ID", "Festival name", "Festival date", "Ticket type", "Price",
                                          "Bought", "Amount", "Festival Status", "Refunable");

            for (int i = 0; i < TicketList.Count; i++)
            {
                ticketTable.AddRow($"{TicketList[i][5]}", $"{TicketList[i][0]}", $"{TicketList[i][1]}",
                                   $"{TicketList[i][3]}", $"{TicketList[i][4]}", $"{TicketList[i][6]}",
                                   $"{TicketList[i][7]}", $"{TicketList[i][2]}", "NULL");
            }
            ticketTable.Config = TableConfiguration.Markdown(); //Ticket Table Themes (See Link)-(Markdown, Unicode, MySqlSimple, MySql, Markdown)

            Console.Write(ticketTable.ToString()); 
        }

        public static void Draw()
        {
            Console.ReadKey();
        }

        public static void SetTicketList(List<List<string>> ticketList)
        {
            TicketList = ticketList;
        }
    }
}