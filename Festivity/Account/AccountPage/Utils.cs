﻿using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity.AccountPage
{
    internal class Utils
    {
        private static readonly JSONFestivalList festivals = JSONFunctions.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctions.GetTickets();
        private static readonly JSONTransactionList transactions = JSONFunctions.GetTransactions();

        public static double AmountEarned()
        {
            List<TicketModel> ticketList = new List<TicketModel>();
            double amountEarned = 0.0;

            foreach (var festival in festivals.Festivals)
            {
                if (LoggedInModel.GetID() == festival.FestivalOrganiserID)
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
        // Returns 8 if logged in user is a Visitor, if not it returns 9. For the amount of Account
        // Changing options.
        {
            return LoggedInModel.User.AccountType == 2 ? 8 : 9;
        }
    }
}