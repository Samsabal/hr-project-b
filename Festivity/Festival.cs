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
        public Address Location { get; set; }
        [JsonProperty("Date")]
        public Date Date { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }

    }

    class JSONFestivalList
    {
        [JsonProperty("Festivals")]
        public List<Festival> Festivals { get; set; }
    }
}
