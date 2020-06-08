using System;

namespace Festivity.FestivalRegister
{
    class TicketModifier
    {
        public static void InputTicketName(Ticket ticket, int ticketAmount)
        {
            do { ticket.TicketName = InputLoop($"Fill in the ticket name of ticket {(ticketAmount + 1)} : "); }
            while (!RegexUtils.IsValidAddressName(ticket.TicketName));
        }

        public static void InputTicketDescription(Ticket ticket)
        {
            do { ticket.TicketDescription = InputLoop("Fill in the ticket description: "); }
            while (!RegexUtils.IsValidDescription(ticket.TicketDescription));
        }

        public static void InputTickePrice(Ticket ticket)
        {
            string tempTicketPrice;
            do { tempTicketPrice = InputLoop("Fill in the price of the ticket in euros: "); }
            while (!RegexUtils.IsValidPrice(tempTicketPrice));
            ticket.TicketPrice = double.Parse(tempTicketPrice);
        }

        public static void InputMaxTickets(Ticket ticket)
        {
            string tempMaxTickets;
            do { tempMaxTickets = InputLoop("Fill in the maximum amount of available tikets of this ticket type: "); }
            while (!RegexUtils.IsValidMaxTickets(tempMaxTickets));
            ticket.MaxTickets = int.Parse(tempMaxTickets);
        }

        public static void InputTicketMaxPerPerson(Ticket ticket)
        {
            string tempTicketMaxPerPerson;
            do { tempTicketMaxPerPerson = InputLoop("Fill in the maximum amount of tickets a single person may buy: "); }
            while (!RegexUtils.IsValidMaxTicketsPerPerson(tempTicketMaxPerPerson));
            ticket.MaxTicketsPerPerson = int.Parse(tempTicketMaxPerPerson);
        }

        public static int InputTicketAmount()
        {
            string festivalAmountVariousTickets;
            Console.Clear();
            do { festivalAmountVariousTickets = InputLoop("Fill in the amount of various tickets as a number: "); }
            while (!RegexUtils.NumberCheck(festivalAmountVariousTickets, 1, 20));

            return int.Parse(festivalAmountVariousTickets);
        }

        private static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }
    }
}
