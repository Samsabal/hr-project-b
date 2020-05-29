using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class Transaction
    {
        [JsonProperty("transactionID")]
        public int transactionID { get; set; }
        [JsonProperty("festivalID")]
        public int festivalID { get; set; }
        [JsonProperty("ticketID")]
        public int ticketID { get; set; }
        [JsonProperty("buyerID")]
        public int buyerID { get; set; }
        [JsonProperty("ticketAmount")]
        public int ticketAmount { get; set; }
        [JsonProperty("orderDate")]
        public string orderDate { get; set; }
    }

    class JSONTransactionList
    {
        [JsonProperty("transactions")]
        public List<Transaction> transactions { get; set; }
    }
}
