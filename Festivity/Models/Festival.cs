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

        /// <summary>
        /// This method gives a string representing the current status of the Festival to be displayed on the CatalogPage.
        /// </summary>
        /// <returns>
        /// Returns a string containing "Tickets available" or "No tickets available" if the festival hasn't happened yet, and returns "This festival has ended" if it has ended.
        /// </returns>
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

        /// <summary>
        /// This method gives a string representing the current status of the Festival to be displayed on the TicketTable.
        /// </summary>
        /// <returns>
        /// Returns a string containing the date status of the Festival if no FestivalStatus has been set, otherwise returns FestivalStatus.
        /// </returns>
        public string CheckStatusTicketTable()
        {
            if (FestivalStatus == null)
            {
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

        /// <summary>
        /// This method checks if the Festival has any tickets available for sale.
        /// </summary>
        /// <returns>
        /// Returns true if there are tickets available, returns false if there aren't
        /// </returns>
        private bool TicketsLeft()
        {
            foreach (Ticket t in this.GetTickets())
            {
                if (FestivalPage.TicketsLeft(t.TicketID, t.MaxTickets) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method gets a list of tickets associated with the current Festival.
        /// </summary>
        /// <returns>\
        /// Returns a List<Ticket> containing all tickets that match the FestivalID
        /// </returns>
        private List<Ticket> GetTickets()
        {
            JSONTicketList tickets = JSONFunctionality.GetTickets();
            List<Ticket> resultList = new List<Ticket>();

            foreach (Ticket t in tickets.Tickets)
            {
                if (t.FestivalID == this.FestivalID)
                {
                    resultList.Add(t);
                }
            }
            return resultList;
        }
    }

    /// <summary>
    /// JSONFestivalList class to add JSON List functionality to the Festival class
    /// </summary>
    internal class JSONFestivalList
    {
        [JsonProperty("festivals")]
        public List<Festival> Festivals { get; set; }
    }
}