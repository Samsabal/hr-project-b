using Newtonsoft.Json;
using System.IO;

namespace Festivity
{
    internal class JSONFunctionality
    {
        private static readonly string PathFestival = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"FestivalsDatabase.json");
        private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"UsersDatabase.json");
        private static readonly string PathTicket = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"TicketDatabase.json");
        private static readonly string PathTransaction = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"TransactionDatabase.json");

        public static JSONFestivalList GetFestivals()
        {
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PathFestival));
            return Festivals;
        }

        public static void WriteFestivals(JSONFestivalList festivals)
        {
            string jsonfestival = JsonConvert.SerializeObject(festivals, Formatting.Indented);
            File.WriteAllText(PathFestival, jsonfestival);
        }

        public static JSONUserList GetUserList()
        {
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
            return users;
        }

        public static void WriteToUserList(JSONUserList users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(PathUser, json);
        }

        public static void WriteUser(User user)
        {
            JSONUserList users = GetUserList();
            users.Users.Add(user);
            WriteToUserList(users);
        }



        public static JSONTicketList GetTickets()
        {
            JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PathTicket));
            return tickets;
        }

        public static void WriteTickets(JSONTicketList tickets)
        {
            string json = JsonConvert.SerializeObject(tickets, Formatting.Indented);
            File.WriteAllText(PathTicket, json);
        }

        public static JSONTransactionList GetTransactions()
        {
            JSONTransactionList transactions = JsonConvert.DeserializeObject<JSONTransactionList>(File.ReadAllText(PathTransaction));
            return transactions;
        }

        public static void WriteTransactions(JSONTransactionList transactions)
        {
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(PathTransaction, json);
        }

        public static int GenerateUserID()
        {
            JSONUserList userList = GetUserList();
            int accountID;
            if (userList.Users.Count == 0)
            {
                accountID = 1;
            }
            else
            {
                int item = userList.Users[userList.Users.Count - 1].AccountID;
                accountID = item + 1;
            };
            return accountID;
        }
    }
}