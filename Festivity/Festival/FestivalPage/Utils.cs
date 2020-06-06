namespace Festivity.Festival
{
    class Utils
    {
        public static int TicketsLeft(int ticketId, int maxTickets)
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

        public static bool AgeCheck(int festivalId) //Checks if the user is old enough to use the program
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
    }
}
