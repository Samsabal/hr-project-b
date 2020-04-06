using Newtonsoft.Json;

namespace Festivity
{
    class Date
    {
        [JsonProperty("Day")]
        private int day;
        [JsonProperty("Month")]
        private int month;
        [JsonProperty("Year")]
        private int year;

        public int Day { get => day;}
        public int Month { get => month;}
        public int Year { get => year;}

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }


        public string to_string()
        {
            string result = day + "/" + month + "/" + year;
            return result;
        }
    }
}
