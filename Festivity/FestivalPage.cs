using System;
using System.IO;

namespace Festivity
{
    public class FestivalPage
    {
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONUserList users = JSONFunctionality.GetUserList();
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
                        if (LoggedInAccount.GetID() == user.AccountID)
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

        public static void ShowFestivalPage(int festivalId) //Displays the festival page
        {
            foreach (var festival in festivals.Festivals)
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
                                    Console.WriteLine(ticket.TicketName);
                                    Console.WriteLine("De prijs van dit ticket is " + ticket.TicketPrice + " euro.");
                                    Console.WriteLine("Er zijn in totaal " + ticket.MaxTickets + " tickets waarvan er nog " + "(Will include remaining tickets)" + " over zijn");
                                    Console.WriteLine(ticket.TicketDescription);
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