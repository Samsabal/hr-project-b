using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class Festival
    {
        [JsonProperty("festivalId")]
        public int festivalId { get; set; }
        [JsonProperty("festivalName")]
        public string festivalName { get; set; }
        [JsonProperty("festivalDate")]
        public string festivalDate { get; set; }
        [JsonProperty("festivalStartingTime")]
        public string festivalStartingTime { get; set; }
        [JsonProperty("festivalEndTime")]
        public string festivalEndTime { get; set; }
        [JsonProperty("festivalLocationCountry")]
        public string festivalLocationCountry { get; set; }
        [JsonProperty("festivalLocationCity")]
        public string festivalLocationCity { get; set; }
        [JsonProperty("festivalLocationStreet")]
        public string festivalLocationStreet { get; set; }
        [JsonProperty("festivalLocationHouseNumber")]
        public string festivalLocationHouseNumber { get; set; }
        [JsonProperty("festivalDescription")]
        public string festivalDescription { get; set; }
        [JsonProperty("festivalAgeRestriction")]
        public string festivalAgeRestriction { get; set; }
        [JsonProperty("festivalGenre")]
        public string festivalGenre { get; set; }
        

        public Festival(int Id, string Name, string Date, string StartTime, string EndTime, string Country, string City, string Street, string HouseNumber, string Description, string AgeLimit, string Genre)
        {
            this.festivalId = Id;
            this.festivalName = Name;
            this.festivalDate = Date;
            this.festivalStartingTime = StartTime;
            this.festivalEndTime = EndTime;
            this.festivalLocationCountry = Country;
            this.festivalLocationCity = City;
            this.festivalLocationStreet = Street;
            this.festivalLocationHouseNumber = HouseNumber;
            this.festivalDescription = Description;
            this.festivalAgeRestriction = AgeLimit;
            this.festivalGenre = Genre;
        }
    }

    class JSONFestivalList
    {
        [JsonProperty("Festivals")]
        public List<Festival> Festivals { get; set; }
    }
}
