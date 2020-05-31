﻿using System;

namespace Festivity
{
    internal class FestivalRegister
    {
        public static bool activeScreen = true;
        public static string currentRegisterSelection = null;

        // Festival vairables

        public static string festivalName = null;
        public static string festivalDescription = null;
        public static int festivalDateDay = 00;
        public static int festivalDateMonth = 00;
        public static int festivalDateYear = 00;
        public static string festivalStartingTime = null;
        public static string festivalEndTime = null;
        public static string festivalLocationCountry = null;
        public static string festivalLocationCity = null;
        public static string festivalLocationStreet = null;
        public static string festivalLocationZipCode = null;
        public static string festivalLocationHouseNumber = null;
        public static string festivalGenre = null;
        public static int festivalAgeRestriction = 0;
        public static string festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
        public static string festivalAdress = "Country: " + festivalLocationCountry + "\nCity: " + festivalLocationCity + "\nStreet: " + festivalLocationStreet + "\nHousenumber: " + festivalLocationHouseNumber + "\nZipcode: " + festivalLocationZipCode;
        public static int cancelTime = 0;

        public static void ShowFestivalRegister()
        {
            // This is used to write and retrieve data to the correct database
            JSONFestivalList festivals = JSONFunctionality.get_festivals();
            JSONTicketList tickets = JSONFunctionality.get_tickets();

            // This is a function to retrieve the latest registered festivalid and create the next festivalid
            int FestivalID(JSONFestivalList festivals)
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
            int TicketID(JSONTicketList tickets)
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

            int festivalID = FestivalID(festivals);

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
                    MenuFunction.Menu(new string[] { "Festival Name", "Festival Date", "Starting Time", "End Time", "Festival Adress", "Festival Description", "Age restriction", "Festival Genre", "Cancel Time", "Tickets", "Save Festival" });
                }
                else if (currentRegisterSelection == "Festival Name")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the name of the festival: ");
                    festivalName = Console.ReadLine();
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Festival Date")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
                    Console.WriteLine("Fill in the day: ");
                    festivalDateDay = int.Parse(Console.ReadLine());

                    Console.WriteLine("Fill in the month: ");
                    festivalDateMonth = int.Parse(Console.ReadLine());

                    Console.WriteLine("Fill in the year: ");
                    festivalDateYear = int.Parse(Console.ReadLine());
                    festivalDate = festivalDateDay + ":" + festivalDateMonth + ":" + festivalDateYear;
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Starting Time")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in starting time(hh:mm): ");
                    festivalStartingTime = Console.ReadLine();
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "End Time")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the expected end time(hh:mm): ");
                    festivalEndTime = Console.ReadLine();
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Festival Adress")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the adress of the location.");
                    Console.WriteLine("Fill in the country: ");
                    festivalLocationCountry = Console.ReadLine();


                    Console.WriteLine("Fill in the city: ");
                    festivalLocationCity = Console.ReadLine();

                    Console.WriteLine("Fill in the zipcode");
                    festivalLocationZipCode = Console.ReadLine();
                    Console.WriteLine("Fill in the street: ");
                    festivalLocationStreet = Console.ReadLine();

                    Console.WriteLine("Fill in the house number: ");
                    festivalLocationHouseNumber = Console.ReadLine();
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Festival Description")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the festival description (press enter when finished but don't press enter for a new line): ");
                    festivalDescription = Console.ReadLine();
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Age Restriction")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the age restriction as a number");
                    festivalAgeRestriction = int.Parse(Console.ReadLine());
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Festival Genre")
                {
                    Console.Clear();
                    Console.WriteLine("Select the genre of you festival. If it is not in the list it is not a real festival! ");
                    MenuFunction.Menu(new string[] { "Techno", "Drum & Bass", "Pop", "Rock", "Hip-Hop" });
                }
                else if (currentRegisterSelection == "Cancel Time")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the amount of days before the start of the festival a customer is allowed to cancel their order: ");
                    cancelTime = int.Parse(Console.ReadLine());
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Tickets")
                {
                    Console.Clear();
                    Console.WriteLine("Fill in the amount of various tickets as a number: ");
                    int festivalAmountVariousTickets = int.Parse(Console.ReadLine());

                    // this for loop loops the amount of times the organiser filled in for various amounts of tickets
                    for (int i = 0; i < festivalAmountVariousTickets; i++)
                    {
                        // This variable connected to the ticketid function is placed inside the loop to give every ticket a new ticketid
                        int ticketID = TicketID(tickets);

                        Console.WriteLine("Fill in the ticket name of ticket ", (i + 1),
                        ": ");
                        string festivalTicketName = Console.ReadLine();

                        Console.WriteLine("Fill in ticket description");
                        string festivalTicketDescription = Console.ReadLine();

                        Console.WriteLine("Fill in the price of the ticket in euros: ");
                        double festivalTicketPrice = double.Parse(Console.ReadLine());

                        Console.WriteLine("Fill in the maximum available amount of this type ticket: ");
                        int festivalMaxTickets = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Fill in the maximum amount of tickets a single person may buy: ");
                        int festivalMaxTicketsPerPerson = Int32.Parse(Console.ReadLine());

                        // This is a format to create the new ticket
                        Ticket ticket = new Ticket
                        {
                            FestivalID = festivalID,
                            TicketID = ticketID,
                            TicketName = festivalTicketName,
                            TicketDescription = festivalTicketDescription,
                            TicketPrice = festivalTicketPrice,
                            MaxTickets = festivalMaxTickets,
                            MaxTicketsPerPerson = festivalMaxTicketsPerPerson
                        };

                        // Adds a new ticket to the database
                        tickets.Tickets.Add(ticket);

                        JSONFunctionality.write_tickets(tickets);
                    };
                    currentRegisterSelection = "Main";
                }
                else if (currentRegisterSelection == "Save Festival")
                {
                    Console.Clear();

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
                            Day = festivalDateDay,
                            Month = festivalDateMonth,
                            Year = festivalDateYear
                        },
                        FestivalStartingTime = festivalStartingTime,
                        FestivalEndTime = festivalEndTime,
                        FestivalGenre = festivalGenre,
                        FestivalAgeRestriction = festivalAgeRestriction,
                        FestivalCancelTime = cancelTime
                    };
                    // Adds a new festival to the database
                    festivals.festivals.Add(festival);
                    JSONFunctionality.write_festivals(festivals);

                    activeScreen = false;
                    currentRegisterSelection = null;
                    MenuFunction.option = 0;
                }
            }
        }
    }
}