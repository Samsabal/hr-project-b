using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading;

namespace Festivity
{
    /// <summary>
    /// This class is used to register a festival.
    /// </summary>
    internal class FestivalRegister
    {
        // Variables that manage the functionality of the registration.
        public static bool ActiveScreen { private get; set; }
        public static string CurrentRegisterSelection  { private get; set; }
        private static List<Ticket> ticketList;
        private static string festivalGenre;

        // Database arrays.
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();

        /// <summary>
        /// This is a function to show the festivalregistration and let the user allow inputs.
        /// </summary>
        public static void ShowFestivalRegister()
        {
            // Festival vairables.
            string festivalName = null;
            string festivalDescription = null;
            string festivalDateDay = null;
            string festivalDateMonth = null;
            string festivalDateYear = null;
            string festivalStartingTime = null;
            string festivalEndTime = null;
            string festivalLocationCountry = null;
            string festivalLocationCity = null;
            string festivalLocationStreet = null;
            string festivalLocationZipCode = null;
            string festivalLocationHouseNumber = null;
            string festivalAgeRestriction = null;
            string festivalDate = null;
            string festivalAdress = null;
            string cancelTime = null;
            SetFestivalGenre(null);

            // Ticket vairables.
            int ticketID;
            string festivalTicketName;
            string festivalTicketDescription;
            string festivalTicketPrice;
            string festivalMaxTickets;
            string festivalMaxTicketsPerPerson;
            int festivalID = SetFestivalId(festivals);

            ticketList = new List<Ticket>();

            // Makes sure the console keeps refreshing, allowing input.
            while (ActiveScreen == true)
            {
                // This is a summary of all the assigned variables with their values for the current festival.
                switch (CurrentRegisterSelection)
                {
                    case "Main":
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Console.Write("Festival Name: " + festivalName + "\n" +
                        "Festival Date: " + festivalDate + "\n" +
                        "Festival Starting Time: " + festivalStartingTime + "\n" +
                        "Festival End Time: " + festivalEndTime + "\n" +
                        "Festival Adress: " + festivalAdress + "\n" +
                        "Festival Description: " + festivalDescription + "\n" +
                        "Festival Age Restriction: " + festivalAgeRestriction + "\n" +
                        "Festival Genre: " + GetFestivalGenre() + "\n" +
                        "Cancel Time: " + cancelTime + "\n" +
                        "===============================================\n");
                        Menu.Draw(MenuBuilder.FestivalRegisterMenu());
                        break;
                    case "Festival Name":
                        Console.Clear();
                        do { festivalName = InputLoop("Fill in the name of the festival: "); }
                        while (!RegexUtils.IsValidName(festivalName));
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Festival Date":
                        Console.Clear();
                        Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
                        do { festivalDateDay = InputLoop("Fill in the day: "); }
                        while (!RegexUtils.IsValidDay(festivalDateDay));
                        do { festivalDateMonth = InputLoop("Fill in the month: "); }
                        while (!RegexUtils.IsValidMonth(festivalDateMonth));
                        do { festivalDateYear = InputLoop("Fill in the year: "); }
                        while (!RegexUtils.IsValidFestivalYear(festivalDateYear));
                        festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Starting Time":
                        Console.Clear();
                        do { festivalStartingTime = InputLoop("Fill in starting time(hh:mm): "); }
                        while (!RegexUtils.IsValidTimeFormat(festivalStartingTime));
                        CurrentRegisterSelection = "Main";
                        break;
                    case "End Time":
                        Console.Clear();
                        do { festivalEndTime = InputLoop("Fill in the expected end time(hh:mm): "); }
                        while (!RegexUtils.IsValidTimeFormat(festivalEndTime));
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Festival Adress":
                        Console.Clear();
                        Console.WriteLine("Fill in the adress of the location.");
                        do { festivalLocationCountry = InputLoop("Fill in the country: "); }
                        while (!RegexUtils.IsValidAddressName(festivalLocationCountry));
                        do { festivalLocationCity = InputLoop("Fill in the city: "); }
                        while (!RegexUtils.IsValidAddressName(festivalLocationCity));
                        do { festivalLocationZipCode = InputLoop("Fill in the zipcode: "); }
                        while (!RegexUtils.IsValidZipCode(festivalLocationZipCode));
                        do { festivalLocationStreet = InputLoop("Fill in the street: "); }
                        while (!RegexUtils.IsValidAddressName(festivalLocationStreet));
                        do { festivalLocationHouseNumber = InputLoop("Fill in the house number: "); }
                        while (!RegexUtils.IsValidStreetNumber(festivalLocationHouseNumber));

                        festivalAdress = "\nCountry: " + festivalLocationCountry + "\nCity: " + festivalLocationCity + "\nStreet: " + festivalLocationStreet + "\nHousenumber: " + festivalLocationHouseNumber + "\nZipcode: " + festivalLocationZipCode;
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Festival Description":
                        Console.Clear();
                        do { festivalDescription = InputLoop("Fill in the festival description (press enter when finished but don't press enter for a new line): "); }
                        while (!RegexUtils.IsValidDescription(festivalLocationCountry));
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Age Restriction":
                        Console.Clear();
                        do { festivalAgeRestriction = InputLoop("Fill in the age restriction as a number(if there is no age restriction please fill in 0): "); }
                        while (!RegexUtils.IsValidAge(festivalAgeRestriction));
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Festival Genre":
                        Console.Clear();
                        Menu.OptionReset();
                        while (true)
                        {
                            Console.WriteLine("Select the genre of you festival. If it is not in the list it is not a real festival! ");
                            Menu.Draw(MenuBuilder.GenreMenu());
                        }
                    case "Cancel Time":
                        Console.Clear();
                        do { cancelTime = InputLoop("Fill in the amount of days before the start of the festival a customer is allowed to cancel their order: "); }
                        while (!RegexUtils.IsValidCancelTime(cancelTime));
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Tickets":
                        string festivalAmountVariousTickets;
                        Console.Clear();
                        do { festivalAmountVariousTickets = InputLoop("Fill in the amount of various tickets as a number: "); }
                        while (!RegexUtils.NumberCheck(festivalAmountVariousTickets, 1, 20));

                        int variousTickets = int.Parse(festivalAmountVariousTickets);
                        // this for loop loops the amount of times the organiser filled in for various amounts of tickets.
                        for (int i = 0; i < variousTickets; i++)
                        {
                            // This variable connected to the ticketid function is placed inside the loop to give every ticket a new ticketid.
                            ticketID = SetTicketID(tickets);

                            do { festivalTicketName = InputLoop($"Fill in the ticket name of ticket {(i + 1)} : "); }
                            while (!RegexUtils.IsValidAddressName(festivalTicketName));

                            do { festivalTicketDescription = InputLoop("Fill in the ticket description: "); }
                            while (!RegexUtils.IsValidDescription(festivalTicketDescription));

                            do { festivalTicketPrice = InputLoop("Fill in the price of the ticket in euros: "); }
                            while (!RegexUtils.IsValidPrice(festivalTicketPrice));

                            do { festivalMaxTickets = InputLoop("Fill in the maximum amount of available tikets of this ticket type: "); }
                            while (!RegexUtils.IsValidMaxTickets(festivalMaxTickets));

                            do { festivalMaxTicketsPerPerson = InputLoop("Fill in the maximum amount of tickets a single person may buy: "); }
                            while (!RegexUtils.IsValidMaxTicketsPerPerson(festivalMaxTicketsPerPerson));

                            // This is a format to create the new ticket
                            Ticket ticket = new Ticket
                            {
                                FestivalID = festivalID,
                                TicketID = ticketID,
                                TicketName = festivalTicketName,
                                TicketDescription = festivalTicketDescription,
                                TicketPrice = double.Parse(festivalTicketPrice),
                                MaxTickets = int.Parse(festivalMaxTickets),
                                MaxTicketsPerPerson = int.Parse(festivalMaxTicketsPerPerson)
                            };

                            ticketList.Add(ticket);
                        };
                        CurrentRegisterSelection = "Main";
                        break;
                    case "Save Festival":
                        {
                            Console.Clear();

                            // Checks if there are tickets registered.
                            // If not it will not save the festival.

                            if (!ticketList.Any())
                            {
                                TicketsRegisteredErrorMessage();
                            }

                            // Checks if there is any value unassigned to prevent other parts from crashing upon retrieving the data from the databases.
                            else if (festivalName == null || festivalDescription == null || festivalLocationCountry == null || festivalLocationCity == null ||
                                festivalLocationStreet == null || festivalLocationHouseNumber == null || festivalLocationZipCode == null || festivalDateDay == null || festivalDateMonth == null || festivalDateYear == null ||
                                festivalStartingTime == null || festivalEndTime == null || festivalGenre == null || festivalAgeRestriction == null || cancelTime == null)
                            {
                                Console.WriteLine("Before you can save the festival to our database you must assign a value to every option but you do not have to register the tickets again");
                                Thread.Sleep(5000);
                                CurrentRegisterSelection = "Main";
                            }
                            else
                            {
                                foreach (var Ticket in ticketList)
                                {
                                    // Adds a new ticket to the database
                                    tickets.Tickets.Add((Ticket)Ticket);
                                }
                                JSONFunctionality.WriteTickets(tickets);

                                // this is used to format the date to write to the database.

                                DateTime FestivalDate = new DateTime(int.Parse(festivalDateYear), int.Parse(festivalDateMonth), int.Parse(festivalDateDay));
                                DateTime FestivalStartingTime = new DateTime(FestivalDate.Year, FestivalDate.Month, FestivalDate.Day, int.Parse(festivalStartingTime.Substring(0, 2)),
                                    int.Parse(festivalStartingTime.Substring(3, 2)), 0);
                                DateTime FestivalEndTime = new DateTime(FestivalDate.Year, FestivalDate.Month, FestivalDate.Day, int.Parse(festivalEndTime.Substring(0, 2)),
                                    int.Parse(festivalEndTime.Substring(3, 2)), 0);
                                if (FestivalEndTime < FestivalStartingTime)
                                {
                                    FestivalEndTime.AddDays(1);
                                }

                                // This is a format for creating a new festival.

                                FestivalModel festival = new FestivalModel
                                {
                                    FestivalID = festivalID,
                                    FestivalName = festivalName,
                                    FestivalDescription = festivalDescription,
                                    FestivalLocation = new Address
                                    {
                                        Country = festivalLocationCountry,
                                        City = festivalLocationCity,
                                        ZipCode = festivalLocationZipCode,
                                        StreetName = festivalLocationStreet,
                                        StreetNumber = festivalLocationHouseNumber
                                    },
                                    FestivalDate = FestivalDate,
                                    FestivalStartingTime = FestivalStartingTime,
                                    FestivalEndTime = FestivalEndTime,
                                    FestivalGenre = festivalGenre,
                                    FestivalAgeRestriction = int.Parse(festivalAgeRestriction),
                                    FestivalCancelTime = int.Parse(cancelTime),
                                    FestivalOrganiserID = LoggedInAccount.GetID()
                                };
                                // Adds a new festival to the database
                                festivals.Festivals.Add(festival);
                                JSONFunctionality.WriteFestivals(festivals);
                                ActiveScreen = false;
                                CurrentRegisterSelection = null;
                                Menu.OptionReset();
                            }
                            break;
                        }
                    case "Cancel Festival Registration":
                        // Reset all vairables
                        // Returns you to the main menu
                        ActiveScreen = false;
                        CurrentRegisterSelection = null;
                        Menu.OptionReset();
                        break;
                }
            }
        }

        public static string GetFestivalGenre()
        {
            return festivalGenre;
        }

        public static void SetFestivalGenre(string genre)
        {
            festivalGenre = genre;
        }

        /// <summary>
        /// This function is used to apply regex.
        /// </summary>
        /// <param name="printString"></param>
        /// <returns>userInput</returns>
        private static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        /// <summary>
        /// This function gives an error message that there hasn't been a ticket registered yet.
        /// </summary>
        private static void TicketsRegisteredErrorMessage()
        {
            Console.WriteLine("Before you can save the festival to our database you must create atleast one ticket!");
            Thread.Sleep(5000);
            CurrentRegisterSelection = "Main";
        }

        /// <summary>
        /// This is a function to reset all variables upon leaving the festival registration.
        /// </summary>

        /// <summary>
        /// This is a function to retrieve the latest registered festivalid and create the next festivalid.
        /// </summary>
        /// <param name="festivals"></param>
        /// <returns>festivalID</returns>
        private static int SetFestivalId(JSONFestivalList festivals)
        {
            int festivalId;
            if (festivals.Festivals.Count == 0)
            {
                festivalId = 1;
            }
            else
            {
                int item = festivals.Festivals[^1].FestivalID;
                festivalId = item + 1;
            };

            return festivalId;
        }

        /// <summary>
        /// This is a function to retrieve the latest registered ticketid and create the next ticketid.
        /// </summary>
        /// <param name="tickets"></param>
        /// <returns></returns>
        private static int SetTicketID(JSONTicketList tickets)
        {
            int ticketId;
            if (tickets.Tickets.Count == 0)
            {
                ticketId = 1;
            }
            else
            {
                int item = tickets.Tickets[^1].TicketID;
                ticketId = item + 1;
            };

            return ticketId;
        }
    }
}