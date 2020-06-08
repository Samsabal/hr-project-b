﻿using Festivity.FestivalRegister;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Festivity
{
    public class Ticket
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

        public void EditName()
        {
            do { TicketName = TicketModifier.InputLoop("Fill in the new ticket name: "); }
            while (!RegexUtils.IsValidName(TicketName));
        }

        public void EditDescription()
        {
            do { TicketDescription = TicketModifier.InputLoop("Fill in the new ticket description: "); }
            while (!RegexUtils.IsValidDescription(TicketDescription));
        }

        public void EditPrice()
        {
            do { TicketPrice = double.Parse(TicketModifier.InputLoop("Fill in the new ticket price: ")); }
            while (!RegexUtils.IsValidPrice(TicketPrice.ToString()));
        }

        public void EditMaxTickets()
        {
            do { MaxTickets = int.Parse(TicketModifier.InputLoop("Fill in the maximum amount of available tikets of this ticket type: ")); }
            while (!RegexUtils.IsValidMaxTickets(MaxTickets.ToString()));
        }

        public void EditMaxTicketsPerPerson()
        {
            do { MaxTicketsPerPerson = int.Parse(TicketModifier.InputLoop("Fill in the maximum amount of tickets a single person may buy: ")); }
            while (!RegexUtils.IsValidMaxTicketsPerPerson(MaxTicketsPerPerson.ToString()));
        }

    }

    internal class JSONTicketList
    {
        [JsonProperty("tickets")]
        public List<Ticket> Tickets { get; set; }
    }
}