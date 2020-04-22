using Newtonsoft.Json;

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
