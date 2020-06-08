using Festivity.Utils;
using System;

namespace Festivity
{
    /// <summary>
    /// The main class for the festival catalog. Contains all methods for drawing information on the
    /// catalog screen.
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
                    Menu.Draw(MenuBuilder.CatalogMain());
                }
                else
                {
                    Menu.Draw(MenuBuilder.CatalogFilter());
                }
            }
        }

        /// <summary> This method handles the initial setup of the Catalog screen variables. </summary>
        private static void CatalogSetup()
        {
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();
            festivalArray = festivals.Festivals.ToArray();
            festivalArray = SortingFunctions.SortDate(festivalArray);
            festivalArray = SortingFunctions.SortAvailability(festivalArray);

            currentCatalogNavigation = "main";
            currentPage = 0;
        }

        /// <summary>
        /// This method checks the amount of festivals on the current page and draws them with
        /// dividing lines in between.
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
                        Console.WriteLine("X===================================================================X");
                    }
                    else
                    {
                        Console.WriteLine("|-------------------------------------------------------------------|");
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
                        Console.WriteLine("X===================================================================X");
                    }
                    else
                    {
                        Console.WriteLine("|-------------------------------------------------------------------|");
                    }
                    DrawFestival(festivalArray[i]);
                }
            }
            Console.WriteLine("X===================================================================X");
        }

        /// <summary>
        /// This method takes a festival and draws it in the desired format for the festival catalog.
        /// </summary>
        /// <param name="festival"> A Festival object </param>
        private static void DrawFestival(FestivalModel festival)
        {
            Console.Write($"| Name: {festival.FestivalName}");
            Console.SetCursorPosition(49, Console.CursorTop);
            Console.Write($"Genre: {festival.FestivalGenre} |\n");
            Console.WriteLine($"| Description: {festival.SetDescriptionLength(52)} |");
            Console.Write($"| City: {festival.FestivalLocation.City}");
            Console.SetCursorPosition(60 - festival.PricesToString().Length, Console.CursorTop);
            Console.Write($"Price: {festival.PricesToString()} |\n");
            Console.Write($"| Status: {festival.CheckAvailability()}");
            Console.SetCursorPosition(51, Console.CursorTop);
            Console.Write($"Date: {festival.FestivalDate.ToShortDateString()} |\n");
        }
    }
}