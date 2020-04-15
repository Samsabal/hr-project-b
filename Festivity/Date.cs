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
        public int year { get; set; }

        public string to_string()
        {
            if (day == -1 || month == -1 || year == -1)
            {
                return "";
            }
            string result = day + "/" + month + "/" + year;
            return result;
        }
    }
}
