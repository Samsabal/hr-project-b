using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Festivity
{
    class TicketBuy
    {
        public static int ticketListLength;
        public static int selectedTicket;
        public static Ticket[] ticketArray;
        static int ticketAmount;

        static string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
        static JSONFestivalList festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

        static string PATH_TICKET = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TicketDatabase.json");
        static JSONTicketList tickets = JsonConvert.DeserializeObject<JSONTicketList>(File.ReadAllText(PATH_TICKET));

        static string PATH_TRANSACTION = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"TransactionDatabase.json");
        static JSONTransactionList transactions = JsonConvert.DeserializeObject<JSONTransactionList>(File.ReadAllText(PATH_TRANSACTION));

        public static void ticket_buy(int festivalId)
        {
            List<int> ticketList = new List<int>();
            
            // Gets all Tickets related to the current Festival
            foreach (var ticket in tickets.tickets)
            {
                foreach (var festival in festivals.festivals)
                {
                    if (festivalId == festival.festivalId)
                    {
                        ticketList.Add(ticket.ticketId);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
            }

            int[] ticketCount = ticketList.ToArray();
            ticketListLength = ticketCount.Length;

            MenuFunction.option = 0;

            List<string> menuOptionsList = new List<string>();
            List<Ticket> ticketArrayList = new List<Ticket>();

            foreach (var ticketId in ticketList)
            {
                foreach (var ticket in tickets.tickets)
                {
                    if (ticket.ticketId == ticketId)
                    {
                        ticketArrayList.Add(ticket);
                        menuOptionsList.Add("Buy Ticket:" + ticketId );
                    }
                }

            }
            menuOptionsList.Add("Return to Festival Page");
            menuOptionsList.Add("Exit to Main Menu");

            string[] menuOptions = menuOptionsList.ToArray();
            ticketArray = ticketArrayList.ToArray();

            while (true)
            {
                string line = "----------------------------------------------------------------------";
                // Displays the Tickets for the current Festival
                foreach (var ticketId in ticketList)
                {
                    foreach (var ticket in tickets.tickets)
                    {
                        if (ticket.ticketId == ticketId)
                        {
                            Console.WriteLine(ticket.ticketName);
                            Console.WriteLine("Description: " + ticket.ticketDescription);
                            Console.WriteLine("Price: " + ticket.ticketPrice + " euros");
                            Console.WriteLine(line);
                        }
                    }
                }
                MenuFunction.menu(menuOptions, null, ticketArray);
            }
        }

        public static void ticket_buy_selected(int ticket)
        {
            Console.Clear();
            Console.WriteLine("Would you like to buy this ticket? [y/n]");
            ConsoleKey response = Console.ReadKey(true).Key;
            if (response == ConsoleKey.Y)
            {
                Console.WriteLine("How many tickets would you like to buy?");
                ticketAmount = ticket_amount();
                Console.WriteLine("Ordered Succesfully!");
                Thread.Sleep(2000);
                write_to_database();

            }

            Console.Clear();
            void write_to_database()
            {
                DateTime now = DateTime.Now;
                string timeStamp = "" + now;

                Transaction transaction = new Transaction
                {
                    transactionID = transaction_id(transactions),
                    festivalID = (int)CatalogPage.selectedFestival,
                    ticketID = ticket,
                    buyerID = (int)UserLoginPage.currentUserId,
                    ticketAmount = ticketAmount,
                    orderDate = timeStamp
                };

                transactions.transactions.Add(transaction);
                string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                File.WriteAllText(PATH_TRANSACTION, json);
            }

            int transaction_id(JSONTransactionList transactions)
            {
                int transactionID;
                if (transactions.transactions.Count == 0)
                {
                    transactionID = 1;
                }
                else
                {
                    int item = transactions.transactions[transactions.transactions.Count - 1].transactionID;
                    transactionID = item + 1;
                };

                return transactionID;
            }

            int ticket_amount()
            {
                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid number");
                    Console.WriteLine("Enter the number and press <Enter>: ");
                }
                if (userInput > 0 && userInput <= 10)
                {
                    return userInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid number");
                    Console.WriteLine("Enter the number and press <Enter>: ");
                    return ticket_amount();
                }
            }
        }
    }
}
