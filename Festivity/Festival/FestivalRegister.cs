using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;

namespace Festivity
{
    internal class FestivalRegister
    {
        // Variables that manage the functionality of the registration.
        public static bool activeScreen { private get; set; }
        public static string currentRegisterSelection  { private get; set; }
        private static List<Ticket> ticketList;

        // Festival vairables.
        private static string festivalName = null;
        private static string festivalDescription = null;
        private static string festivalDateDay = null;
        private static string festivalDateMonth = null;
        private static string festivalDateYear = null;
        private static string festivalStartingTime = null;
        private static string festivalEndTime = null;
        private static string festivalLocationCountry = null;
        private static string festivalLocationCity = null;
        private static string festivalLocationStreet = null;
        private static string festivalLocationZipCode = null;
        private static string festivalLocationHouseNumber = null;
        public static string festivalGenre { private get; set; }
        private static string festivalAgeRestriction = null;
        private static string festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
        private static string festivalAdress = "\nCountry: " + festivalLocationCountry + "\nCity: " + festivalLocationCity + "\nStreet: " + festivalLocationStreet + "\nHousenumber: " + festivalLocationHouseNumber + "\nZipcode: " + festivalLocationZipCode;
        private static string cancelTime = null;

        // Ticket vairables.
        private static int ticketID;
        private static string festivalTicketName;
        private static string festivalTicketDescription;
        private static string festivalTicketPrice;
        private static string festivalMaxTickets;
        private static string festivalMaxTicketsPerPerson;

        // Database arrays.
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();

        // This function that is used to apply regex.
        private static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        // This function gives an error message that there hasn't been a ticket registered yet.
        private static void TicketsRegisteredErrorMessage()
        {
            Console.WriteLine("Before you can save the festival to our database you must create atleast one ticket!");
            Thread.Sleep(5000);
            currentRegisterSelection = "Main";
        }

        // This is a function to reset all variables upon leaving the festival registration
        private static void ResetFestivalAndTicketRegistration()
        {

            // Removes all tickets from the ticketList if the ticketlist contains a ticket
            ticketList.Clear();

            // Festival vairables.
            festivalName = null;
            festivalDescription = null;
            festivalDateDay = null;
            festivalDateMonth = null;
            festivalDateYear = null;
            festivalStartingTime = null;
            festivalEndTime = null;
            festivalLocationCountry = null;
            festivalLocationCity = null;
            festivalLocationStreet = null;
            festivalLocationZipCode = null;
            festivalLocationHouseNumber = null;
            festivalGenre = null;
            festivalAgeRestriction = null;
            festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
            festivalAdress = "\nCountry: " + festivalLocationCountry + "\nCity: " + festivalLocationCity + "\nStreet: " + festivalLocationStreet + "\nHousenumber: " + festivalLocationHouseNumber + "\nZipcode: " + festivalLocationZipCode;
            cancelTime = null;

            // Ticket vairables.
            festivalTicketName = null;
            festivalTicketDescription = null;
            festivalTicketPrice = null;
            festivalMaxTickets = null;
            festivalMaxTicketsPerPerson = null;
        }

        // This is a function to retrieve the latest registered festivalid and create the next festivalid
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

        // This is a function to retrieve the latest registered ticketid and create the next ticketid
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
        
        // This is a function to show the festivalregistration and let the user allow inputs.
        public static void ShowFestivalRegister()
        {
            int festivalID = SetFestivalId(festivals);

            // Makes sure the console keeps refreshing, allowing input.
            while (activeScreen == true)
            {
                // This is a summary of all the assigned variables with their values for the current festival.
                if (currentRegisterSelection == "Main")
                {
                    Console.Clear();
                    Console.Write("Festival Name: " + festivalName + "\n" +
                    "Festival Date: " + festivalDate + "\n" +
                    "Festival Starting Time: " + festivalStartingTime + "\n" +
                    "Festival End Time: " + festivalEndTime + "\n" +
                    "Festival Adress: " + festivalAdress + "\n" +
                    "Festival Description: " + festivalDescription + "\n" +
                    "Festival Age Restriction: " + festivalAgeRestriction + "\n" +
                    "Festival Genre: " + festivalGenre + "\n" +
                    "Cancel Time: " + cancelTime + "\n" +
                    "===============================================\n");
                    Menu.Draw(MenuBuilder.FestivalRegisterMenu());
                }

                // Sets the name of this festival.
                else if (currentRegisterSelection == "Festival Name")
                {
                    Console.Clear();
                    do { festivalName = InputLoop("Fill in the name of the festival: "); }
                    while (!RegexUtils.IsValidName(festivalName));
                    currentRegisterSelection = "Main";
                }

                // Sets the festival date for this festival.
                else if (currentRegisterSelection == "Festival Date")
                {
                    Console.Clear();

                    Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
                    do { festivalDateDay = InputLoop("Fill in the day: "); }
                    while (!RegexUtils.IsValidDay(festivalDateDay));
                    do { festivalDateMonth = InputLoop("Fill in the month: "); }
                    while (!RegexUtils.IsValidMonth(festivalDateMonth));
                    do { festivalDateYear = InputLoop("Fill in the year: "); }
                    while (!RegexUtils.IsValidFestivalYear(festivalDateYear));
                    festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
                    currentRegisterSelection = "Main";
                }

                // Sets the starting time of this festival.
                else if (currentRegisterSelection == "Starting Time")
                {
                    Console.Clear();
                    do { festivalStartingTime = InputLoop("Fill in starting time(hh:mm): "); }
                    while (!RegexUtils.IsValidTimeFormat(festivalStartingTime));
                    currentRegisterSelection = "Main";
                }

                // Sets the estimated ending time of this festival.
                else if (currentRegisterSelection == "End Time")
                {
                    Console.Clear();
                    do { festivalEndTime = InputLoop("Fill in the expected end time(hh:mm): "); }
                    while (!RegexUtils.IsValidTimeFormat(festivalEndTime));
                    currentRegisterSelection = "Main";
                }

                // Sets the festival adress.
                else if (currentRegisterSelection == "Festival Adress")
                {
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
                    currentRegisterSelection = "Main";
                }

                // Sets a description for this festival.
                else if (currentRegisterSelection == "Festival Description")
                {
                    Console.Clear();
                    do { festivalDescription = InputLoop("Fill in the festival description (press enter when finished but don't press enter for a new line): "); }
                    while (!RegexUtils.IsValidDescription(festivalLocationCountry));
                    currentRegisterSelection = "Main";
                }

                // Sets an age restriction for this festival.
                else if (currentRegisterSelection == "Age Restriction")
                {
                    Console.Clear();
                    do { festivalAgeRestriction = InputLoop("Fill in the age restriction as a number(if there is no age restriction please fill in 0): "); }
                    while (!RegexUtils.IsValidAge(festivalAgeRestriction));
                    currentRegisterSelection = "Main";
                }

                // Sets the genre to one of the options.
                else if (currentRegisterSelection == "Festival Genre")
                {
                    Console.Clear();
                    Menu.option = 0;
                    Console.WriteLine("Select the genre of you festival. If it is not in the list it is not a real festival! ");
                    Menu.Draw(MenuBuilder.GenreMenu());
                }
                // Sets an amount of weeks until the customer cant refund their tickets.
                else if (currentRegisterSelection == "Cancel Time")
                {
                    Console.Clear();
                    do { cancelTime = InputLoop("Fill in the amount of days before the start of the festival a customer is allowed to cancel their order: "); }
                    while (!RegexUtils.IsValidCancelTime(cancelTime));
                    currentRegisterSelection = "Main";
                }

                // This starts the ticket registration.
                else if (currentRegisterSelection == "Tickets")
                {
                    string festivalAmountVariousTickets;
                    Console.Clear();
                    do { festivalAmountVariousTickets = InputLoop("Fill in the amount of various tickets as a number: "); }
                    while (!RegexUtils.NumberCheck(festivalAmountVariousTickets, 1, 20));

                    int variousTickets = int.Parse(festivalAmountVariousTickets);

                    ticketList = new List<Ticket>();
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
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Save Festival")
                {
                    Console.Clear();

                    // Checks if there are tickets registered.
                    // If not it will not save the festival.
                    
                    // This if checks for a modification to ticketList, if this list isn't modified it won't allow the registration of the festival.
                    if (ticketList == null)
                    {
                        TicketsRegisteredErrorMessage();
                    }
                    // This else if is necessary once the ticket list has been modified once due to C# limitations.
                    else if (ticketList.Count == 0)
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
                        currentRegisterSelection = "Main";
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

                        Festival festival = new Festival
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

                        ResetFestivalAndTicketRegistration();
                        activeScreen = false;
                        currentRegisterSelection = null;
                        Menu.option = 0;
                    }
                }
                else if (currentRegisterSelection == "Cancel Festival Registration")
                {
                    // Reset all vairables
                    ResetFestivalAndTicketRegistration();
                    // Returns you to the main menu
                    activeScreen = false;
                    currentRegisterSelection = null;
                    Menu.option = 0;
                }
            }
        }
    }
}