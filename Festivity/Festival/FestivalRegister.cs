using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Festivity
{
    internal class FestivalRegister
    {
        public static bool activeScreen = true;
        public static string currentRegisterSelection = null;
        public static List<Ticket> ticketList { get; set; }

        // Festival vairables

        public static string festivalName = null;
        public static string festivalDescription = null;
        public static string festivalDateDay = null;
        public static string festivalDateMonth = null;
        public static string festivalDateYear = null;
        public static string festivalStartingTime = null;
        public static string festivalEndTime = null;
        public static string festivalLocationCountry = null;
        public static string festivalLocationCity = null;
        public static string festivalLocationStreet = null;
        public static string festivalLocationZipCode = null;
        public static string festivalLocationHouseNumber = null;
        public static string festivalGenre = null;
        public static string festivalAgeRestriction = null;
        public static string festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
        public static string festivalAdress = "\nCountry: " + festivalLocationCountry + "\nCity: " + festivalLocationCity + "\nStreet: " + festivalLocationStreet + "\nHousenumber: " + festivalLocationHouseNumber + "\nZipcode: " + festivalLocationZipCode;
        public static string cancelTime = null;

        // Ticket vairables

        public static int ticketID;
        public static string festivalTicketName;
        public static string festivalTicketDescription;
        public static string festivalTicketPrice;
        public static string festivalMaxTickets;
        public static string festivalMaxTicketsPerPerson;

        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();
        
        // This function is used to apply regex
        public static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        // This is a function to reset all variables upon leaving the festival registration
        public static void ResetFestivalAndTicketRegistration()
        {

        // Festival vairables

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

        // Ticket vairables

        festivalTicketName = null;
        festivalTicketDescription = null;
        festivalTicketPrice = null;
        festivalMaxTickets = null;
        festivalMaxTicketsPerPerson = null;

        // Removes all tickets from the ticketList if the ticketlist contains a ticket
        ticketList.Clear();
        }

        // This is a function to retrieve the latest registered festivalid and create the next festivalid
        public static int FestivalId(JSONFestivalList festivals)
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
        public static int TicketID(JSONTicketList tickets)
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
        
        public static void ShowFestivalRegister()
        {
        

            int festivalID = FestivalId(festivals);

            // Makes sure the console keeps refreshing, allowing input

            while (activeScreen == true)
            {
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
                    MenuFunction.Menu(new string[] { "Festival Name", "Festival Date", "Starting Time", "End Time", "Festival Adress", "Festival Description", "Age restriction", "Festival Genre", "Cancel Time", "Tickets", "Save Festival", "Cancel Festival Registration" });
                }
                else if (currentRegisterSelection == "Festival Name")
                {
                    Console.Clear();
                    do { festivalName = InputLoop("Fill in the name of the festival: "); }
                    while (!RegexUtils.IsValidName(festivalName));
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Festival Date")
                {
                    Console.Clear();
                    
                    Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
                    do { festivalDateDay = InputLoop("Fill in the day: "); }
                    while (!RegexUtils.IsValidFestivalDay(festivalDateDay));
                    do { festivalDateMonth = InputLoop("Fill in the month: "); }
                    while (!RegexUtils.IsValidFestivalMonth(festivalDateMonth));
                    do { festivalDateYear = InputLoop("Fill in the year: "); }
                    while (!RegexUtils.IsValidFestivalYear(festivalDateYear));
                    festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Starting Time")
                {
                    Console.Clear();
                    do { festivalStartingTime = InputLoop("Fill in starting time(hh:mm): "); }
                    while (!RegexUtils.IsValidTimeFormat(festivalStartingTime));
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "End Time")
                {
                    Console.Clear();
                    do { festivalEndTime = InputLoop("Fill in the expected end time(hh:mm): "); }
                    while (!RegexUtils.IsValidTimeFormat(festivalEndTime));
                    currentRegisterSelection = "Main";
                }
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
                else if (currentRegisterSelection == "Festival Description")
                {
                    Console.Clear();
                    do { festivalDescription = InputLoop("Fill in the festival description (press enter when finished but don't press enter for a new line): "); }
                    while (!RegexUtils.IsValidDescription(festivalLocationCountry));
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Age Restriction")
                {
                    Console.Clear();
                    do { festivalAgeRestriction = InputLoop("Fill in the age restriction as a number(if there is no age restriction please fill in 0)"); }
                    while (!RegexUtils.IsValidAge(festivalAgeRestriction));
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Festival Genre")
                {
                    Console.Clear();
                    MenuFunction.option = 0;
                    Console.WriteLine("Select the genre of you festival. If it is not in the list it is not a real festival! ");
                    MenuFunction.Menu(new string[] { "Techno", "Drum & Bass", "Pop", "Rock", "Hip-Hop" });
                }
                else if (currentRegisterSelection == "Cancel Time")
                {
                    Console.Clear();
                    do { cancelTime = InputLoop("Fill in the amount of days before the start of the festival a customer is allowed to cancel their order: "); }
                    while (!RegexUtils.IsValidCancelTime(cancelTime));
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Tickets")
                {
                    string festivalAmountVariousTickets;
                    Console.Clear();
                    do { festivalAmountVariousTickets = InputLoop("Fill in the amount of various tickets as a number: "); }
                    while (!RegexUtils.NumberCheck(festivalAmountVariousTickets, 1, 20));
                    
                    int variousTickets = int.Parse(festivalAmountVariousTickets);

                    ticketList = new List<Ticket>();
                    // this for loop loops the amount of times the organiser filled in for various amounts of tickets
                    for (int i = 0; i < variousTickets; i++)
                    {
                        // This variable connected to the ticketid function is placed inside the loop to give every ticket a new ticketid
                        ticketID = TicketID(tickets);

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
                    
                    if (ticketList == null)
                    {
                        Console.WriteLine("Before you can save the festival to our database you must create atleast one ticket!");
                        Thread.Sleep(5000);
                        currentRegisterSelection = "Main";
                    }
                    else if (festivalName == null || festivalDescription == null || festivalLocationCountry == null || festivalLocationCity == null ||
                        festivalLocationStreet == null || festivalLocationHouseNumber == null || festivalLocationZipCode == null || festivalDateDay == null|| festivalDateMonth == null || festivalDateYear == null ||
                        festivalStartingTime == null || festivalEndTime == null || festivalGenre == null || festivalAgeRestriction == null || cancelTime == null)
                    {
                        // Checks if every field is filled in so the application does not crash
                        Console.WriteLine("Before you can save the festival to our database you must assign a value to every option but you dont have to register the tickets again");
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

                        // A format for creating a new festival
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
                            FestivalDate = new Date
                            {
                                Day = int.Parse(festivalDateDay),
                                Month = int.Parse(festivalDateMonth),
                                Year = int.Parse(festivalDateYear)
                            },
                            FestivalStartingTime = festivalStartingTime,
                            FestivalEndTime = festivalEndTime,
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
                        MenuFunction.option = 0;
                    }
                }
                else if (currentRegisterSelection == "Cancel Festival Registration")
                {
                    // Reset all vairables
                    ResetFestivalAndTicketRegistration();
                    // Returns you to the main menu
                    activeScreen = false;
                    currentRegisterSelection = null;
                    MenuFunction.option = 0;
                }
            }
        }
    }
}