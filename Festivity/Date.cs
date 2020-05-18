using Newtonsoft.Json;
using System.Collections.Generic;

namespace Festivity
{
    public class Date
    {
        [JsonProperty("day")]
        public int day { get; set; }
        [JsonProperty("month")]
        public int month { get; set; }
        [JsonProperty("year")]
        public int year { get; set; }

        public static bool check_validity(Date date)
        {
            int[] months31days = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] months30days = new int[] { 4, 6, 9, 11};
            for(int i = 0; i < months31days.Length; i++)
            {
                if(date.month == months31days[i])
                {
                    return 0 < date.day && date.day <= 31;
                }
            }
            for(int i = 0; i<months30days.Length; i++)
            {
                if (date.month == months30days[i])
                {
                    return 0 < date.day && date.day <= 30;
                }
            }
            if(date.month == 2)
            {
                return 0 < date.day && date.day <= 29;
            }
            return false;
        } 


        public int to_identifier()
        {
            string result = year.ToString() + month.ToString() + day.ToString();
            return int.Parse(result);
        }

        public string to_string()
        {
            if (day == -1 || month == -1 || year == -1)
            {
                return "";
            }
            string result = day.ToString("D2") + "/" + month.ToString("D2") + "/" + year.ToString("D4");
            return result;
        }
    }
}
