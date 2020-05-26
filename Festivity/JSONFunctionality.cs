using Newtonsoft.Json;
using System.IO;

namespace Festivity
{
    class JSONFunctionality
    {
        private static string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
        private static string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
        private static string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
        private static string PATH_TRANSACTION = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TransactionDatabase.json");

        public static JSONFestivalList get_festivals()
        {
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));
            return Festivals;
        }

        public static void write_festivals(JSONFestivalList festivals)
        {
            string jsonfestival = JsonConvert.SerializeObject(festivals, Formatting.Indented);
            File.WriteAllText(PATH_FESTIVAL, jsonfestival);
        }

        public static JSONUserList get_users()
        {
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));
            return users;
        }

        public static void write_users(JSONUserList users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(PATH_USER, json);
        }

        public static JSONTicketList get_tickets()
        {
            JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));
            return tickets;
        }


        public static void write_tickets(JSONTicketList tickets)
        {
            string json = JsonConvert.SerializeObject(tickets, Formatting.Indented);
            File.WriteAllText(PATH_TICKET, json);
        }

        public static JSONTransactionList get_transactions()
        {
            JSONTransactionList transactions = JsonConvert.DeserializeObject<JSONTransactionList>(File.ReadAllText(PATH_TRANSACTION));
            return transactions;
        }

        public static void write_transactions(JSONTransactionList transactions)
        {
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(PATH_TRANSACTION, json);
        }
    }
}
