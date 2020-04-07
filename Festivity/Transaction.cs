using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class Transaction
    {
        [JsonProperty("festivalID")]
        public int festivalID { get; set; }
        [JsonProperty("ticketID")]
        public int ticketID { get; set; }
        [JsonProperty("buyerID")]
        public int buyerID { get; set; }
        [JsonProperty("ticketNumber")]
        public int ticketNumber { get; set; }
        [JsonProperty("orderNumber")]
        public int orderNumber { get; set; }
    }

    class JSONTransactionList
    {
        [JsonProperty("transactions")]
        public List<Transaction> transactions { get; set; }
    }
}
