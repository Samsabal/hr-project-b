using System;
using Newtonsoft.Json;
using System.IO;

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
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            activeScreen = true;
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

            MenuFunction.option = 0;

            festivalArray = CatalogPageFilter.sort_date(festivalArray, arraySize);

            // Makes sure the console keeps refreshing, allowing input
            while (activeScreen == true)
            {
                if (currentCatalogNavigation == "main")
                {
                    Console.Clear();
                    show_festivals(festivalArray);
                    MenuFunction.menu(new string[]{"festival1", "festival2", "festival3", "festival4", "festival5",
                        "Next page", "Previous page", "Filter festivals", "Exit to Main Menu" },
                        new Festival[]{festivalArray[currentPage * 5 + 0], festivalArray[currentPage * 5 + 1],
                            festivalArray[currentPage * 5 + 2], festivalArray[currentPage * 5 + 3], festivalArray[currentPage * 5 + 4]});
                }
                else
                {
                    Console.Clear();
                    show_festivals(festivalArray);
                    MenuFunction.menu(new string[] { "Sort by name", 
                        "Sort by date", "Filter by genre", "Filter by price", 
                        "Filter by availability", "Filter by location", "Return to catalog" });
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
    }
}
