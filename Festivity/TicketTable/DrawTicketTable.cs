using BetterConsoleTables;
using Festivity.Utils;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class DrawTicketTable
    {
        /// <summary> Source: https://github.com/douglasg14b/BetterConsoleTables </summary>

        private static List<List<string>> TicketList;
        private static Table ticketTable;

        public static void CreateTable()
        {
            if (TicketList.Count > 0)
            {
                ticketTable = new Table("ID", "Name", "Festival Date", "Ticket Name", "Price",
                              "Bought", "Amount", "Status", "Refundable");

                for (int i = 0; i < TicketList.Count; i++)
                {
                    ticketTable.AddRow($"{TicketList[i][7]}", $"{General.SetStringLength(TicketList[i][0], 8)}", $"{TicketList[i][1]}",
                                       $"{General.SetStringLength(TicketList[i][4], 13)}", $"{TicketList[i][5]}", $"{General.SetStringLength(TicketList[i][6], 13)}",
                                       $"{TicketList[i][8]}", $"{TicketList[i][2]}", $"{TicketList[i][3]}");
                }
                ticketTable.Config = TableConfiguration.Markdown(); //Ticket Table Themes (See Link)-(Markdown, Unicode, MySqlSimple, MySql, Markdown)
            }
        }

        public static void DrawTicketTablePage()
        {
            while (TicketTableListBuilder.Build())
            {
                DrawTable();
                Menu.Draw(TicketTableMenu.GenreMenuBuilder());
            }
        }

        public static void DrawTable()
        {
            CreateTable();
            Console.Write(ticketTable.ToString());
            Console.WriteLine();
        }

        public static void DrawRefund()
        {
            Console.Write(ticketTable.ToString());
        }

        public static void SetTicketList(List<List<string>> ticketList)
        {
            TicketList = ticketList;
        }
    }
}