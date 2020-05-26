using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class Ticket
    {
        [JsonProperty("festivalId")]
        public int festivalId { get; set; }

        [JsonProperty("ticketId")]
        public int ticketId { get; set; }

        [JsonProperty("ticketName")]
        public string ticketName { get; set; }

        [JsonProperty("ticketDescription")]
        public string ticketDescription { get; set; }

        [JsonProperty("ticketPrice")]
        public double ticketPrice { get; set; }

        [JsonProperty("maxTickets")]
        public int maxTickets { get; set; }

        [JsonProperty("maxTicketsPerPerson")]
        public int maxTicketsPerPerson { get; set; }
    }

    class JSONTicketList
    {
        [JsonProperty("tickets")]
        public List<Ticket> tickets { get; set; }
    }
}
