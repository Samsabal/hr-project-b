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

    }
}
