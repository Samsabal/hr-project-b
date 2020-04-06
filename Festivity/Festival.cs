using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class Festival
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("location")]
        public string location { get; set; }
        [JsonProperty("address")]
        public string address { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("time")]
        public string time { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }

    class JSONFestivalList
    {
        [JsonProperty("Festivals")]
        public List<Festival> Festivals { get; set; }
    }
}
