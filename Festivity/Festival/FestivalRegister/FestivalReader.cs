using System;
using System.Collections.Generic;
using Festivity.Utils;

namespace Festivity.FestivalRegister
{
    internal class FestivalReader
    {
        private static UIElements UI = new UIElements("Register");
        public static void InputFestivalName(FestivalModel festival)
        {
            do { festival.FestivalName = General.InputLoop(" Festival Name: "); }
            while (!RegexUtils.IsValidName(festival.FestivalName));
        }

        public static void InputCancelTime(FestivalModel festival)
        {
            string tempCancelTime;
            do { tempCancelTime = General.InputLoop(" Maximum cancel time in weeks: "); }
            while (!RegexUtils.IsValidCancelTime(tempCancelTime));
            festival.FestivalCancelTime = int.Parse(tempCancelTime);
        }

        public static void InputFestivalAdress(FestivalModel festival)
        {
            AddressModel address = new AddressModel();

            do { address.Country = General.InputLoop(" Country: "); }
            while (!RegexUtils.IsValidAddressName(address.Country));

            do { address.City = General.InputLoop(" City: "); }
            while (!RegexUtils.IsValidAddressName(address.City));

            do { address.ZipCode = General.InputLoop(" ZipCode: "); }
            while (!RegexUtils.IsValidZipCode(address.ZipCode));

            do { address.StreetName = General.InputLoop(" Street: "); }
            while (!RegexUtils.IsValidAddressName(address.StreetName));

            do { address.StreetNumber = General.InputLoop(" House number: "); }
            while (!RegexUtils.IsValidStreetNumber(address.StreetNumber));

            festival.FestivalLocation = address;
        }

        public static void ModifyFestivalAgeRestriction(FestivalModel festival)
        {
            string tempAge;
            do { tempAge = General.InputLoop(" Festival age restriction as a number(if there is no age restriction please fill in 0): "); }
            while (!RegexUtils.IsValidAge(tempAge));
            festival.FestivalAgeRestriction = int.Parse(tempAge);
        }

        public static void ModifyFestivalDescription(FestivalModel festival)
        {
            do { festival.FestivalDescription = General.InputLoop(" Festival description: "); }
            while (!RegexUtils.IsValidDescription(festival.FestivalDescription));
        }

        public static void InputFestivalDate(FestivalModel festival)
        {
            string festivalDay;
            string festivalMonth;
            string festivalYear;

            do { festivalDay = General.InputLoop(" Day: "); }
            while (!RegexUtils.IsValidDay(festivalDay));
            do { festivalMonth = General.InputLoop(" Month: "); }
            while (!RegexUtils.IsValidMonth(festivalMonth));
            do { festivalYear = General.InputLoop(" Year: "); }
            while (!RegexUtils.IsValidFestivalYear(festivalYear));
            try
            {
                festival.FestivalDate = new DateTime(int.Parse(festivalYear), int.Parse(festivalMonth), int.Parse(festivalDay));
            }
            catch (ArgumentOutOfRangeException e)
            {
                ErrorMessage.InvalidDateError();
                InputFestivalDate(festival);
            }

        }

        public static void InputStartingTime(FestivalModel festival)
        {
            string tempStartingTime;
            do { tempStartingTime = General.InputLoop(" Starting Time(hh:mm): "); }
            while (!RegexUtils.IsValidTimeFormat(tempStartingTime));

            festival.FestivalStartingTime = new DateTime(festival.FestivalDate.Year,
                  /*Woosh I am a helicopter!*/           festival.FestivalDate.Month,
                                                         festival.FestivalDate.Day,
                                                         int.Parse(tempStartingTime.Substring(0, 2)),
                                                         int.Parse(tempStartingTime.Substring(3, 2)), 0);
        }

        public static void InputEndTime(FestivalModel festival)
        {
            string tempEndTime;
            do { tempEndTime = General.InputLoop(" Ending Time(hh:mm): "); }
            while (!RegexUtils.IsValidTimeFormat(tempEndTime));
            festival.FestivalEndTime = new DateTime(festival.FestivalDate.Year,
                  /*Woosh I am a helicopter too!*/       festival.FestivalDate.Month,
                                                         festival.FestivalDate.Day,
                                                         int.Parse(tempEndTime.Substring(0, 2)),
                                                         int.Parse(tempEndTime.Substring(3, 2)), 0);
            if (festival.FestivalEndTime < festival.FestivalStartingTime)
            {
                festival.FestivalEndTime = festival.FestivalEndTime.AddDays(1);
            }
        }

        public static void InputGenre(FestivalModel festival)
        {
            Menu.OptionReset();
            while (true)
            {
                UI.Pom("Select your Festival genre");
                Menu.Draw(new FestivalGenreMenu().GenreMenuBuilder(festival));
            }
        }

        public static List<TicketModel> InputFestivalTickets(List<TicketModel> savedTicketList)
        {
            int alreadySavedTicketsCount = savedTicketList.Count;
            int variousTickets = TicketReader.InputTicketAmount();
            for (int i = savedTicketList.Count; i < alreadySavedTicketsCount + variousTickets; i++)
            {
                TicketModel ticket = new TicketModel
                {
                    FestivalID = Handler.SetFestivalId(JSONFunctions.GetFestivals()),
                    TicketID = Handler.SetTicketID(JSONFunctions.GetTickets()) + i
                };
                UI.PathLine();
                UI.InfoLine("Command -q or -quit to go back.");
                UI.Pom($"Ticket {i+1}");
                TicketReader.InputTicketName(ticket, i);
                TicketReader.InputTicketDescription(ticket);
                TicketReader.InputTickePrice(ticket);
                TicketReader.InputMaxTickets(ticket);
                TicketReader.InputTicketMaxPerPerson(ticket);

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

        //private static string InputLoop(string printString)
        //{
        //    string userInput;
        //    Console.Write(printString); userInput = Console.ReadLine();
        //    Console.Clear();
        //    return userInput;
        //}

        public static void ModifyUpdateDateByTime(FestivalModel festival)
        {
            if (festival.FestivalStartingTime.Date != festival.FestivalDate.Date)
            {
                festival.FestivalStartingTime = new DateTime(festival.FestivalDate.Year, festival.FestivalDate.Month, festival.FestivalDate.Day, festival.FestivalStartingTime.Hour, festival.FestivalStartingTime.Minute, festival.FestivalStartingTime.Second);
                festival.FestivalEndTime = new DateTime(festival.FestivalDate.Year, festival.FestivalDate.Month, festival.FestivalDate.Day, festival.FestivalEndTime.Hour, festival.FestivalEndTime.Minute, festival.FestivalEndTime.Second);
                if (festival.FestivalEndTime < festival.FestivalStartingTime)
                {
                    festival.FestivalEndTime = festival.FestivalEndTime.AddDays(1);
                }
            }
        }
    }
}