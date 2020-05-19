using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

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

        public static void ticket_table_page()
        {
            List<List<string>> tableList = new List<List<string>>();

            int index = 0;

            foreach (var transaction in transactions.transactions)
            {
                if(transaction.buyerID == UserLoginPage.currentUserId)
                {
                    List<string> tempList = new List<string>();
                    foreach (var festival in festivals.festivals)
                    {
                        if (festival.festivalId == transaction.festivalID)
                        {
                            tempList.Add(festival.festivalName);
                            tempList.Add(Convert.ToString(festival.festivalDate.day + "/" + festival.festivalDate.month + "/" + festival.festivalDate.year ));
                        }                    
                    } 
                    foreach (var ticket in tickets.tickets)
                    {
                        if(ticket.ticketId == transaction.ticketID)
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
            Console.WriteLine("------------------------------------------------ Ticket Table -----------------------------------------------------");
            Console.WriteLine("Festival Name  |  Festival Date  | Ticket Name  |  Order date  |  Ticket Price  |  Transaction ID  |  Ticket Amount");
            for (int i = 0; i < tableList.Count-1; i++) 
            {
                Console.WriteLine($"{tableList[i][0]}\t{tableList[i][1]}\t{tableList[i][2]}\t{tableList[i][3]}\t{tableList[i][4]}\t{tableList[i][5]}\t{tableList[i][6]}");
            }
            Console.ReadLine();
        }
    }
}

//if ()
// festival name
// festival date
// ticket name
// order date
// ticket price
//Console.WriteLine($"{transaction.transactionID}");
//Console.WriteLine($"{transaction.ticketAmount}");


