using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    public class Festival
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
        [JsonProperty("festivalLocation")]
        public Address festivalLocation { get; set; }
        [JsonProperty("festivalDecription")]
        public string festivalDescription { get; set; }
        [JsonProperty("festivalAgeRestriction")]
        public int festivalAgeRestriction { get; set; }
        [JsonProperty("festivalGenre")]
        public string festivalGenre { get; set; }


        public static Festival[] festival_remove_padding(Festival[] festivals)
        {
            int count = 0;
            for (int i = 0; i < festivals.Length; i++)
            {
                if (festivals[i].festivalId != -1)
                {
                    count++;
                }
            }

            Festival[] resultArray = new Festival[count];
            for (int i = 0; i < count; i++)
            {
                resultArray[i] = festivals[i];
            }

            return resultArray;
        }
    }


    class JSONFestivalList
    {
        [JsonProperty("festivals")]
        public List<Festival> festivals { get; set; }
    }
}
