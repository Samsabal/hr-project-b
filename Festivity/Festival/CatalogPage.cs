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
        public static Festival[] festivalArray { get; set; }
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
                    MenuFunction.Menu(new string[] { "Sort by name", "Sort by date", "Sort by price", "Sort by availability", "Filter by festival name",
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
            festivalArray = CatalogPageFilter.SortAvailability(festivalArray);

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
        private static void DrawFestival(Festival festival)
        {
            Console.Write($"Name: {festival.FestivalName}");
            Console.SetCursorPosition(48, Console.CursorTop);
            Console.Write($"Genre: {festival.FestivalGenre}\n");
            Console.WriteLine($"Description: {festival.ShortenDescription(50)}");
            Console.Write($"City: {festival.FestivalLocation.City}");
            Console.SetCursorPosition(66 - 7 - festival.PricesToString().Length, Console.CursorTop);
            Console.Write($"Price: {festival.PricesToString()}\n");
            Console.Write($"Status: {festival.CheckAvailability()}");
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.Write($"Date: {festival.FestivalDate.ToShortDateString()} \n");
        }
    }
}