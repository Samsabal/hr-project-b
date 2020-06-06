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

        [JsonProperty("festivalDate")]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\d\.\d{3}Z$")]
        public DateTime FestivalDate { get; set; }

        [JsonProperty("festivalStartingTime")]
        public DateTime FestivalStartingTime { get; set; }

        [JsonProperty("festivalEndTime")]
        public DateTime FestivalEndTime { get; set; }

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

        public bool IsRefundable()
        {
            return (DateTime.Now.AddDays(FestivalCancelTime * 7) < FestivalDate);
        }

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
                if (this.FestivalEndTime < DateTime.Now)
                {
                    return "This festival has ended";
                }
                else if (DateTime.Now < this.FestivalEndTime && this.FestivalStartingTime < DateTime.Now)
                {
                    return "This festival is ongoing";
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