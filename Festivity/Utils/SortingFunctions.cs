using System;

namespace Festivity.Utils
{
    internal class SortingFunctions
    {
        /// <summary> Sorts a given Festival[] alphabetically by the names of the festivals. </summary>
        /// <param name="festivalArray"> Festival array to be sorted. </param>
        /// <returns> Returns a Festival[] sorted alphabetically by festivalname </returns>
        public static FestivalModel[] SortName(FestivalModel[] festivalArray)
        {
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].FestivalName.CompareTo(festivalArray[i + 1].FestivalName) > 0 && festivalArray[i].FestivalID != -1)
                    {
                        FestivalModel temp = festivalArray[i];
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
        /// <param name="festivalArray"> Festival array to be sorted. </param>
        /// <returns> Returns a Festival[] sorted by the lowest prices. </returns>
        public static FestivalModel[] SortPrice(FestivalModel[] festivalArray)
        {
            Tuple<FestivalModel, double>[] festivalArrayWithPrices = GetMinPrices(festivalArray);
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArrayWithPrices[i].Item2 >= festivalArrayWithPrices[i + 1].Item2)
                    {
                        Tuple<FestivalModel, double> temp = festivalArrayWithPrices[i];
                        festivalArrayWithPrices[i] = festivalArrayWithPrices[i + 1];
                        festivalArrayWithPrices[i + 1] = temp;
                    }
                }
            }
            FestivalModel[] resultArray = new FestivalModel[festivalArrayWithPrices.Length];
            for (int i = 0; i < festivalArrayWithPrices.Length; i++)
            {
                resultArray[i] = festivalArrayWithPrices[i].Item1;
            }

            return resultArray;
        }

        /// <summary> Takes a Festival[] and returns a Tuple<Festival, double>[] containing the same
        /// festivals buy with their minimum ticket prices. </summary> <param name="festivalArray">
        /// Festival[] that you want to get the minimum prices for. </param> <returns> Returns a
        /// Tuple<festival, double>[] containing the input Festivals with their lowest ticket
        /// prices. </returns>
        private static Tuple<FestivalModel, double>[] GetMinPrices(FestivalModel[] festivalArray)
        {
            Tuple<FestivalModel, double>[] festivalsWithPrices = new Tuple<FestivalModel, double>[festivalArray.Length];

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
                festivalsWithPrices[i] = new Tuple<FestivalModel, double>(festivalArray[i], minPrice);
            }
            return festivalsWithPrices;
        }

        /// <summary> Sorts a given Festival[] from earliest to latest by the dates of the festivals. </summary>
        /// <param name="festivalArray"> Festival array to be sorted. </param>
        /// <returns> Returns a Festival[] sorted by FestivalDate </returns>
        public static FestivalModel[] SortDate(FestivalModel[] festivalArray)
        {
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].FestivalDate > festivalArray[i + 1].FestivalDate)
                    {
                        FestivalModel temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        public static FestivalModel[] SortAvailability(FestivalModel[] festivalArray)
        {
            for (int j = festivalArray.Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (AvailabilityAsInt(festivalArray[i].CheckAvailability()) > AvailabilityAsInt(festivalArray[i + 1].CheckAvailability()))
                    {
                        FestivalModel temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        private static int AvailabilityAsInt(string AvailabilityString)
        {
            if (AvailabilityString == "Tickets available")
            {
                return 0;
            }
            else if (AvailabilityString == "No tickets available")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}