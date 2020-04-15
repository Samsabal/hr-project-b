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
                    if (festivalArray[i].Name.CompareTo(festivalArray[i + 1].Name) > 0)
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
                    if (festivalArray[i].Date.year > festivalArray[i + 1].Date.year)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                    else if (festivalArray[i].Date.year == festivalArray[i + 1].Date.year &&
                        festivalArray[i].Date.month > festivalArray[i + 1].Date.month)
                    {
                        Festival temp = festivalArray[i];
                        festivalArray[i] = festivalArray[i + 1];
                        festivalArray[i + 1] = temp;
                    }
                    else if (festivalArray[i].Date.year == festivalArray[i + 1].Date.year &&
                        festivalArray[i].Date.month == festivalArray[i + 1].Date.month &&
                        festivalArray[i].Date.day > festivalArray[i + 1].Date.day)
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
                if (festivalArray[i].Name.ToLower().Contains(searchText.ToLower()))
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
                Id = -1,
                Name = null,
                Location = {
                    country = null,
                    city = null,
                    zipCode = null,
                    streetName = null,
                    streetNumber = null
                },
                Date = {
                    day = -1,
                    month = -1,
                    year = -1,
                },
                Description = null,
            };

            for (int i = count; i < resultArray.Length; i++)
            {
                resultArray[i] = emptyFestival;
            }

            return resultArray;
        }
    }
}
