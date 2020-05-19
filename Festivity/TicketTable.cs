using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using BetterConsoleTables;

namespace Festivity
{
    class TicketTable
    {
        static string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
        static JSONFestivalList festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

        static string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
        static JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

        static string PATH_TRANSACTION = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TransactionDatabase.json");
        static JSONTransactionList transactions = JsonConvert.DeserializeObject<JSONTransactionList>(File.ReadAllText(PATH_TRANSACTION));


        public static void create_ticket_table_list()
        {
            List<List<string>> tableList = new List<List<string>>();
            int index = 0;
            foreach (var transaction in transactions.transactions)
            {
                if (transaction.buyerID == UserLoginPage.currentUserId)
                {
                    List<string> tempList = new List<string>();
                    foreach (var festival in festivals.festivals)
                    {
                        if (festival.festivalId == transaction.festivalID)
                        {
                            tempList.Add(festival.festivalName);
                            tempList.Add(Convert.ToString(festival.festivalDate.day + "/" + festival.festivalDate.month + "/" + festival.festivalDate.year));
                        }
                    }
                    foreach (var ticket in tickets.tickets)
                    {
                        if (ticket.ticketId == transaction.ticketID)
                        {
                            tempList.Add(ticket.ticketName);
                            tempList.Add(ticket.ticketPrice);
                        }
                    }
                    tempList.Add(transaction.orderDate);
                    tempList.Add(Convert.ToString(transaction.transactionID));
                    tempList.Add(Convert.ToString(transaction.ticketAmount));
                    tableList.Add(tempList);
                    index++;
                }
            }
            draw_ticket_table(tableList);
        }
        public static void draw_ticket_table(List<List<string>> tableList)
        {
            // Source: https://github.com/douglasg14b/BetterConsoleTables
            Table ticketTable = new Table("ID", "Festival name", "Festival date", "Ticket type", "Price", 
                                          "Bought", "Amount", "Festival Status", "Refunable");
            for (int i = 0; i < tableList.Count - 1; i++)
            {
                ticketTable.AddRow($"{tableList[i][5]}",$"{tableList[i][0]}",$"{tableList[i][1]}", 
                                   $"{tableList[i][2]}",$"{tableList[i][3]}",$"{tableList[i][4]}",
                                   $"{tableList[i][6]}", "NULL", "NULL");
            }
            ticketTable.Config = TableConfiguration.Markdown(); //Ticket Table Themes (See Link)-(Markdown, Unicode, MySqlSimple, MySql, Markdown)
           


            Console.Write(ticketTable.ToString());
            Console.ReadKey();
        }
        public static void ticket_table_menu()
        {
            create_ticket_table_list();
            Console.WriteLine();
            //while (true)
            //{
            //    Console.Write(ticketTable.ToString());
            //    MenuFunction.menu(new string[] { "Refund Ticket", "Exit to Main Menu"});
            //}
        }
        public static void refund_ticket()
        {
              
        }
    }
}



