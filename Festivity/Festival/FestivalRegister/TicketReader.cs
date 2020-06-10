using System;
using Festivity.Utils;

namespace Festivity.FestivalRegister
{
    internal class TicketReader
    {
        public static void InputTicketName(TicketModel ticket, int ticketAmount)
        {
            do { ticket.TicketName = General.InputLoop($" Ticket name #{(ticketAmount + 1)} : "); }
            while (!RegexUtils.IsValidAddressName(ticket.TicketName));
        }

        public static void InputTicketDescription(TicketModel ticket)
        {
            do { ticket.TicketDescription = General.InputLoop(" Description: "); }
            while (!RegexUtils.IsValidDescription(ticket.TicketDescription));
        }

        public static void InputTickePrice(TicketModel ticket)
        {
            string tempTicketPrice;
            do { tempTicketPrice = General.InputLoop(" Ticket price: "); }
            while (!RegexUtils.IsValidPrice(tempTicketPrice));
            if (tempTicketPrice.Contains(","))
            {
                tempTicketPrice = tempTicketPrice.Replace(@",", @".");
            }
            ticket.TicketPrice = double.Parse(tempTicketPrice);
        }

        public static void InputMaxTickets(TicketModel ticket)
        {
            string tempMaxTickets;
            do { tempMaxTickets = General.InputLoop(" Total amount of tickets: "); }
            while (!RegexUtils.IsValidMaxTickets(tempMaxTickets));
            ticket.MaxTickets = int.Parse(tempMaxTickets);
        }

        public static void InputTicketMaxPerPerson(TicketModel ticket)
        {
            string tempTicketMaxPerPerson;
            do { tempTicketMaxPerPerson = General.InputLoop(" Max tickets per order: "); }
            while (!RegexUtils.IsValidMaxTicketsPerPerson(tempTicketMaxPerPerson));
            ticket.MaxTicketsPerPerson = int.Parse(tempTicketMaxPerPerson);
        }

        public static int InputTicketAmount()
        {
            string festivalAmountVariousTickets;
            do { festivalAmountVariousTickets = General.InputLoop(" Amount of ticket types: "); }
            while (!RegexUtils.NumberCheck(festivalAmountVariousTickets, 1, 20));
            ConsoleHelperFunctions.ClearCurrentConsole();
            return int.Parse(festivalAmountVariousTickets);
        }
    }
}