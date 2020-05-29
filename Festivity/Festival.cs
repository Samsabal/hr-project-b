using System;
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
        [JsonProperty("festivalDescription")]
        public string festivalDescription { get; set; }
        [JsonProperty("festivalAgeRestriction")]
        public int festivalAgeRestriction { get; set; }
        [JsonProperty("festivalGenre")]
        public string festivalGenre { get; set; }
        [JsonProperty("festivalCancelTime")]
        public int festivalCancelTime { get; set; }
        [JsonProperty("festivalStatus")]
        public string festivalStatus { get; set; }
        [JsonProperty("festivalOrganisorId")]
        public int festivalOrganiserId { get; set; }


        public string check_status()
        {
            if (this == null || this.festivalId == -1)
            {
                return "";
            }
            else if (this.festivalStatus == "Festival aborted")
            {
                return "Festival aborted";
            }
            else if (this.festivalStatus == "Festival changed")
            {
                return "Festival changed";
            }
            else
            {
                int currentDate = int.Parse(DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString() + DateTime.UtcNow.Day.ToString());
                int currentTime = int.Parse(DateTime.UtcNow.Hour.ToString() + DateTime.UtcNow.Minute.ToString());
                if (this.festivalDate.to_identifier() < currentDate)
                {
                    return "This festival has ended";
                }
                else if (this.festivalDate.to_identifier() == currentDate)
                {
                    if (int.Parse(this.festivalEndTime) < currentTime)
                    {
                        return "This festival has ended";
                    }
                    else if (currentTime < int.Parse(this.festivalStartingTime))
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
