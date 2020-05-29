using Newtonsoft.Json;
using System;
using System.IO;

namespace Festivity
{
    class CatalogPageFilter
    {
        // Receives a Festival array and sorts it in alphabetical order by name
        public static Festival[] sort_name(Festival[] festivalArray)
        {
            festivalArray = Festival.festival_remove_padding(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].festivalName.CompareTo(festivalArray[i + 1].festivalName) > 0 && festivalArray[i].festivalId != -1)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return CatalogPage.add_or_remove_padding(festivalArray);
        }

        public static Festival[] sort_price(Festival[] festivalArray)
        {
            festivalArray = Festival.festival_remove_padding(festivalArray);
            Tuple<Festival, double>[] festivalArrayWithPrices = GetMinPrices(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].festivalName.CompareTo(festivalArray[i + 1].festivalName) > 0 && festivalArray[i].festivalId != -1)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return CatalogPage.add_or_remove_padding(festivalArray);
        }

        public static Tuple<Festival, double>[] GetMinPrices(Festival[] festivalArray)
        {
            Tuple<Festival, double>[] festivalsWithPrices = new Tuple<Festival, double>[festivalArray.Length];
            
            JSONTicketList tickets = JSONFunctionality.get_tickets();
            Ticket[] ticketArray = tickets.tickets.ToArray();


            for (int i = 0; i < festivalArray.Length; i++)
            {
                double minPrice = int.MaxValue;
                foreach (Ticket t in ticketArray)
                {
                    if (festivalArray[i].festivalId == t.festivalId)
                    {
                        if (t.ticketPrice < minPrice)
                        {
                            minPrice = t.ticketPrice;
                        }
                    }
                }
                festivalsWithPrices[i] = new Tuple<Festival, double>(festivalArray[i], minPrice);
            }
            return festivalsWithPrices;
        }

        // Receives a Festival array and sorts it in ascending order by date
        public static Festival[] sort_date(Festival[] festivalArray)
        {
            festivalArray = Festival.festival_remove_padding(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].festivalDate.to_identifier() > festivalArray[i + 1].festivalDate.to_identifier())
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return CatalogPage.add_or_remove_padding(festivalArray);
        }

        public static Festival[] filter_name(Festival[] festivalArray, string searchText)
        {
            Festival[] resultArray = new Festival[festivalArray.Length];
            int count = 0;

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].festivalName.ToLower().Contains(searchText.ToLower()))
                {
                    resultArray[count] = festivalArray[i];
                    count++;
                }
            }
            resultArray = CatalogPage.add_or_remove_padding(resultArray);
            return resultArray;
        }

        public static Festival[] filter_location(Festival[] festivalArray, string searchText)
        {
            Festival[] resultArray = new Festival[festivalArray.Length];
            int count = 0;

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].festivalLocation.city.ToLower().Contains(searchText.ToLower())
                    || festivalArray[i].festivalLocation.streetName.ToLower().Contains(searchText.ToLower()))
                {
                    resultArray[count] = festivalArray[i];
                    count++;
                }
            }
            resultArray = CatalogPage.add_or_remove_padding(resultArray);
            return resultArray;
        }

        public static Festival[] filter_genre(Festival[] festivalArray, string searchText)
        {
            Festival[] resultArray = new Festival[festivalArray.Length];
            int count = 0;

            for (int i = 0; i < festivalArray.Length; i++)
            {
                if (festivalArray[i].festivalGenre.ToLower().Contains(searchText.ToLower()))
                {
                    resultArray[count] = festivalArray[i];
                    count++;
                }
            }
            resultArray = CatalogPage.add_or_remove_padding(resultArray);
            return resultArray;
        }

        public static void clear_filters()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));
            CatalogPage.festivalArray = CatalogPage.add_or_remove_padding(Festivals.festivals.ToArray());
        }
    }
}