using Festivity.Utils;
using System;

namespace Festivity.Festival
{
    /// <summary>
    /// The main class for the festival catalog. Contains all methods for drawing information on the
    /// catalog screen.
    /// </summary>
    public class CatalogPage
    {
        public static int CurrentPage { get; set; }
        public static FestivalModel[] FestivalArray { get; set; }
        public static string CurrentCatalogNavigation { get; set; }

        /// <summary>
        /// The main method of the Catalog class, should be used when trying to go to the Catalog screen.
        /// </summary>
        public static void CatalogMain()
        {
            CatalogSetup();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                DrawCatalog();
                if (CurrentCatalogNavigation == "main")
                {
                    Menu.Draw(new CatalogMainMenu().CatalogMainMenuBuilder());
                }
                else
                {
                    Menu.Draw(new CatalogFilterMenu().CatalogFilterMenuBuilder());
                }
            }
        }

        /// <summary> This method handles the initial setup of the Catalog screen variables. </summary>
        private static void CatalogSetup()
        {
            JSONFestivalList festivals = JSONFunctions.GetFestivals();
            FestivalArray = festivals.Festivals.ToArray();
            FestivalArray = SortingFunctions.SortDate(FestivalArray);
            FestivalArray = SortingFunctions.SortAvailability(FestivalArray);

            CurrentCatalogNavigation = "main";
            CurrentPage = 0;
        }

        /// <summary>
        /// This method checks the amount of festivals on the current page and draws them with
        /// dividing lines in between.
        /// </summary>
        private static void DrawCatalog()
        {
            int lastpage = FestivalArray.Length / 5;
            if (FestivalArray.Length == 0)
            {
                Console.WriteLine("X===================================================================X");
                Console.WriteLine("|                                                                   |");
                Console.WriteLine("|           Sorry, there are no festivals available :(              |");
                Console.WriteLine("|                                                                   |");
            }
            else if (CurrentPage == lastpage)
            {
                for (int i = CurrentPage * 5; i < FestivalArray.Length; i++)
                {
                    if (i == CurrentPage * 5)
                    {
                        Console.WriteLine("X===================================================================X");
                    }
                    else
                    {
                        Console.WriteLine("|-------------------------------------------------------------------|");
                    }
                    DrawFestival(FestivalArray[i]);
                }
            }
            else
            {
                for (int i = CurrentPage * 5; i < CurrentPage * 5 + 5; i++)
                {
                    if (i == CurrentPage * 5)
                    {
                        Console.WriteLine("X===================================================================X");
                    }
                    else
                    {
                        Console.WriteLine("|-------------------------------------------------------------------|");
                    }
                    DrawFestival(FestivalArray[i]);
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