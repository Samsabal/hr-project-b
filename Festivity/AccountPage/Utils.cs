using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.AccountPage
{
    class Utils
    {
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();
        private static readonly JSONTransactionList transactions = JSONFunctionality.GetTransactions();

        public static double AmountEarned()
        {
            List<Ticket> ticketList = new List<Ticket>();
            double amountEarned = 0.0;


            foreach (var festival in festivals.Festivals)
            {
                if (LoggedInAccount.GetID() == festival.FestivalOrganiserID)
                {
                    foreach (var ticket in tickets.Tickets)
                    {
                        if (festival.FestivalID == ticket.FestivalID)
                        {
                            ticketList.Add(ticket);
                        }
                    }
                }
            }

            foreach (var transaction in transactions.Transactions)
            {
                foreach (var organiserTicket in ticketList)
                {
                    if (organiserTicket.TicketID == transaction.TicketID)
                    {
                        amountEarned += organiserTicket.TicketPrice * transaction.TicketAmount;
                    }
                }
            }
            return amountEarned;
        }

        public static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            return userInput;
        }

        public static bool IsValidAccountChange(string userInput, int max)
        {
            return RegexUtils.NumberCheck(userInput, 1, max);
        }
        public static int GetOptionAmount()
        // Returns 8 if logged in user is a Visitor, if not it returns 9. For the amount of Account Changing options.
        {
            return LoggedInAccount.User.AccountType == 2 ? 8 : 9;
        }

    }
}
