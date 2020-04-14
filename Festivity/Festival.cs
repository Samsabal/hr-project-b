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
        [JsonProperty("Address")]
        public string Address { get; set; }
        [JsonProperty("Date")]
        public Date Date { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }


        public Festival(int Id, string Name, string Description, string Location, Date Date, string Time)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Location = Location;
            this.Date = Date;
            this.Time = Time;
        }
    }

    class JSONFestivalList
    {
        [JsonProperty("Festivals")]
        public List<Festival> Festivals { get; set; }
    }
}
