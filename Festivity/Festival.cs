using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class Festival
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Location")]
        public string Location { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
    }

    class JSONFestivalList
    {
        [JsonProperty("Festivals")]
        public List<Festival> Festivals { get; set; }
    }
}
