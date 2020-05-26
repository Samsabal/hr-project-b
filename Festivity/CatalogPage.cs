using System;

namespace Festivity
{
    public class CatalogPage
    {
        public static int currentPage;
        public static Festival[] festivalArray;
        public static string currentCatalogNavigation;
        public static int arraySize;
        public static bool activeScreen;
        public static int selectedFestival;

        // Class containing everything relevant to the catalog page in the console
        public static void catalog_main()
        {
            JSONFestivalList Festivals = JSONFunctionality.get_festivals();

            activeScreen = true;
            currentCatalogNavigation = "main";
            currentPage = 0;

            // Makes an array with extra space to ensure there's always 5 festivals on screen
            festivalArray = add_or_remove_padding(Festivals.festivals.ToArray());

            MenuFunction.option = 0;

            festivalArray = CatalogPageFilter.sort_date(festivalArray);

            // Makes sure the console keeps refreshing, allowing input
            while (activeScreen == true)
            {
                Console.SetCursorPosition(0, 0);
                if (currentCatalogNavigation == "main")
                {
                    show_festivals(festivalArray);
                    MenuFunction.menu(new string[]{"festival1", "festival2", "festival3", "festival4", "festival5",
                        "Next page", "Previous page", "Filter festivals", "Exit to Main Menu" },
                        new Festival[]{festivalArray[currentPage * 5 + 0], festivalArray[currentPage * 5 + 1],
                            festivalArray[currentPage * 5 + 2], festivalArray[currentPage * 5 + 3], festivalArray[currentPage * 5 + 4]});
                }
                else
                {
                    show_festivals(festivalArray);
                    MenuFunction.menu(new string[] { "Sort by name",
                        "Sort by date", "Filter by festival name", "Filter by genre", "Filter by location (City/Street)", "Clear filters", "Return to catalog" });
                }
            }
        }

        // Function that shows the currently selected festivals in the console
        private static void show_festivals(Festival[] festivalArray)
        {
            for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
            {
                string description;
                Console.WriteLine("------------------------------------------------------------------");
                Console.Write($"Name: {festivalArray[i].festivalName}");
                if (festivalArray[i].festivalDescription.Length > 50)
                {
                    description = festivalArray[i].festivalDescription.Substring(0, 50) + "...";
                }
                else
                {
                    description = festivalArray[i].festivalDescription;
                }
                Console.SetCursorPosition(48, Console.CursorTop);
                Console.Write($"Genre: {festivalArray[i].festivalGenre}\n");
                Console.WriteLine($"Description: {description}");
                Console.Write($"City: {festivalArray[i].festivalLocation.city}");
                Console.SetCursorPosition(66-7-min_max_price(festivalArray[i].festivalId).Length, Console.CursorTop);
                Console.Write($"Price: {min_max_price(festivalArray[i].festivalId)}\n");
                Console.Write($"Status: {festivalArray[i].check_status()}");
                Console.SetCursorPosition(50, Console.CursorTop);
                Console.Write($"Date: {festivalArray[i].festivalDate.to_string()} \n");
            }
            Console.WriteLine("------------------------------------------------------------------");
        }

        public static string min_max_price(int festivalId)
        {
            JSONTicketList tickets = JSONFunctionality.get_tickets();
            Ticket[] ticketArray = tickets.tickets.ToArray();
            double minPrice = -1;
            double maxPrice = -1;
            foreach (Ticket t in ticketArray)
            {
                if ((t.festivalId == festivalId) && (minPrice == -1))
                {
                    minPrice = t.ticketPrice;
                    maxPrice = t.ticketPrice;
                }
                else if ((t.festivalId == festivalId) && (t.ticketPrice < minPrice)){
                    minPrice = t.ticketPrice;
                }
                else if ((t.festivalId == festivalId) && (t.ticketPrice > maxPrice)){
                    maxPrice = t.ticketPrice;
                }
            }

            if (minPrice == -1)
            {
                return "";
            }
            else if (minPrice == maxPrice)
            {
                return $"\u20AC{minPrice}";
            }
            else
            {
                return $"\u20AC{minPrice} - \u20AC{maxPrice}";
            }
        }

        public static Festival[] add_or_remove_padding(Festival[] festivals)
        {
            Festival emptyFestival = new Festival
            {
                festivalId = -1,
                festivalName = "",
                festivalDate = new Date
                {
                    day = -1,
                    month = -1,
                    year = -1
                },
                festivalStartingTime = "",
                festivalEndTime = "",
                festivalLocation = new Address
                {
                    country = "",
                    city = "",
                    zipCode = "",
                    streetName = "",
                    streetNumber = ""
                },
                festivalDescription = "",
                festivalAgeRestriction = 18,
                festivalGenre = "",
            };

            int actualfestivalamount = 0;
            for (int i = 0; i < festivals.Length; i++)
            {
                if (festivals[i] == null)
                {
                    festivals[i] = emptyFestival;
                }
                actualfestivalamount++;
            }

            int extraSpace = 5 - (actualfestivalamount % 5);

            Festival[] resultarray = new Festival[actualfestivalamount + extraSpace];
            for (int i = 0; i < actualfestivalamount; i++)
            {
                resultarray[i] = festivals[i];
            }

            for (int j = actualfestivalamount; j < (actualfestivalamount + extraSpace); j++)
            {
                resultarray[j] = emptyFestival;
            }
            return resultarray;
        }
    }
}
