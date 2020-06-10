namespace Festivity.FestivalRegister
{
    /// <summary> This class is used to register a festival. </summary>
    internal class Handler
    {
        private static UIElements UI = new UIElements("Register");
        // Variables that manage the functionality of the registration.
        public static bool ActiveScreen { private get; set; }


        /// <summary> This function initiate the festival register </summary>
        /// <param name="festival"> </param>
        public static void InitiateFestivalRegister(FestivalModel festival)
        {
            UI.PathLine();
            UI.InfoLine("Command -q or -quit to go back.");
            UI.Pom("Name");
            FestivalReader.InputFestivalName(festival);
            UI.WhiteLinePom("Date");
            FestivalReader.InputFestivalDate(festival);
            FestivalReader.InputStartingTime(festival);
            FestivalReader.InputEndTime(festival);
            FestivalReader.InputCancelTime(festival);
            UI.WhiteLinePom("Address");
            FestivalReader.InputFestivalAdress(festival);
            UI.WhiteLinePom("Description");
            FestivalReader.ModifyFestivalDescription(festival);
            UI.WhiteLinePom("Restrictions");
            FestivalReader.ModifyFestivalAgeRestriction(festival);    
            FestivalRegisterMenu.savedTicketList = FestivalReader.InputFestivalTickets(FestivalRegisterMenu.savedTicketList);
            ConsoleHelperFunctions.ClearCurrentConsole();
            FestivalReader.InputGenre(festival);
        }

        /// <summary> This is a function to show the festivalregistration and let the user allow
        /// inputs. </summary
        public static void ShowFestivalRegister(FestivalModel festival)
        {
            // Makes sure the console keeps refreshing, allowing input.
            while (true)
            {
                UI.Header();
                UI.InfoLine("Edit your festival information");
                UI.Pom("Confirm Registration");
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