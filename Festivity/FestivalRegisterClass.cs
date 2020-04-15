using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class FestivalRegisterClass
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

    }

    class JSONFestivalRegisterList
    {
        [JsonProperty("festivals")]
        public List<FestivalRegisterClass> festivals { get; set; }
    }
}
