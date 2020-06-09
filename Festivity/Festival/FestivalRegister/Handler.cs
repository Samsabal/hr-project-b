namespace Festivity.FestivalRegister
{
    /// <summary> This class is used to register a festival. </summary>
    internal class Handler
    {
        // Variables that manage the functionality of the registration.
        public static bool ActiveScreen { private get; set; }

        public static string CurrentRegisterSelection { private get; set; }

        // Database arrays.
        private static readonly JSONFestivalList festivals = JSONFunctions.GetFestivals();

        private static readonly JSONTicketList tickets = JSONFunctions.GetTickets();

        /// <summary> This function initiate the festival register </summary>
        /// <param name="festival"> </param>
        public static void InitiateFestivalRegister(FestivalModel festival)
        {
            FestivalReader.InputFestivalName(festival);
            FestivalReader.InputFestivalDate(festival);
            FestivalReader.InputStartingTime(festival);
            FestivalReader.InputEndTime(festival);
            FestivalReader.InputFestivalAdress(festival);
            FestivalReader.ModifyFestivalDescription(festival);
            FestivalReader.ModifyFestivalAgeRestriction(festival);
            FestivalReader.InputCancelTime(festival);
            FestivalRegisterMenu.savedTicketList = FestivalReader.InputFestivalTickets(FestivalRegisterMenu.savedTicketList);
            FestivalReader.InputGenre(festival);
        }

        /// <summary> This is a function to show the festivalregistration and let the user allow
        /// inputs. </summary
        public static void ShowFestivalRegister(FestivalModel festival)
        {
            // Makes sure the console keeps refreshing, allowing input.
            while (true)
            {
                Menu.Draw(new FestivalRegisterMenu().FestivalRegisterMenuBuilder(festival));
            }
        }

        /// <summary>
        /// This is a function to retrieve the latest registered festivalid and create the next festivalid.
        /// </summary>
        /// <param name="festivals"> </param>
        /// <returns> festivalID </returns>
        public static int SetFestivalId(JSONFestivalList festivals)
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

        /// <summary>
        /// This is a function to retrieve the latest registered ticketid and create the next ticketid.
        /// </summary>
        /// <param name="tickets"> </param>
        /// <returns> </returns>
        public static int SetTicketID(JSONTicketList tickets)
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
    }
}