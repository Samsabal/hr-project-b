using System;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace Festivity
{

    public class CatalogPage
    {
        public static int currentPage;
        static int option;
        public static Festival[] festivalArray;
        public static string currentCatalogNavigation;
        public static int arraySize;

        // Class containing everything relevant to the catalog page in the console
        public static void catalog_main()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            currentCatalogNavigation = "main";
            currentPage = 0;

            // Makes an array with extra space to ensure there's always 5 festivals on screen
            int arraySize = Festivals.festivals.Count;
            int extraSpace = 5 - (arraySize % 5);

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

            // Adds placeholder festivals to ensure the application can always display 5 options at a time
            for (int i = 0; i <= extraSpace; i++)
            {
                Festivals.festivals.Add(emptyFestival);
            }

            festivalArray = Festivals.festivals.ToArray();

            option = 0;

            festivalArray = CatalogPageFilter.sort_date(festivalArray, arraySize);

            // Makes sure the console keeps refreshing, allowing input
            while (true)
            {
                if (currentCatalogNavigation == "main")
                {
                    Console.Clear();
                    show_festivals(festivalArray);
                    MenuFunction.menu(new string[]{"festival1", "festival2", "festival3", "festival4", "festival5",
                        "Next page", "Previous page", "Filter festivals", "Exit" },
                        new Festival[]{festivalArray[currentPage * 5 + 0], festivalArray[currentPage * 5 + 1],
                            festivalArray[currentPage * 5 + 2], festivalArray[currentPage * 5 + 3], festivalArray[currentPage * 5 + 4]});
                }
                else
                {
                    Console.Clear();
                    show_festivals(festivalArray);
                    MenuFunction.menu(new string[] { "Sort by name", 
                        "Sort by date", "Filter by genre", "Filter by price", 
                        "Filter by availability", "Filter by location", "Return" });
                }
            }
        }

        // Function that shows the currently selected festivals in the console
        private static void show_festivals(Festival[] festivalArray)
        {
            for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
            {

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(festivalArray[i].festivalName);
                Console.WriteLine(festivalArray[i].festivalDescription);
                Console.WriteLine(festivalArray[i].festivalDate.to_string());
                Console.WriteLine(festivalArray[i].festivalLocation.city);
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        // Function handling the navigation and selection of options in the catalog page
        private static void catalog_navigate(Festival[] festivalArray, int arraySize)
        {
            // String containing the selectable options in the console

            string[] ConsoleOptions = new string[]{"Select festival "+ festivalArray[currentPage*5].festivalName, "Select festival " + festivalArray[currentPage*5+1].festivalName,
                "Select festival " + festivalArray[currentPage*5+2].festivalName, "Select festival " + festivalArray[currentPage*5+3].festivalName,
                "Select festival " + festivalArray[currentPage*5+4].festivalName, "Next page", "Previous page", "Filter festivals", "Exit" };

            for (int i = 0; i < ConsoleOptions.Length; i++)
            {
                if (option == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine("{0}.{1}", i, ConsoleOptions[i]);
                if (option == i)
                {
                    Console.ResetColor();
                }
            }

            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (option != ConsoleOptions.Length - 1)
                {
                    option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (option != 0)
                {
                    option--;
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
                switch (option)
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
                        if (currentPage * 5 + 5 < arraySize)
                        {
                            currentPage++;
                        }
                        break;
                    case 6: // Redirection to previous catalog page
                        if (currentPage > 0)
                        {
                            currentPage--;
                        }
                        break;
                    case 7: // Redirection to filter functions
                        currentCatalogNavigation = "filter";
                        break;
                    case 8: // Exit option
                        Console.Clear();
                        Program.Main(new string[] { });
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
