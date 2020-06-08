﻿using System;
using System.Collections.Generic;

namespace Festivity.Festival
{
    internal class Writer
    {
        public static void FestivalName(FestivalModel festival) // Displays the name of the current festival
        {
            Console.WriteLine($"X=============================================================================X");
            Console.WriteLine($"| {festival.FestivalName}".PadRight(77) + " |");
        }

        public static void FestivalAge(FestivalModel festival) // Display how old you have to be to enter the festival
        {
            Console.WriteLine($"|-----------------------------------------------------------------------------|");
            Console.WriteLine($"| You need to be at least {festival.FestivalAgeRestriction} years old in order to enter.".PadRight(77) + " |");
        }

        public static void Festival(FestivalModel festival) // Displays information about the current festival
        {
            Console.WriteLine($"|-----------------------------------------------------------------------------|");
            Console.WriteLine($"| Starts at {festival.FestivalStartingTime} and ends on {festival.FestivalEndTime}.".PadRight(77) + " |");
            Console.WriteLine($"| Takes place on: {festival.FestivalDate.Day}-{festival.FestivalDate.Month}-{festival.FestivalDate.Year}".PadRight(77) + " |");
            Console.WriteLine($"| ".PadRight(77) + " |");
            Console.WriteLine($"| {festival.FestivalLocation.StreetName} {festival.FestivalLocation.StreetNumber}, {festival.FestivalLocation.ZipCode}".PadRight(77) + " |");
            Console.WriteLine($"| {festival.FestivalLocation.City}, {festival.FestivalLocation.Country}".PadRight(77) + " |");
            Console.WriteLine($"|=============================================================================|");
        }

        public static void Tickets() // Displays the Tickets for the current Festival
        {
            foreach (var ticket in Transaction.TicketListBuilder.Get())
            {
                int ticketId = ticket.TicketID;
                int maxTickets = ticket.MaxTickets;
                Console.WriteLine($"| {ticket.TicketName}".PadRight(77) + " |");
                Console.WriteLine($"| Description: {ticket.TicketDescription}".PadRight(77) + " |");
                Console.WriteLine($"| Price: This ticket cost {ticket.TicketPrice} euros.".PadRight(77) + " |");
                Console.WriteLine($"| There are {ticket.MaxTickets} in total of which there are {Utils.TicketsLeft(ticketId, maxTickets)} left.".PadRight(77) + " |");
                Console.WriteLine($"|-----------------------------------------------------------------------------|");
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utils.ClearConsoleLine();
            Console.WriteLine($"X=============================================================================X");
        }

        public static void FestivalOrganiser(FestivalModel festival) // Displays the name of the organiser of the festival
        {
            foreach (var user in JSONFunctionality.GetUserList().Users)
            {
                if (festival.FestivalOrganiserID == user.AccountID)
                {
                    Console.WriteLine($"| Organised by: {user.CompanyName}".PadRight(77) + " |");
                }
            }
        }
    }
}