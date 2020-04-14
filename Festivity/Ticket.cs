using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class Ticket
    {
        [JsonProperty("festivalId")]
        public int FestivalId { get; set; }

        [JsonProperty("ticketId")]
        public int TicketId { get; set; }

        [JsonProperty("ticketName")]
        public string TicketName { get; set; }

        [JsonProperty("ticketDescription")]
        public string TicketDescription { get; set; }

        [JsonProperty("ticketPrice")]
        public string TicketPrice { get; set; }

        [JsonProperty("maxTickets")]
        public int MaxTickets { get; set; }

    }

    class JSONTicketList
    {
        [JsonProperty("tickets")]
        public List<Ticket> Tickets { get; set; }
    }
}
