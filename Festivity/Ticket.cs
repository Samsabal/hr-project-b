﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class Ticket
    {
        [JsonProperty("festivalId")]
        public int FestivalID { get; set; }
        [JsonProperty("ticketId")]
        public int TicketID { get; set; }
        [JsonProperty("ticketName")]
        public string TicketName { get; set; }
        [JsonProperty("ticketDescription")]
        public string TicketDescription { get; set; }
        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }
        [JsonProperty("maxTickets")]
        public int MaxTickets { get; set; }
        [JsonProperty("maxTicketsPerPerson")]
        public int MaxTicketsPerPerson { get; set; }
    }

    class JSONTicketList
    {
        [JsonProperty("tickets")]
        public List<Ticket> Tickets { get; set; }
    }
}
