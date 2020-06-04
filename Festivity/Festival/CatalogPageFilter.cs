using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Festivity
{
    internal class CatalogPageFilter
    {
        /// <summary>
        /// Sorts a given Festival[] alphabetically by the names of the festivals.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival array to be sorted.
        /// </param>
        /// <returns>
        /// Returns a Festival[] sorted alphabetically by festivalname
        /// </returns>
        public static Festival[] SortName(Festival[] festivalArray)
        {
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

        /// <summary>
        /// Sorts a given Festival[] lowest to highest according to the lowest ticket prices of the festivals.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival array to be sorted.
        /// </param>
        /// <returns>
        /// Returns a Festival[] sorted by the lowest prices.
        /// </returns>
        public static Festival[] SortPrice(Festival[] festivalArray)
        {
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

        /// <summary>
        /// Takes a Festival[] and returns a Tuple<Festival, double>[] containing the same festivals buy with their minimum ticket prices.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival[] that you want to get the minimum prices for.
        /// </param>
        /// <returns>
        /// Returns a Tuple<festival, double>[] containing the input Festivals with their lowest ticket prices.
        /// </returns>
        public static Tuple<Festival, double>[] GetMinPrices(Festival[] festivalArray)
        {
            Tuple<Festival, double>[] festivalsWithPrices = new Tuple<Festival, double>[festivalArray.Length];
            
            Ticket[] ticketArray = JSONFunctionality.GetTickets().Tickets.ToArray();

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

        /// <summary>
        /// Sorts a given Festival[] from earliest to latest by the dates of the festivals.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival array to be sorted.
        /// </param>
        /// <returns>
        /// Returns a Festival[] sorted by FestivalDate
        /// </returns>
        public static Festival[] SortDate(Festival[] festivalArray)
        {
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].FestivalDate > festivalArray[i + 1].FestivalDate)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        /// <summary>
        /// Takes a Festival[] and a string and returns all Festivals where the festival name contains the search text.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival array to be searched in.
        /// </param>
        /// <param name="searchText">
        /// string that needs to be searched for
        /// </param>
        /// <returns>
        /// Returns a Festival[] containing all the festivals where the name contains the search text.
        /// </returns>
        public static Festival[] FilterName(Festival[] festivalArray, string searchText)
        {
            List<Festival> resultList = new List<Festival>();

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].FestivalName.ToLower().Contains(searchText.ToLower()))
                {
                    resultList.Add(festivalArray[i]);
                }
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Takes a Festival[] and a string and returns all Festivals where the festival location contains the search text.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival array to be searched in.
        /// </param>
        /// <param name="searchText">
        /// string that needs to be searched for
        /// </param>
        /// <returns>
        /// Returns a Festival[] containing all the festivals where the festival location contains the search text.
        /// </returns>
        public static Festival[] FilterLocation(Festival[] festivalArray, string searchText)
        {
            List<Festival> resultList = new List<Festival>();

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].FestivalLocation.City.ToLower().Contains(searchText.ToLower())
                    || festivalArray[i].FestivalLocation.StreetName.ToLower().Contains(searchText.ToLower()))
                {
                    resultList.Add(festivalArray[i]);
                }
            }
            return resultList.ToArray();
        }

        /// <summary>
        /// Takes a Festival[] and a string and returns all Festivals where the festival genre contains the search text.
        /// </summary>
        /// <param name="festivalArray">
        /// Festival array to be searched in.
        /// </param>
        /// <param name="searchText">
        /// string that needs to be searched for
        /// </param>
        /// <returns>
        /// Returns a Festival[] containing all the festivals where the festival genre contains the search text.
        /// </returns>
        public static Festival[] FilterGenre(Festival[] festivalArray, string searchText)
        {
            List<Festival> resultList = new List<Festival>();

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].FestivalGenre.ToLower().Contains(searchText.ToLower()))
                {
                    resultList.Add(festivalArray[i]);
                }
            }
            return resultList.ToArray();
        }

        /// <summary>
        /// This method resets the currently selected filters for the CatalogPage by reloading the data from the Festival JSON
        /// </summary>
        public static void ClearFilters()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));
            CatalogPage.festivalArray = Festivals.Festivals.ToArray();
        }
    }
}