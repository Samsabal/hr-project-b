using Newtonsoft.Json;
using System;
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
        public static void CatalogMain()
        {
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();

            activeScreen = true;
            currentCatalogNavigation = "main";
            currentPage = 0;

            // Makes an array with extra space to ensure there's always 5 festivals on screen
            festivalArray = AddOrRemovePadding(festivals.Festivals.ToArray());

            MenuFunction.option = 0;

            festivalArray = CatalogPageFilter.SortDate(festivalArray);

            // Makes sure the console keeps refreshing, allowing input
            while (activeScreen == true)
            {
                Console.SetCursorPosition(0, 0);
                if (currentCatalogNavigation == "main")
                {
                    ShowFestivals(festivalArray);
                    MenuFunction.Menu(new string[]{"festival1", "festival2", "festival3", "festival4", "festival5",
                        "Next page", "Previous page", "Filter festivals", "Exit to Main Menu" },
                        new Festival[]{festivalArray[currentPage * 5 + 0], festivalArray[currentPage * 5 + 1],
                            festivalArray[currentPage * 5 + 2], festivalArray[currentPage * 5 + 3], festivalArray[currentPage * 5 + 4]});
                }
                else
                {
                    ShowFestivals(festivalArray);
                    MenuFunction.Menu(new string[] { "Sort by name",
                        "Sort by date", "Filter by festival name", "Filter by genre", "Filter by location (City/Street)", "Clear filters", "Return to catalog" });
                }
            }
        }

        // Function that shows the currently selected festivals in the console
        private static void ShowFestivals(Festival[] festivalArray)
        {
            for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
            {
                string description;
                Console.WriteLine("------------------------------------------------------------------");
                Console.Write($"Name: {festivalArray[i].FestivalName}");
                if (festivalArray[i].FestivalDescription.Length > 50)
                {
                    description = festivalArray[i].FestivalDescription.Substring(0, 50) + "...";
                }
                else
                {
                    description = festivalArray[i].FestivalDescription;
                }
                Console.SetCursorPosition(48, Console.CursorTop);
                Console.Write($"Genre: {festivalArray[i].FestivalGenre}\n");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"City: {festivalArray[i].FestivalLocation.City}");
                Console.Write($"Status: {festivalArray[i].CheckStatus()}");
                Console.SetCursorPosition(50, Console.CursorTop);
                Console.Write($"Date: {festivalArray[i].FestivalDate} \n");
            }
            Console.WriteLine("------------------------------------------------------------------");
        }

        public static Festival[] AddOrRemovePadding(Festival[] festivals)
        {
            Festival emptyFestival = new Festival
            {
                FestivalID = -1,
                FestivalName = "",
                FestivalDate = new Date
                {
                    Day = -1,
                    Month = -1,
                    Year = -1
                },
                FestivalStartingTime = "",
                FestivalEndTime = "",
                FestivalLocation = new Address
                {
                    Country = "",
                    City = "",
                    ZipCode = "",
                    StreetName = "",
                    StreetNumber = ""
                },
                FestivalDescription = "",
                FestivalAgeRestriction = 18,
                FestivalGenre = "",
            };

            int actualFestivalAmount = 0;
            for (int i = 0; i < festivals.Length; i++)
            {
                if (festivals[i] == null)
                {
                    festivals[i] = emptyFestival;
                }
                actualFestivalAmount++;
            }

            int extraSpace = 5 - (actualFestivalAmount % 5);

            Festival[] resultArray = new Festival[actualFestivalAmount + extraSpace];
            for (int i = 0; i < actualFestivalAmount; i++)
            {
                resultArray[i] = festivals[i];
            }

            for (int j = actualFestivalAmount; j < (actualFestivalAmount + extraSpace); j++)
            {
                resultArray[j] = emptyFestival;
            }
            return resultArray;
        }
    }
}