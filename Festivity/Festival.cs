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
        [JsonProperty("ageLimit")]
        public string ageLimit { get; set; }

        public Festival(int Id, string Name, string Description, string Location, Date Date, string Time, string AgeLimit)
        {
            this.id = Id;
            this.name = Name;
            this.description = Description;
            this.location = Location;
            this.date = Date;
            this.time = Time;
            this.ageLimit = AgeLimit;
        }
    }

    class JSONFestivalList
    {
        [JsonProperty("Festivals")]
        public List<Festival> Festivals { get; set; }
    }
}
