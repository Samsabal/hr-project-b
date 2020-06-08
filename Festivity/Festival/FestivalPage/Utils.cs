using System;

namespace Festivity.Festival
{
    internal class Utils
    {
        public static int TicketsLeft(int ticketId, int maxTickets) // Checks how many tickets there are left
        {
            foreach (var ticket in JSONFunctionality.GetTickets().Tickets)
            {
                if (ticket.TicketID == ticketId)
                {
                    foreach (var transaction in JSONFunctionality.GetTransactions().Transactions)
                    {
                        if (transaction.TicketID == ticket.TicketID)
                        {
                            int ticketsLeft = ticket.MaxTickets - transaction.TicketAmount;
                            return ticketsLeft;
                        }
                    }
                }
            }
            return maxTickets;
        }

        public static bool AgeCheck(int festivalId) // Checks if the user is old enough to use the program
        {
            foreach (var festival in JSONFunctionality.GetFestivals().Festivals)
            {
                if (festival.FestivalID == festivalId)
                {
                    foreach (var user in JSONFunctionality.GetUserList().Users)
                    {
                        if (LoggedInAccount.GetID() == user.AccountID)
                        {
                            int userAgeYear = festival.FestivalDate.Year - user.BirthDate.Year;
                            int userAgeMonth = festival.FestivalDate.Month - user.BirthDate.Month;
                            int userAgeDay = festival.FestivalDate.Day - user.BirthDate.Day;
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

        public static void ClearConsoleLine() // Removes the last line in the ticket table for a cleaner look
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void DescriptionParts() // Splits up the description in parts that fit in the festival page and displays them
        {
            int DescriptionLength = SelectedFestival.festival.FestivalDescription.Length;
            int LineCount = 0;

            while (DescriptionLength > 75 * LineCount)
            {
                if (DescriptionLength - 75 * LineCount > 75)
                {
                    Console.WriteLine("| " + SelectedFestival.festival.FestivalDescription.Substring(75 * LineCount, 75) + " |");
                    LineCount += 1;
                }
                else
                {
                    Console.WriteLine($"| {SelectedFestival.festival.FestivalDescription.Substring(75 * LineCount)}".PadRight(78) + "|");
                    LineCount += 1;
                }
            }

        }
    }
}