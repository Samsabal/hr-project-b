using System;
using System.Collections.Generic;

namespace Festivity
{
    /// <summary>
    /// The main class for the festival catalog.
    /// Contains all methods for drawing information on the catalog screen.
    /// </summary>
    public class CatalogPage
    {
        public static int currentPage { get; set; }
        public static FestivalModel[] festivalArray { get; set; }
        public static string currentCatalogNavigation { get; set; }
        public static int selectedFestival;

        /// <summary>
        /// The main method of the Catalog class, should be used when trying to go to the Catalog screen.
        /// </summary>
        public static void CatalogMain()
        {
            CatalogSetup();
            // Makes sure the console keeps refreshing, allowing input
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                DrawCatalog();
                if (currentCatalogNavigation == "main")
                {
                    DrawMenuMain();
                }
                else
                {
                    MenuFunction.Menu(new string[] { "Sort by name", "Sort by date", "Sort by price", "Filter by festival name",
                        "Filter by genre", "Filter by location (City/Street)", "Clear filters", "Return to catalog" });
                }
            }
        }
        /// <summary>
        /// This method handles the initial setup of the Catalog screen variables.
        /// </summary>
        private static void CatalogSetup()
        {
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();
            festivalArray = festivals.Festivals.ToArray();
            festivalArray = CatalogPageFilter.SortDate(festivalArray);

            currentCatalogNavigation = "main";
            currentPage = 0;
        }

        /// <summary>
        /// This method checks the amount of festivals on the current page and draws the right amount of menu options.
        /// </summary>
        private static void DrawMenuMain()
        {
            int lastpage = festivalArray.Length / 5;
            List<string> menuOptionsList = new List<string>();
            List<FestivalModel> currentFestivalList = new List<FestivalModel>();
            if (currentPage == lastpage)
            {
                for (int i = 0; i < festivalArray.Length % 5; i++)
                {
                    menuOptionsList.Add("Select festival:" + festivalArray[currentPage * 5 + i]);
                    currentFestivalList.Add(festivalArray[currentPage * 5 + i]);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    menuOptionsList.Add("Select festival:" + festivalArray[currentPage * 5 + i]);
                    currentFestivalList.Add(festivalArray[currentPage * 5 + i]);
                }
            }

            menuOptionsList.Add("Next page");
            menuOptionsList.Add("Previous page");
            menuOptionsList.Add("Filter festivals");
            menuOptionsList.Add("Exit to Main Menu");

            MenuFunction.Menu(menuOptionsList.ToArray(), currentFestivalList.ToArray());
        }

        /// <summary>
        /// This method checks the amount of festivals on the current page and draws them with dividing lines in between.
        /// </summary>
        private static void DrawCatalog()
        {
            int lastpage = festivalArray.Length / 5;
            if (currentPage == lastpage)
            {
                for (int i = currentPage * 5; i < festivalArray.Length; i++)
                {
                    if (i == currentPage * 5)
                    {
                        Console.WriteLine("==================================================================");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------");
                    }
                    DrawFestival(festivalArray[i]);
                }
            }
            else
            {
                for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
                {
                    if (i == currentPage * 5)
                    {
                        Console.WriteLine("==================================================================");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------");
                    }
                    DrawFestival(festivalArray[i]);
                }
            }
            Console.WriteLine("==================================================================");
        }
        /// <summary>
        /// This method takes a festival and draws it in the desired format for the festival catalog.
        /// </summary>
        /// <param name="festival">A Festival object</param>
        private static void DrawFestival(FestivalModel festival)
        {
            Console.Write($"Name: {festival.FestivalName}");
            Console.SetCursorPosition(48, Console.CursorTop);
            Console.Write($"Genre: {festival.FestivalGenre}\n");
            Console.WriteLine($"Description: {ShortenFestivalDescription(festival.FestivalDescription)}");
            Console.Write($"City: {festival.FestivalLocation.City}");
            Console.SetCursorPosition(66 - 7 - PricesToString(MinMaxPrice(festival.FestivalID)).Length, Console.CursorTop);
            Console.Write($"Price: {PricesToString(MinMaxPrice(festival.FestivalID))}\n");
            Console.Write($"Status: {festival.CheckStatus()}");
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.Write($"Date: {festival.FestivalDate} \n");
        }
        /// <summary>
        /// This method takes a string and returns a shortened version if it is over 50 characters long.
        /// </summary>
        /// <param name="description">A festival description string.</param>
        /// <returns>
        /// A shortened version of the input string if it is over 50 characters, otherwise returns the entire string.
        /// </returns>
        private static string ShortenFestivalDescription(string description)
        {
            if (description.Length > 50)
            {
                return description.Substring(0, 50) + "...";
            }
            else
            {
                return description;
            }
        }
        /// <summary>
        /// This method takes a festivalID and checks all the associated tickets for the lowest and highest price.
        /// </summary>
        /// <param name="festivalId">A festivalID to check prices for</param>
        /// <returns>
        /// A Tuple<double,double> with the first item being the lowest found price and the second item being the highest found price
        /// </returns>
        private static Tuple<double,double> MinMaxPrice(int festivalId)
        {
            JSONTicketList tickets = JSONFunctionality.GetTickets();
            Ticket[] ticketArray = tickets.Tickets.ToArray();
            double minPrice = -1;
            double maxPrice = -1;
            foreach (Ticket t in ticketArray)
            {
                if ((t.FestivalID == festivalId) && (minPrice == -1))
                {
                    minPrice = t.TicketPrice;
                    maxPrice = t.TicketPrice;
                }
                else if ((t.FestivalID == festivalId) && (t.TicketPrice < minPrice))
                {
                    minPrice = t.TicketPrice;
                }
                else if ((t.FestivalID == festivalId) && (t.TicketPrice > maxPrice))
                {
                    maxPrice = t.TicketPrice;
                }
            }
            return new Tuple<double, double>(minPrice,maxPrice);
        }
        /// <summary>
        /// This method takes a Tuple<double,double> and returns a string formatted version for display on the catalog screen
        /// </summary>
        /// <param name="minMax">A Tuple<double,double> containing the lowest and highest price of a festival</param>
        /// <returns>
        /// A string depending on the amount of different values found in minMax
        /// </returns>
        private static string PricesToString(Tuple<double, double> minMax)
        {
            if (minMax.Item1 == -1)
            {
                return "Price not found";
            }
            else if (minMax.Item1 == minMax.Item2)
            {
                return $"\u20AC{minMax.Item1}";
            }
            else
            {
                return $"\u20AC{minMax.Item1} - \u20AC{minMax.Item2}";
            }
        }
    }
}