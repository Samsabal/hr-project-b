using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Utils
{
    class FilterFunctions
    {

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
    }
}
