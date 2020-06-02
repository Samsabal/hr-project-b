using System;
using System.Collections.Generic;

namespace Festivity
{
    public class CatalogPage
    {
        public static int currentPage { get; set; }
        public static Festival[] festivalArray;
        public static string currentCatalogNavigation;
        public static int selectedFestival;

        // Class containing everything relevant to the catalog page in the console

        public static void CatalogMain()
        {
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();
            currentCatalogNavigation = "main";
            currentPage = 0;

            // Makes an array with extra space to ensure there's always 5 festivals on screen
            festivalArray = festivals.Festivals.ToArray();
            festivalArray = CatalogPageFilter.SortDate(festivalArray);

            // Makes sure the console keeps refreshing, allowing input
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                if (currentCatalogNavigation == "main")
                {
                    DrawCatalogMain();
                }
                else
                {
                    DrawCatalogFilter();
                }
            }
        }

        private static void DrawCatalogMain()
        {
            int lastpage = festivalArray.Length / 5;
            List<string> menuOptionsList = new List<string>();
            List<Festival> currentFestivalList = new List<Festival>();
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

            DrawCatalog(festivalArray);
            MenuFunction.Menu(menuOptionsList.ToArray(), currentFestivalList.ToArray());
        }

        private static void DrawCatalogFilter()
        {
            DrawCatalog(festivalArray);
            MenuFunction.Menu(new string[] { "Sort by name", "Sort by date", "Sort by price", "Filter by festival name",
                "Filter by genre", "Filter by location (City/Street)", "Clear filters", "Return to catalog" });
        }

        // Function that shows the currently selected festivals in the console
        private static void DrawCatalog(Festival[] festivalArray)
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

        private static void DrawFestival(Festival festival)
        {
            Console.Write($"Name: {festival.FestivalName}");
            Console.SetCursorPosition(48, Console.CursorTop);
            Console.Write($"Genre: {festival.FestivalGenre}\n");
            Console.WriteLine($"Description: {ShortenFestivalDescription(festival.FestivalDescription)}");
            Console.Write($"City: {festival.FestivalLocation.City}");
            Console.SetCursorPosition(66 - 7 - MinMaxPrice(festival.FestivalID).Length, Console.CursorTop);
            Console.Write($"Price: {MinMaxPrice(festival.FestivalID)}\n");
            Console.Write($"Status: {festival.CheckStatus()}");
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.Write($"Date: {festival.FestivalDate} \n");
        }

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

        private static string MinMaxPrice(int festivalId)
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
    }
}