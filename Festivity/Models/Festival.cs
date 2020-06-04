using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Festivity
{
    public class Festival
    {
        [JsonProperty("festivalId")]
        public int FestivalID { get; set; }

        [JsonProperty("festivalName")]
        public string FestivalName { get; set; }

        [JsonProperty("dateTimeField", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\d\.\d{3}Z$")]
        public DateTime FestivalDate { get; set; }

        [JsonProperty("festivalStartingTime")]
        public string FestivalStartingTime { get; set; }

        [JsonProperty("festivalEndTime")]
        public string FestivalEndTime { get; set; }

        [JsonProperty("festivalLocation")]
        public Address FestivalLocation { get; set; }

        [JsonProperty("festivalDescription")]
        public string FestivalDescription { get; set; }

        [JsonProperty("festivalAgeRestriction")]
        public int FestivalAgeRestriction { get; set; }

        [JsonProperty("festivalGenre")]
        public string FestivalGenre { get; set; }

        [JsonProperty("festivalCancelTime")]
        public int FestivalCancelTime { get; set; }

        [JsonProperty("festivalStatus")]
        public string FestivalStatus { get; set; }

        [JsonProperty("festivalOrganiserID")]
        public int FestivalOrganiserID { get; set; }

        public string CheckStatus()
        {
            if (this == null || this.FestivalID == -1)
            {
                return "";
            }
            else if (this.FestivalStatus == "Festival aborted")
            {
                return "Festival aborted";
            }
            else if (this.FestivalStatus == "Festival changed")
            {
                return "Festival changed";
            }
            else
            {
                int currentTime = int.Parse(DateTime.UtcNow.Hour.ToString() + DateTime.UtcNow.Minute.ToString());
                if (this.FestivalDate < DateTime.Today)
                {
                    return "This festival has ended";
                }
                else if (this.FestivalDate == DateTime.Today)
                {
                    if (int.Parse(this.FestivalEndTime) < currentTime)
                    {
                        return "This festival has ended";
                    }
                    else if (currentTime < int.Parse(this.FestivalStartingTime))
                    {
                        return "Tickets available";
                    }
                    else
                    {
                        return "Ongoing";
                    }
                }
                else
                {
                    return "Tickets available";
                }
            }
        }

        public static Festival[] FestivalRemovePadding(Festival[] festivals)
        {
            int count = 0;
            for (int i = 0; i < festivals.Length; i++)
            {
                if (festivals[i].FestivalID != -1)
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

    internal class JSONFestivalList
    {
        [JsonProperty("festivals")]
        public List<Festival> Festivals { get; set; }
    }
}