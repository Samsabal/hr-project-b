using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Festivity
{
    class FestivalRegister
    {
        public static void festival_register()
        {
            // This is used to write and retrieve data to the correct database
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalRegisterList festivals = JsonConvert.DeserializeObject<JSONFestivalRegisterList>(File.ReadAllText(PATH_FESTIVAL));
            string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
            JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

            // This is a function to retrieve the latest registered festivalid and create the next festivalid
            int festivalId(JSONFestivalRegisterList festivals)
            {
                int festivalId;
                if (festivals.festivals.Count == 0)
                {
                    festivalId = 1;
                }
                else
                {
                    int item = festivals.festivals[^1].festivalId;
                    festivalId = item + 1;
                };

                return festivalId;
            }

            // This is a function to retrieve the latest registered ticketid and create the next ticketid
            int ticketId(JSONTicketList tickets)
            {
                int ticketId;
                if (tickets.Tickets.Count == 0)
                {
                    ticketId = 1;
                }
                else
                {
                    int item = tickets.Tickets[^1].ticketId;
                    ticketId = item + 1;
                };

                return ticketId;
            }

            int festivalID = festivalId(festivals);
           


            Console.WriteLine("You will now start the festival registering fase");
            Console.WriteLine("Fill in the name of the festival: ");
            string festivalName = Console.ReadLine();

            Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
            string festivalDate = Console.ReadLine();

            Console.WriteLine("Fill in starting time(hh:mm): ");
            string festivalStartingTime = Console.ReadLine();

            Console.WriteLine("Fill in the expected end time(hh:mm): ");
            string festivalEndTime = Console.ReadLine();

            Console.WriteLine("Fill in the adress of the location.");
            Console.WriteLine("Fill in the country: ");
            string festivalLocationCountry = Console.ReadLine();

            Console.WriteLine("Fill in the city: ");
            string festivalLocationCity = Console.ReadLine();

            Console.WriteLine("Fill in the street: ");
            string festivalLocationStreet = Console.ReadLine();

            Console.WriteLine("Fill in the house number: ");
            string festivalLocationHouseNumber = Console.ReadLine()
                ;
            Console.WriteLine("Fill in the festival description (press enter when finished but don't press enter for a new line): ");
            string festivalDescription = Console.ReadLine();

            Console.WriteLine("Fill in the age restriction as a number");
            string festivalAgeRestriction = Console.ReadLine();

            Console.WriteLine("Fill in the genre of the festival: ");
            string festivalGenre = Console.ReadLine();

            Console.WriteLine("Fill in the amount of various tickets as anumber: ");
            int festivalAmountVariousTickets = Int32.Parse(Console.ReadLine());

            // A format for creating a new festival

            FestivalRegisterClass festival = new FestivalRegisterClass
            {
                festivalId = festivalID,
                festivalName = festivalName,
                festivalDescription = festivalDescription,
                festivalLocationCountry = festivalLocationCountry,
                festivalLocationCity = festivalLocationCity,
                festivalLocationStreet = festivalLocationStreet,
                festivalLocationHouseNumber = festivalLocationHouseNumber,
                festivalDate = festivalDate,
                festivalStartingTime = festivalStartingTime,
                festivalEndTime = festivalEndTime,
                festivalGenre = festivalGenre,
                festivalAgeRestriction = festivalAgeRestriction
            };

            // Adds a new festival to the database
            festivals.festivals.Add(festival);

            string jsonfestival = JsonConvert.SerializeObject(festivals, Formatting.Indented);

            File.WriteAllText(PATH_FESTIVAL, jsonfestival);

            // this a for loop to loop the amount of times the organiser filled in for various amounts of tickets
            for (int i = 0; i < festivalAmountVariousTickets; i++)
            {
                // This variable connected to the ticketid function is placed inside the loop to give every ticket a new ticketid
                int ticketID = ticketId(tickets);


                Console.WriteLine("Fill in the ticket name of ticket ", (i + 1),
                ": ");
                string festivalTicketName = Console.ReadLine();

                Console.WriteLine("Fill in ticket description");
                string festivalTicketDescription = Console.ReadLine();
                
                Console.WriteLine("Fill in the price of the ticket in euros: ");
                string festivalTicketPrice = Console.ReadLine();

                Console.WriteLine("Fill in the maximum available amount of this type ticket");
                int festivalMaxTickets = Int32.Parse(Console.ReadLine());
                
                // This is a format to create the new ticket
                Ticket ticket = new Ticket
                {
                    festivalId = festivalID,
                    ticketId = ticketID,
                    ticketName = festivalTicketName,
                    ticketDescription = festivalTicketDescription,
                    ticketPrice = festivalTicketPrice,
                    maxTickets = festivalMaxTickets
                };

                // Adds a new ticket to the database
                tickets.Tickets.Add(ticket);

                string jsonticket = JsonConvert.SerializeObject(tickets, Formatting.Indented);

                File.WriteAllText(PATH_TICKET, jsonticket);
            };
        }
    }
}
