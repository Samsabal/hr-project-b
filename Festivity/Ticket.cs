using Newtonsoft.Json;
using System.Collections.Generic;

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

    }

    class JSONTicketList
    {
        [JsonProperty("tickets")]
        public List<Ticket> tickets { get; set; }
    }
}
