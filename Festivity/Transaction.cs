using Newtonsoft.Json;
using System.Collections.Generic;

namespace Festivity
{
    internal class Transaction
    {
        [JsonProperty("transactionID")]
        public int TransactionID { get; set; }

        [JsonProperty("festivalID")]
        public int FestivalID { get; set; }

        [JsonProperty("ticketID")]
        public int TicketID { get; set; }

        [JsonProperty("buyerID")]
        public int BuyerID { get; set; }

        [JsonProperty("ticketAmount")]
        public int TicketAmount { get; set; }

        [JsonProperty("orderDate")]
        public string OrderDate { get; set; }
    }

    internal class JSONTransactionList
    {
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}