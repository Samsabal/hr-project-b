using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class FestivalRegisterClass
    {
        [JsonProperty("festivalId")]
        public int FestivalId { get; set; }

        [JsonProperty("festivalName")]
        public string FestivalName { get; set; }

        [JsonProperty("festivalDate")]
        public string FestivalDate { get; set; }

        [JsonProperty("festivalStartingTime")]
        public string FestivalStartingTime { get; set; }

        [JsonProperty("festivalEndTime")]
        public string FestivalEndTime { get; set; }

        [JsonProperty("festivalLocationCountry")]
        public string FestivalLocationCountry { get; set; }

        [JsonProperty("festivalLocationCity")]
        public string FestivalLocationCity { get; set; }

        [JsonProperty("festivalLocationStreet")]
        public string FestivalLocationStreet { get; set; }

        [JsonProperty("festivalLocationHouseNumber")]
        public string FestivalLocationHouseNumber { get; set; }

        [JsonProperty("festivalDescription")]
        public string FestivalDescription { get; set; }

        [JsonProperty("festivalAgeRestriction")]
        public string FestivalAgeRestriction { get; set; }

        [JsonProperty("festivalGenre")]
        public string FestivalGenre { get; set; }

    }

    class JSONFestivalRegisterList
    {
        [JsonProperty("festivals")]
        public List<FestivalRegisterClass> festivals { get; set; }
    }
}
