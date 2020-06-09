using Festivity.JSON;
using Newtonsoft.Json;
using System.IO;

namespace Festivity
{
    /// <summary>
    /// Static class containing the functionality for reading from and writing to our JSON files.
    /// </summary>
    internal static class JSONFunctionality
    {
        private static readonly string PathFestival = CreateFestivalDatabase.Check();
        private static readonly string PathUser = CreateUserDatabase.Check();
        private static readonly string PathTicket = CreateTicketDatabase.Check();
        private static readonly string PathTransaction = CreateTransactionDatabase.Check();

        /// <summary> Gets the festivals from our Festival database </summary>
        /// <returns> Returns a JSONFestivalList containing all Festivals in the Festival database </returns>
        public static JSONFestivalList GetFestivals()
        {
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PathFestival));
            return Festivals;
        }

        /// <summary> Writes the given JSONFestivalList to the Festival database </summary>
        /// <param name="festivals">
        /// The JSONFestivalList that needs to be written to the Festival database
        /// </param>
        public static void WriteFestivals(JSONFestivalList festivals)
        {
            string jsonfestival = JsonConvert.SerializeObject(festivals, Formatting.Indented);
            File.WriteAllText(PathFestival, jsonfestival);
        }

        /// <summary> Gets the users from our User database </summary>
        /// <returns> Returns a JSONUserList containing all users in the User database </returns>
        public static JSONUserList GetUserList()
        {
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));
            return users;
        }

        /// <summary> Writes the given JSONUserList to the User database </summary>
        /// <param name="users"> The JSONUserList that needs to be written to the User database </param>
        public static void WriteToUserList(JSONUserList users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(PathUser, json);
        }

        /// <summary> Writes the given UserModel to the User database </summary>
        /// <param name="user"> The UserModel that needs to be written to the User database </param>
        public static void WriteUser(UserModel user)
        {
            JSONUserList users = GetUserList();
            users.Users.Add(user);
            WriteToUserList(users);
        }

        /// <summary> Gets the tickets from our Ticket database </summary>
        /// <returns> Returns a JSONTicketList containing all tickets in the Ticket Database </returns>
        public static JSONTicketList GetTickets()
        {
            JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PathTicket));
            return tickets;
        }

        /// <summary> Writes the given JSONTicketList to the Ticket database </summary>
        /// <param name="tickets"> The JSONTicketList that needs to be written to the Ticket database </param>
        public static void WriteTickets(JSONTicketList tickets)
        {
            string json = JsonConvert.SerializeObject(tickets, Formatting.Indented);
            File.WriteAllText(PathTicket, json);
        }

        /// <summary> Gets the transactions from our Transaction database </summary>
        /// <returns>
        /// Returns a JSONTransactionList containing all transactions in the Transaction Database
        /// </returns>
        public static JSONTransactionList GetTransactions()
        {
            JSONTransactionList transactions = JsonConvert.DeserializeObject<JSONTransactionList>(File.ReadAllText(PathTransaction));
            return transactions;
        }

        /// <summary> Writes the given JSONTransactionList to the Transaction database </summary>
        /// <param name="transactions">
        /// The JSONTransactionList that needs to be written to the Transaction database
        /// </param>
        public static void WriteTransactions(JSONTransactionList transactions)
        {
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(PathTransaction, json);
        }

        /// <summary> Generates a new UserID based on the amount of users in the User database </summary>
        /// <returns> Returns a new UserID </returns>
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

        public static void UpdateTicket(Ticket ticket)
        {
            JSONTicketList tickets = GetTickets();
            for (int i = 0; i < tickets.Tickets.Count; i++)
            {
                if (tickets.Tickets[i].TicketID == ticket.TicketID)
                {
                    tickets.Tickets[i] = ticket;
                    break;
                }
            }
            WriteTickets(tickets);
        }

        public static void UpdateFestival(FestivalModel festival)
        {
            JSONFestivalList festivals = GetFestivals();
            for (int i = 0; i < festivals.Festivals.Count; i++)
            {
                if (festivals.Festivals[i].FestivalID == festival.FestivalID)
                {
                    festivals.Festivals[i] = festival;
                    break;
                }
            }
            WriteFestivals(festivals);
        }
    }
}