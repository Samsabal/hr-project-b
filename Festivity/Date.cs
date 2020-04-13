using Newtonsoft.Json;

namespace Festivity
{
    class Date
    {
        [JsonProperty("day")]
        public int day { get; set; }
        [JsonProperty("month")]
        public int month { get; set; }
        [JsonProperty("year")]
        public int year { get;  set; }


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
