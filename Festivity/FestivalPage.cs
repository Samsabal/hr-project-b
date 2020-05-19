using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Threading;

namespace Festivity
{
    public class FestivalPage
    {
        public static void clear_console_line() //Removes the last line in the ticket table for a cleaner look
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static bool age_check(int festivalId)//Checks if the user is old enough to use the program
        {
            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            foreach (var festival in Festivals.festivals)
            {
                if (festival.festivalId == festivalId)
                {
                    foreach (var user in users.users)
                    {
                        if (LoginPage.currentUserId == user.accountID)
                        {
                            int userAgeYear = festival.festivalDate.year - user.birthDate.year;
                            int userAgeMonth = festival.festivalDate.month - user.birthDate.month;
                            int userAgeDay = festival.festivalDate.day - user.birthDate.day;
                            if (userAgeYear * 365 + userAgeMonth * 30 + userAgeDay > festival.festivalAgeRestriction * 365)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static void festival_page(int festivalId)//Displays the festival page
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
            JSONTicketList Tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

            foreach (var festival in Festivals.festivals)
            {
                if (festival.festivalId == festivalId)
                {
                    MenuFunction.option = 0;
                    while (true) 
                    {
                        if (age_check(festivalId))
                        {
                            Console.WriteLine("Sorry but you are too young to enter this festival.");
                            Console.WriteLine("You need to be at least " + festival.festivalAgeRestriction + " years old in order to enter.");
                            Console.WriteLine("");
                            MenuFunction.menu(new string[] { "Return to Catalog", "Exit to Main Menu" });
                        }
                        else
                        {
                            string line = "----------------------------------------------------------------------";
                            string thickLine = "======================================================================";

                            Console.WriteLine(thickLine);
                            Console.WriteLine(festival.festivalName);
                            foreach (var user in users.users)
                            {
                                if (festival.festivalOrganiserId == user.accountID)
                                {
                                    Console.WriteLine("Organised by: " + user.companyName);
                                }
                            }
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
                            foreach (var ticket in Tickets.tickets)//Shows the tickets from the corresponding festival
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
                            clear_console_line();
                            Console.WriteLine(thickLine);
                            MenuFunction.menu(new string[] { "Order Ticket", "Return to Catalog", "Exit to Main Menu" });//The menu used in the festivalpage
                        }
                    }
                } 
            }
        }
            
    }        
}

