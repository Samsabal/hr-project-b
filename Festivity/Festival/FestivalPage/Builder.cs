using System;
using System.Collections.Generic;

namespace Festivity.FestivalPage
{
    internal class Builder
    {
        private static readonly JSONTransactionList transactions = JSONFunctions.GetTransactions();

        public static int TicketsLeft(int ticketId, int maxTickets)
        {
            List<TransactionModel> TransactionList = new List<TransactionModel>();
            int ticketsLeft = maxTickets;

            foreach (var transaction in transactions.Transactions)
            {
                if (transaction.TicketID == ticketId)
                {
                    TransactionList.Add(transaction);
                }
            }
            foreach (var transaction in TransactionList)
            {
                ticketsLeft -= transaction.TicketAmount;
            }

            return ticketsLeft;
        }

        public static void DescriptionParts() // Splits up the description in parts that fit in the festival page and displays them
        {
            int DescriptionLength = Festival.SelectedFestival.Festival.FestivalDescription.Length;
            int LineCount = 0;

            while (DescriptionLength > 65 * LineCount)
            {
                if (DescriptionLength - 65 * LineCount > 65)
                {
                    Console.WriteLine("  " + Festival.SelectedFestival.Festival.FestivalDescription.Substring(65 * LineCount, 65));
                    LineCount += 1;
                }
                else
                {
                    Console.WriteLine($"  {Festival.SelectedFestival.Festival.FestivalDescription.Substring(65 * LineCount)}");
                    LineCount += 1;
                }
            }
        }

        public static void TicketDescription(int ticketId) // Splits up the description in parts that fit in the festival page and displays them
        {
            foreach (var ticket in Transaction.TicketListBuilder.Get())
            {
                if (ticketId == ticket.TicketID)
                {
                    int DescriptionLength = ticket.TicketDescription.Length;
                    int LineCount = 0;

                    while (DescriptionLength > 65 * LineCount)
                    {
                        if (DescriptionLength - 65 * LineCount > 65)
                        {
                            Console.WriteLine("  " + ticket.TicketDescription.Substring(65 * LineCount, 65));
                            LineCount += 1;
                        }
                        else
                        {
                            Console.WriteLine($"  {ticket.TicketDescription.Substring(65 * LineCount)}");
                            LineCount += 1;
                        }
                    }
                }
            }
        }
    }
}