using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Festivity
{
    internal static class TicketTableListBuilder
    {
        private static readonly string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
        private static readonly JSONFestivalList festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

        private static readonly string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
        private static readonly JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

        private static readonly string PATH_TRANSACTION = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TransactionDatabase.json");
        private static readonly JSONTransactionList transactions = JsonConvert.DeserializeObject<JSONTransactionList>(File.ReadAllText(PATH_TRANSACTION));

        public static void Build()
        {
            List<List<string>> ticketList = new List<List<string>>();
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
                            tempList.Add(festival.check_status());
                        }
                    }
                    foreach (var ticket in tickets.tickets)
                    {
                        if (ticket.ticketId == transaction.ticketID)
                        {
                            tempList.Add(ticket.ticketName);
                            tempList.Add(ticket.ticketPrice.ToString());
                        }
                    }
                    tempList.Add(transaction.orderDate);
                    tempList.Add(Convert.ToString(transaction.transactionID));
                    tempList.Add(Convert.ToString(transaction.ticketAmount));
                    ticketList.Add(tempList);
                    index++;
                }
            }
            DrawTicketTable.SetTicketList(ticketList);
        }
    }
}