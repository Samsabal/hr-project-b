using System;
using System.IO;

namespace Festivity
{
    public class FestivalPage
    {
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONUserList users = JSONFunctionality.GetUsers();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();

        public static void ClearConsoleLine() //Removes the last line in the ticket table for a cleaner look
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static bool AgeCheck(int festivalId) //Checks if the user is old enough to use the program
        {
            foreach (var festival in festivals.Festivals)
            {
                if (festival.FestivalID == festivalId)
                {
                    foreach (var user in users.Users)
                    {
                        if (UserLoginPage.currentUserID == user.AccountID)
                        {
                            int userAgeYear = festival.FestivalDate.Year - user.birthDate.Year;
                            int userAgeMonth = festival.FestivalDate.Month - user.birthDate.Month;
                            int userAgeDay = festival.FestivalDate.Day - user.birthDate.Day;
                            if (userAgeYear * 365 + userAgeMonth * 30 + userAgeDay > festival.FestivalAgeRestriction * 365)
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

        public static int tickets_left(int ticketId, int maxTickets)
        {
            foreach (var ticket in Tickets.tickets)
            {
                if (ticket.ticketId == ticketId)
                {
                    foreach (var transaction in Transactions.transactions)
                    {
                        if (transaction.ticketID == ticket.ticketId)
                        {
                            int ticketsLeft = ticket.maxTickets - transaction.ticketNumber;
                            return ticketsLeft;
                        }
                    }
                }
            }
            return maxTickets;
        }

        public static void festival_page(int festivalId)//Displays the festival page
        {
            foreach (var festival in Festivals.festivals)
            {
                if (festival.FestivalID == festivalId)
                {
                    MenuFunction.option = 0;
                    while (true)
                    {
                        if (AgeCheck(festivalId))
                        {
                            Console.WriteLine("Sorry but you are too young to enter this festival.");
                            Console.WriteLine("You need to be at least " + festival.FestivalAgeRestriction + " years old in order to enter.");
                            Console.WriteLine("");
                            MenuFunction.Menu(new string[] { "Return to Catalog", "Exit to Main Menu" });
                        }
                        else
                        {
                            string line = "----------------------------------------------------------------------";
                            string thickLine = "======================================================================";

                            Console.WriteLine(thickLine);
                            Console.WriteLine(festival.FestivalName);
                            foreach (var user in users.Users)
                            {
                                if (festival.FestivalOrganiserID == user.AccountID)
                                {
                                    Console.WriteLine("Organised by: " + user.CompanyName);
                                }
                            }
                            Console.WriteLine(line);
                            Console.WriteLine("You need to be at least " + festival.FestivalAgeRestriction + " years old in order to enter.");
                            Console.WriteLine(festival.FestivalDescription);
                            Console.WriteLine(line);
                            Console.WriteLine("Starts at " + festival.FestivalStartingTime + " and ends on " + festival.FestivalEndTime + ".");
                            Console.WriteLine("Takes place on: " + festival.FestivalDate.Day + "-" + festival.FestivalDate.Month + "-" + festival.FestivalDate.Year);
                            Console.WriteLine();
                            Console.WriteLine(festival.FestivalLocation.StreetName + " " + festival.FestivalLocation.StreetNumber + ", " + festival.FestivalLocation.ZipCode);
                            Console.WriteLine(festival.FestivalLocation.City + ", " + festival.FestivalLocation.Country);
                            Console.WriteLine(thickLine);
                            foreach (var ticket in tickets.Tickets)//Shows the tickets from the corresponding festival
                            {
                                if (ticket.FestivalID == festival.FestivalID)
                                {
                                    int ticketId = ticket.ticketId;
                                    int maxTickets = ticket.maxTickets;
                                    Console.WriteLine(ticket.ticketName);
                                    Console.WriteLine("This ticket costs " + ticket.ticketPrice + " euro.");
                                    Console.WriteLine("There are " + ticket.maxTickets + " in total of which there are " + tickets_left(ticketId, maxTickets) + " left.");
                                    Console.WriteLine(ticket.ticketDescription);
                                    Console.WriteLine();
                                }
                            }
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            ClearConsoleLine();
                            Console.WriteLine(thickLine);
                            MenuFunction.Menu(new string[] { "Order Tickets", "Return to Catalog", "Exit to Main Menu" });//The menu used in the festivalpage
                        }
                    }
                }
            }
        }
    }
}