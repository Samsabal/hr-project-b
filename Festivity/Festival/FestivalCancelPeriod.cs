using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Festivity
{
    internal class FestivalCancelPeriod
    {
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();
        private static readonly JSONTransactionList transactions = JSONFunctionality.GetTransactions();

        public static List<Transaction> transactionList { get; set; }
        public static List<Festival> festivalList { get; set; }

        public static Festival GetFestival(int festivalID)
        {
            foreach (Festival festival in festivalList)
            {
                if (festival.FestivalID == festivalID)
                {
                    return festival;
                }
            }
            return null;
        }

        public static int GetCancelTime(int festivalID)
        { 
            foreach (Festival festival in festivalList)
            {
                if (festival.FestivalID == festivalID)
                {
                    return festival.FestivalCancelTime;
                }
            }
            return 0;
        }

        public static bool IsRefundable(int transactionID)
        {
            foreach (var transaction in transactionList)
            {
                if (transactionID == transaction.TransactionID)
                {
                    
                    if (GetCancelTime(transaction.FestivalID) > 0 && DateTime.Now.AddDays( GetFestival(transaction.FestivalID).FestivalCancelTime * 7) < (GetFestival(transaction.TransactionID).FestivalDate))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
