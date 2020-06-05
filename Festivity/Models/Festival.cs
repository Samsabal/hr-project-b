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

        public string CheckStatusCatalog()
        {
            if (this.FestivalEndTime < DateTime.Now)
            {
                return "This festival has ended";
            }

            if (TicketsLeft())
            {
                return "Tickets available";
            }
            else
            {
                return "No tickets available";
            }
        }

        public string CheckStatusTicketTable()
        {
            if (FestivalStatus == null) {
                if (FestivalEndTime < DateTime.Now)
                {
                    return "This festival has ended";
                }
                else if (FestivalStartingTime < DateTime.Now && FestivalEndTime < DateTime.Now)
                {
                    return "This festival is ongoing";
                }
                else
                {
                    return "This festival is upcoming";
                }
            }
            else
            {
                return FestivalStatus;
            }
        }
        

        private bool TicketsLeft()
        {
            foreach(Ticket t in this.GetTickets())
            {
                if (FestivalPage.TicketsLeft(t.TicketID, t.MaxTickets) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Ticket> GetTickets()
        {
            JSONTicketList tickets = JSONFunctionality.GetTickets();
            List<Ticket> resultList = new List<Ticket>();

            foreach(Ticket t in tickets.Tickets)
            {
                if (t.FestivalID == this.FestivalID) {
                    resultList.Add(t);
                }
            }
            return resultList;
        }
    }

    internal class JSONFestivalList
    {
        [JsonProperty("festivals")]
        public List<Festival> Festivals { get; set; }
    }
}