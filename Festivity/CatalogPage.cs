using System;
using System.Collections.Generic;

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
            festivalArray = festivals.Festivals.ToArray();
            int lastpage = festivalArray.Length / 5;
            MenuFunction.option = 0;

            festivalArray = CatalogPageFilter.SortDate(festivalArray);

            // Makes sure the console keeps refreshing, allowing input
            while (activeScreen == true)
            {
                Console.SetCursorPosition(0, 0);
                if (currentCatalogNavigation == "main")
                {
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

                    ShowFestivals(festivalArray);
                    MenuFunction.Menu(menuOptionsList.ToArray(), currentFestivalList.ToArray());
                }
                else
                {
                    ShowFestivals(festivalArray);
                    MenuFunction.Menu(new string[] { "Sort by name",
                        "Sort by date", "Sort by price", "Filter by festival name", "Filter by genre", "Filter by location (City/Street)", "Clear filters", "Return to catalog" });
                }
            }
        }

        // Function that shows the currently selected festivals in the console
        private static void ShowFestivals(Festival[] festivalArray)
        {
            try
            {
                for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
                    if (festivalArray[i] != null)
                    {
                        {
                            Console.WriteLine("------------------------------------------------------------------");
                            ShowFestival(festivalArray[i]);
                        }
                    }
                Console.WriteLine("------------------------------------------------------------------");
            }
            catch (IndexOutOfRangeException e) { Console.WriteLine("------------------------------------------------------------------"); }
        }


        private static void ShowFestival(Festival festival)
        {
            string description;
            Console.Write($"Name: {festival.FestivalName}");
            if (festival.FestivalDescription.Length > 50)
            {
                description = festival.FestivalDescription.Substring(0, 50) + "...";
            }
            else
            {
                description = festival.FestivalDescription;
            }
            Console.SetCursorPosition(48, Console.CursorTop);
            Console.Write($"Genre: {festival.FestivalGenre}\n");
            Console.WriteLine($"Description: {description}");
            Console.Write($"City: {festival.FestivalLocation.City}");
            Console.SetCursorPosition(66 - 7 - MinMaxPrice(festival.FestivalID).Length, Console.CursorTop);
            Console.Write($"Price: {MinMaxPrice(festival.FestivalID)}\n");
            Console.Write($"Status: {festival.CheckStatus()}");
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.Write($"Date: {festival.FestivalDate} \n");
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
        public static string MinMaxPrice(int festivalId)
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