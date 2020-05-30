using Newtonsoft.Json;
using System.Collections.Generic;

namespace Festivity
{
    public class Date
    {
        [JsonProperty("day")]
        public int Day { get; set; }
        [JsonProperty("month")]
        public int Month { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }

        public static bool CheckValidity(Date date)
        {
            int[] months31Days = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] months30Days = new int[] { 4, 6, 9, 11};
            for(int i = 0; i < months31Days.Length; i++)
            {
                if(date.Month == months31Days[i])
                {
                    return 0 < date.Day && date.Day <= 31;
                }
            }
            for(int i = 0; i<months30Days.Length; i++)
            {
                if (date.Month == months30Days[i])
                {
                    return 0 < date.Day && date.Day <= 30;
                }
            }
            if(date.Month == 2)
            {
                return 0 < date.Day && date.Day <= 29;
            }
            return false;
        } 


        public int ToIdentifier()
        {
            string result = Year.ToString("D4") + Month.ToString("D2") + Day.ToString("D2");
            return int.Parse(result);
        }

        public override string ToString()
        {
            if (Day == -1 || Month == -1 || Year == -1)
            {
                return "";
            }
            string result = Day.ToString("D2") + "/" + Month.ToString("D2") + "/" + Year.ToString("D4");
            return result;
        }
    }
}
