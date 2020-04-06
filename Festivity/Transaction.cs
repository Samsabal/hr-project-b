using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class Transaction
    {
        [JsonProperty("FestivalID")]
        public int FestivalID { get; set; }
        [JsonProperty("TicketID")]
        public int TicketID { get; set; }
        [JsonProperty("BuyerID")]
        public int BuyerID { get; set; }
        [JsonProperty("TicketNumber")]
        public int TicketNumber { get; set; }
        [JsonProperty("OrderNumber")]
        public int OrderNumber { get; set; }
    }

    class JSONTransactionList
    {
        [JsonProperty("transactions")]
        public List<Transaction> transactions { get; set; }
    }
}