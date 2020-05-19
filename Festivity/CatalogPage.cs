﻿using System;
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

        // Class containing everything relevant to the catalog page in the console
        public static void catalog_main()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

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
                string availability;
                if (festivalArray[i] == null || festivalArray[i].festivalId == -1)
                {
                    availability = "";
                }
                else
                {
                    int currentDate = int.Parse(DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString() + DateTime.UtcNow.Day.ToString());
                    int currentTime = int.Parse(DateTime.UtcNow.Hour.ToString() + DateTime.UtcNow.Minute.ToString());
                    if (festivalArray[i].festivalDate.to_identifier() < currentDate)
                    {
                        availability = "This festival has ended";
                    }
                    else if (festivalArray[i].festivalDate.to_identifier() == currentDate)
                    {
                        if (int.Parse(festivalArray[i].festivalEndTime) < currentTime)
                        {
                            availability = "This festival has ended";
                        }
                        else if (currentTime < int.Parse(festivalArray[i].festivalStartingTime))
                        {
                            availability = "Tickets available";
                        }
                        else
                        {
                            availability = "Ongoing";
                        }
                    }
                    else
                    {
                        availability = "Tickets available";
                    }
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(festivalArray[i].festivalName);
                Console.WriteLine(festivalArray[i].festivalDescription);
                Console.WriteLine(festivalArray[i].festivalDate.to_string());
                Console.WriteLine(festivalArray[i].festivalLocation.city);
                Console.WriteLine(availability);
            }
            Console.WriteLine("------------------------------------------------------------");
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
