﻿using System;
using System.Collections.Generic;

namespace Festivity.FestivalRegister
{
    internal class Modifier
    {
        public static void InputFestivalName(FestivalModel festival)
        {
            do { festival.FestivalName = InputLoop("Fill in the name of the festival: "); }
            while (!RegexUtils.IsValidName(festival.FestivalName));
        }

        public static void InputCancelTime(FestivalModel festival)
        {
            string tempCancelTime;
            do { tempCancelTime = InputLoop("Fill in the amount of days before the start of the festival a customer is allowed to cancel their order: "); }
            while (!RegexUtils.IsValidCancelTime(tempCancelTime));
            festival.FestivalCancelTime = int.Parse(tempCancelTime);
        }
        
        public static void InputFestivalAdress(FestivalModel festival)
        {
            Address address = new Address();

            Console.WriteLine("Fill in the adress of the location.");
            do { address.Country = InputLoop("Fill in the country: "); }
            while (!RegexUtils.IsValidAddressName(address.Country));

            do { address.City = InputLoop("Fill in the city: "); }
            while (!RegexUtils.IsValidAddressName(address.City));

            do { address.ZipCode = InputLoop("Fill in the zipcode: "); }
            while (!RegexUtils.IsValidZipCode(address.ZipCode));

            do { address.StreetName = InputLoop("Fill in the street: "); }
            while (!RegexUtils.IsValidAddressName(address.StreetName));

            do { address.StreetNumber = InputLoop("Fill in the house number: "); }
            while (!RegexUtils.IsValidStreetNumber(address.StreetNumber));

            festival.FestivalLocation = address;
        }

        public static void ModifyFestivalAgeRestriction(FestivalModel festival)
        {
            string tempAge;
            do { tempAge = InputLoop("Fill in the Age restriction: "); }
            while (!RegexUtils.IsValidAge(tempAge));
            festival.FestivalAgeRestriction = int.Parse(tempAge);
        }

        public static void ModifyFestivalDescription(FestivalModel festival)
        {
            do { festival.FestivalDescription = InputLoop("Fill in the age restriction as a number(if there is no age restriction please fill in 0)"); }
            while (!RegexUtils.IsValidDescription(festival.FestivalDescription));    
        }
        
        public static void InputFestivalDate(FestivalModel festival)
        {
            string festivalDay;
            string festivalMonth;
            string festivalYear;

            Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
            do { festivalDay = InputLoop("Fill in the day: "); }
            while (!RegexUtils.IsValidDay(festivalDay));
            do { festivalMonth = InputLoop("Fill in the month: "); }
            while (!RegexUtils.IsValidMonth(festivalMonth));
            do { festivalYear = InputLoop("Fill in the year: "); }
            while (!RegexUtils.IsValidFestivalYear(festivalYear));
            festival.FestivalDate = new DateTime(int.Parse(festivalYear), int.Parse(festivalMonth), int.Parse(festivalDay));
        }

        public static void InputStartingTime(FestivalModel festival)
        {
            string tempStartingTime;
            do { tempStartingTime = InputLoop("Fill in starting time(hh:mm): "); }
            while (!RegexUtils.IsValidTimeFormat(tempStartingTime));

            festival.FestivalStartingTime = new DateTime(festival.FestivalDate.Year,
                                                         festival.FestivalDate.Month,
                                                         festival.FestivalDate.Day,
                                                         int.Parse(tempStartingTime.Substring(0, 2)),
                                                         int.Parse(tempStartingTime.Substring(3, 2)), 0);
        }

        public static void InputEndTime(FestivalModel festival)
        {
            string tempEndTime;
            do { tempEndTime = InputLoop("Fill in the expected end time(hh:mm): "); }
            while (!RegexUtils.IsValidTimeFormat(tempEndTime));
            festival.FestivalEndTime = new DateTime(festival.FestivalDate.Year,
                                                         festival.FestivalDate.Month,
                                                         festival.FestivalDate.Day,
                                                         int.Parse(tempEndTime.Substring(0, 2)),
                                                         int.Parse(tempEndTime.Substring(3, 2)), 0);
        }

        public static void InputGenre(FestivalModel festival)
        {
            Menu.OptionReset();
            while (true)
            {
                Console.WriteLine("Select the genre of you festival. If it is not in the list it is not a real festival! ");
                Menu.Draw(MenuBuilder.GenreMenu(festival));
            }
        }

        public static List<Ticket> InputFestivalTickets(List<Ticket> savedTicketList)
        {
            int variousTickets = TicketModifier.InputTicketAmount();
            for (int i = 0; i < variousTickets; i++)
            {
                Ticket ticket = new Ticket
                {
                    FestivalID = RegisterHandler.SetFestivalId(JSONFunctionality.GetFestivals()),
                    TicketID = RegisterHandler.SetTicketID(JSONFunctionality.GetTickets()) + i
                };

                TicketModifier.InputTicketName(ticket, i);
                TicketModifier.InputTicketDescription(ticket);
                TicketModifier.InputTickePrice(ticket);
                TicketModifier.InputMaxTickets(ticket);
                TicketModifier.InputTicketMaxPerPerson(ticket);

                savedTicketList.Add(ticket);
            };
            return savedTicketList;
        }

        public static string GetFestivalGenre(FestivalModel festival)
        {
            return festival.FestivalGenre;
        }

        public static void SetFestivalGenre(FestivalModel festival, string genre)
        {
            festival.FestivalGenre = genre;
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
