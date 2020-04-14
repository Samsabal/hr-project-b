using System;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace Festivity
{

    public class CatalogPage
    {
        static int CurrentPage;
        static int Option;
        static Festival[] festivalArray;
        static string currentCatalogNavigation;

        // Class containing everything relevant to the catalog page in the console
        public static void catalog_main()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            currentCatalogNavigation = "main";
            CurrentPage = 0;

            // Counts the amount of festivals in the JSON database
            int arraySize = Festivals.Festivals.Count;

            // Makes an array with extra space to ensure there's always 5 festivals on screen
            int extraSpace = 5 - (arraySize % 5);
            festivalArray = new Festival[arraySize + extraSpace + 1];

            // Adds the JSON festivals to an array for easier counting manipulation
            int festivalNumber = 0;
            foreach (var festival in Festivals.Festivals)
            {
                festivalArray[festivalNumber] = new Festival(festival.Id, festival.Name, festival.Description, festival.Location, festival.Date, festival.Time, festival.AgeLimit);
                festivalNumber++;
            }

            // Adds placeholder festivals to ensure the application can always display 5 options at a time
            for (int i = 0; i <= extraSpace; i++)
            {
                festivalArray[festivalNumber] = new Festival(-1, null, null, null, new Date(-1, -1, -1), null);
                festivalNumber++;
            }
            Option = 0;

            festivalArray = CatalogPageFilter.sort_date(festivalArray, arraySize);

            // Makes sure the console keeps refreshing, allowing input

            while (true)
            {
                if (currentCatalogNavigation == "main")
                {
                    Console.Clear();
                    show_festivals(festivalArray);
                    catalog_navigate(festivalArray, arraySize);
                }
                else
                {
                    Console.Clear();
                    show_festivals(festivalArray);
                    catalog_filter_navigate(arraySize);
                }
            }
        }

        // Function that shows the currently selected festivals in the console
        private static void show_festivals(Festival[] festivalArray)
        {
            for (int i = CurrentPage * 5; i < CurrentPage * 5 + 5; i++)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(festivalArray[i].Name);
                Console.WriteLine(festivalArray[i].Description);
                Console.WriteLine(festivalArray[i].Date.to_string());
                Console.WriteLine(festivalArray[i].Location);
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        // Function handling the navigation and selection of options in the catalog page
        private static void catalog_navigate(Festival[] festivalArray, int arraySize)
        {
            // String containing the selectable options in the console
            string[] ConsoleOptions = new string[]{"Select festival "+ festivalArray[CurrentPage*5].Name, "Select festival " + festivalArray[CurrentPage*5+1].Name,
                "Select festival " + festivalArray[CurrentPage*5+2].Name, "Select festival " + festivalArray[CurrentPage*5+3].Name,
                "Select festival " + festivalArray[CurrentPage*5+4].Name, "Next page", "Previous page", "Filter festivals", "Exit" };

            for (int i = 0; i < ConsoleOptions.Length; i++)
            {
                if (Option == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine("{0}.{1}", i, ConsoleOptions[i]);
                if (Option == i)
                {
                    Console.ResetColor();
                }
            }

            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (Option != ConsoleOptions.Length - 1)
                {
                    Option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (Option != 0)
                {
                    Option--;
                }
            }

            // When the escape key is pressed go back to the main menu.
            else if (KeyPressed.Key == ConsoleKey.Escape)
            {
                Program.Main(new string[] { });
            }



            // Switch statement used for redirecting the user to the right option that was chosen.
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                switch (Option)
                {
                    case 0: // Placeholder redirection festival 1
                        Thread.Sleep(10000);
                        break;
                    case 1: // Placeholder redirection festival 2
                        Thread.Sleep(10000);
                        break;
                    case 2: // Placeholder redirection festival 3
                        Thread.Sleep(10000);
                        break;
                    case 3: // Placeholder redirection festival 4
                        Environment.Exit(0);
                        break;
                    case 4: // Placeholder redirection festival 5
                        Environment.Exit(0);
                        break;
                    case 5: // Redirection to next catalog page
                        if (CurrentPage * 5 + 5 < arraySize)
                        {
                            CurrentPage++;
                        }
                        break;
                    case 6: // Redirection to previous catalog page
                        if (CurrentPage > 0)
                        {
                            CurrentPage--;
                        }
                        break;
                    case 7: // Redirection to filter functions
                        currentCatalogNavigation = "filter";
                        break;
                    case 8: // Exit option
                        Program.Main(new string[] { });
                        break;
                    default:
                        break;
                }
            }
        }

        // Function handling the navigation when the user tries to filter the catalog
        private static void catalog_filter_navigate(int arraySize)
        {
            // String containing the selectable options in the console
            string[] ConsoleOptions = new string[]{"Sort by name", "Sort by date",
                "Filter by genre", "Filter by price", "Filter by availability", "Filter by location", "Exit" };

            for (int i = 0; i < ConsoleOptions.Length; i++)
            {
                if (Option == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine("{0}.{1}", i, ConsoleOptions[i]);
                if (Option == i)
                {
                    Console.ResetColor();
                }
            }

            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (Option != ConsoleOptions.Length - 1)
                {
                    Option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (Option != 0)
                {
                    Option--;
                }
            }

            // When the escape key is pressed go back to the main menu.
            else if (KeyPressed.Key == ConsoleKey.Escape)
            {
                currentCatalogNavigation = "main";
            }



            // Switch statement used for redirecting the user to the right option that was chosen.
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                switch (Option)
                {
                    case 0: // sorts the catalog by name and returns to main navigation
                        festivalArray = CatalogPageFilter.sort_name(festivalArray, arraySize);
                        currentCatalogNavigation = "main";
                        CurrentPage = 0;
                        break;
                    case 1: // sorts the catalog by date and returns to main navigation
                        festivalArray = CatalogPageFilter.sort_date(festivalArray, arraySize);
                        currentCatalogNavigation = "main";
                        CurrentPage = 0;
                        break;
                    case 2: // Placeholder
                        Thread.Sleep(10000);
                        break;
                    case 3: // Placeholder
                        Thread.Sleep(10000);
                        break;
                    case 4: // Placeholder
                        Thread.Sleep(10000);
                        break;
                    case 5: // Redirection
                        break;
                    case 6: // Redirection
                        currentCatalogNavigation = "main";
                        break;
                }
            }
        }
    }
}
