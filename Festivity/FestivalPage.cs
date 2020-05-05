using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Threading;

namespace Festivity
{
    public class FestivalPage
    {
        public static void ClearCurrentConsoleLine() //Removes the last line in the ticket table for a cleaner look
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void festival_page(int festivalId)
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
            JSONTicketList Tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

            foreach (var user in users.users)
            {
                foreach (var festival in Festivals.festivals)
                {
                        if (festival.festivalId == festivalId)
                        {
                            if (false) //Needs to contain an age check -> (users.birthDate - festival.festivalDate < 18)
                            {
                                Console.WriteLine("Sorry but you are too young to enter this festival.");
                            }
                            else
                            {
                                MenuFunction.option = 0;
                                while (true) //Displays all the info in the console.
                                {
                                    string line = "----------------------------------------------------------------------";
                                    string thickLine = "======================================================================";

                                    Console.WriteLine(thickLine);
                                    Console.WriteLine(festival.festivalName);
                                    Console.WriteLine("Organised by: " + "(Komt festival organisator)"); 
                                    Console.WriteLine(line);
                                    Console.WriteLine("You need to be at least " + festival.festivalAgeRestriction + " years old in order to enter.");
                                    Console.WriteLine(festival.festivalDescription);
                                    Console.WriteLine(line);
                                    Console.WriteLine("Starts at " + festival.festivalStartingTime + " and ends on " + festival.festivalEndTime + ".");
                                    Console.WriteLine("Takes place on: " + festival.festivalDate.day + "-" + festival.festivalDate.month + "-" + festival.festivalDate.year);
                                    Console.WriteLine();
                                    Console.WriteLine(festival.festivalLocation.streetName + " " + festival.festivalLocation.streetNumber + ", " + festival.festivalLocation.zipCode);
                                    Console.WriteLine(festival.festivalLocation.city + ", " + festival.festivalLocation.country);
                                    Console.WriteLine(thickLine);
                                    foreach (var ticket in Tickets.tickets)
                                    {
                                        if (ticket.festivalId == festival.festivalId)
                                        {
                                            Console.WriteLine(ticket.ticketName);
                                            Console.WriteLine("De prijs van dit ticket is " + ticket.ticketPrice + " euro.");
                                            Console.WriteLine("Er zijn in totaal " + ticket.maxTickets + " tickets waarvan er nog " + "(Will include remaining tickets)" + " over zijn");
                                            Console.WriteLine(ticket.ticketDescription);
                                            Console.WriteLine();
                                        }

                                    }
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    ClearCurrentConsoleLine();
                                    Console.WriteLine(thickLine);
                                    MenuFunction.menu(new string[] { "Order Ticket", "Return to Catalog", "Exit to Main Menu" });

                                }
                            }
                        }
                    
                }
            }
        }        
    }
}
