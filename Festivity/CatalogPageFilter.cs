namespace Festivity
{
    class CatalogPageFilter
    {
        // Receives a Festival array and sorts it in alphabetical order by name
        public static Festival[] sort_name(Festival[] festivalArray, int arraySize)
        {
            for (int j = arraySize - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].festivalName.CompareTo(festivalArray[i + 1].festivalName) > 0)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        // Receives a Festival array and sorts it in ascending order by date
        public static Festival[] sort_date(Festival[] festivalArray, int arraySize)
        {
            for (int j = arraySize - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (festivalArray[i].festivalDate.year > festivalArray[i + 1].festivalDate.year)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                    else if (festivalArray[i].festivalDate.year == festivalArray[i + 1].festivalDate.year &&
                        festivalArray[i].festivalDate.month > festivalArray[i + 1].festivalDate.month)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                    else if (festivalArray[i].festivalDate.year == festivalArray[i + 1].festivalDate.year &&
                        festivalArray[i].festivalDate.month == festivalArray[i + 1].festivalDate.month &&
                        festivalArray[i].festivalDate.day > festivalArray[i + 1].festivalDate.day)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                }
            }
            return festivalArray;
        }

        public static Festival[] filter_name(Festival[] festivalArray, int arraySize, string searchText)
        {
            Festival[] tempArray = new Festival[arraySize];
            int count = 0;

            for (int i = 0; i < arraySize; i++)
            {
                if (festivalArray[i].festivalName.ToLower().Contains(searchText.ToLower()))
                {
                    tempArray[count] = festivalArray[i];
                    count++;
                }
            }
            int extraSpace = 5 - (count % 5);
            Festival[] resultArray = new Festival[count + extraSpace + 1];

            for (int i = 0; i < count; i++)
            {
                resultArray[i] = tempArray[i];
            }

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

            for (int i = count; i < resultArray.Length; i++)
            {
                resultArray[i] = emptyFestival;
            }

            return resultArray;
        }
    }
}
