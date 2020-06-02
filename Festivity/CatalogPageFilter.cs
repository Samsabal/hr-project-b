using Newtonsoft.Json;
using System;
using System.IO;

namespace Festivity
{
    internal class CatalogPageFilter
    {
        // Receives a Festival array and sorts it in alphabetical order by name
        public static Festival[] SortName(Festival[] festivalArray)
        {
            festivalArray = Festival.FestivalRemovePadding(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].FestivalName.CompareTo(festivalArray[i + 1].FestivalName) > 0 && festivalArray[i].FestivalID != -1)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        public static Festival[] SortPrice(Festival[] festivalArray)
        {
            festivalArray = Festival.FestivalRemovePadding(festivalArray);
            Tuple<Festival, double>[] festivalArrayWithPrices = GetMinPrices(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArrayWithPrices[i].Item2 >= festivalArrayWithPrices[i+1].Item2)
                    {
                        Tuple<Festival, double> temp = festivalArrayWithPrices[i];
                        festivalArrayWithPrices[i] = festivalArrayWithPrices[i + 1];
                        festivalArrayWithPrices[i + 1] = temp;
                    }
                }
            }
            Festival[] resultArray = new Festival[festivalArrayWithPrices.Length];
            for(int i = 0; i < festivalArrayWithPrices.Length; i++)
            {
                resultArray[i] = festivalArrayWithPrices[i].Item1;
            }

            return resultArray;
        }

        public static Tuple<Festival, double>[] GetMinPrices(Festival[] festivalArray)
        {
            Tuple<Festival, double>[] festivalsWithPrices = new Tuple<Festival, double>[festivalArray.Length];
            
            JSONTicketList tickets = JSONFunctionality.GetTickets();
            Ticket[] ticketArray = tickets.Tickets.ToArray();


            for (int i = 0; i < festivalArray.Length; i++)
            {
                double minPrice = int.MaxValue;
                foreach (Ticket t in ticketArray)
                {
                    if (festivalArray[i].FestivalID == t.FestivalID)
                    {
                        if (t.TicketPrice < minPrice)
                        {
                            minPrice = t.TicketPrice;
                        }
                    }
                }
                festivalsWithPrices[i] = new Tuple<Festival, double>(festivalArray[i], minPrice);
            }
            return festivalsWithPrices;
        }

        // Receives a Festival array and sorts it in ascending order by date
        public static Festival[] SortDate(Festival[] festivalArray)
        {
            festivalArray = Festival.FestivalRemovePadding(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].FestivalDate.ToIdentifier() > festivalArray[i + 1].FestivalDate.ToIdentifier())
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        public static Festival[] FilterName(Festival[] festivalArray, string searchText)
        {
            Festival[] resultArray = new Festival[festivalArray.Length];
            int count = 0;

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].FestivalName.ToLower().Contains(searchText.ToLower()))
                {
                    resultArray[count] = festivalArray[i];
                    count++;
                }
            }
            return resultArray;
        }

        public static Festival[] FilterLocation(Festival[] festivalArray, string searchText)
        {
            Festival[] resultArray = new Festival[festivalArray.Length];
            int count = 0;

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].FestivalLocation.City.ToLower().Contains(searchText.ToLower())
                    || festivalArray[i].FestivalLocation.StreetName.ToLower().Contains(searchText.ToLower()))
                {
                    resultArray[count] = festivalArray[i];
                    count++;
                }
            }
            return resultArray;
        }

        public static Festival[] FilterGenre(Festival[] festivalArray, string searchText)
        {
            Festival[] resultArray = new Festival[festivalArray.Length];
            int count = 0;

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].FestivalGenre.ToLower().Contains(searchText.ToLower()))
                {
                    resultArray[count] = festivalArray[i];
                    count++;
                }
            }
            return resultArray;
        }

        public static void ClearFilters()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));
            CatalogPage.festivalArray = Festivals.Festivals.ToArray();
        }
    }
}