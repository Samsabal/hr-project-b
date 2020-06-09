using Festivity.FestivalRegister;

namespace Festivity
{
    /// <summary> This class is used to register a festival. </summary>
    internal class RegisterHandler
    {
        // Variables that manage the functionality of the registration.
        public static bool ActiveScreen { private get; set; }

        public static string CurrentRegisterSelection { private get; set; }

        // Database arrays.
        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();

        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();

        /// <summary> This function initiate the festival register </summary>
        /// <param name="festival"> </param>
        public static void InitiateFestivalRegister(FestivalModel festival)
        {
            Modifier.InputFestivalName(festival);
            Modifier.InputFestivalDate(festival);
            Modifier.InputStartingTime(festival);
            Modifier.InputEndTime(festival);
            Modifier.InputFestivalAdress(festival);
            Modifier.ModifyFestivalDescription(festival);
            Modifier.ModifyFestivalAgeRestriction(festival);
            Modifier.InputCancelTime(festival);
            FestivalRegisterMenu.savedTicketList = Modifier.InputFestivalTickets(FestivalRegisterMenu.savedTicketList);
            Modifier.InputGenre(festival);
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