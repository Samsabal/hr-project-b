﻿using System.Collections.Generic;
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
        public Date festivalDate { get; set; }
        [JsonProperty("festivalStartingTime")]
        public string festivalStartingTime { get; set; }
        [JsonProperty("festivalEndTime")]
        public string festivalEndTime { get; set; }
        [JsonProperty("festivalLocationCountry")]
        public Address festivalLocation { get; set; }
        [JsonProperty("festivalLocationCity")]
        public string festivalDescription { get; set; }
        [JsonProperty("festivalAgeRestriction")]
        public int festivalAgeRestriction { get; set; }
        [JsonProperty("festivalGenre")]
        public string festivalGenre { get; set; }
    }

    class JSONFestivalList
    {
        [JsonProperty("festivals")]
        public List<Festival> festivals { get; set; }
    }
}
