using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    class TicketBuy
    {
        public static int ticketListLength;
        public static Ticket[] ticketArray;
        public static void ticket_buy(int festivalId)
        {
            JSONFestivalList festivals = JSONFunctionality.get_festivals();
            JSONTicketList tickets = JSONFunctionality.get_tickets();

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
                        menuOptionsList.Add("Order Ticket:" + ticketId );
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
            JSONTransactionList transactions = JSONFunctionality.get_transactions();

            Console.WriteLine("Would you like to buy this ticket? [y/n]");
            ConsoleKey response = Console.ReadKey(true).Key;
            if (response == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("Succesfully bought a Ticket!");
                Thread.Sleep(2000);
                write_to_database();
            }

            Console.Clear();
            void write_to_database()
            {
                JSONTransactionList transactions = JSONFunctionality.get_transactions();
                DateTime now = DateTime.Now;
                string timeStamp = "" + now;

                Transaction transaction = new Transaction
                {
                    festivalID = (int)CatalogPage.selectedFestival,
                    ticketID = ticket,
                    buyerID = (int)UserLoginPage.currentUserId,
                    ticketNumber = 1,
                    orderNumber = order_number(transactions),
                    orderDate = timeStamp
                };

                transactions.transactions.Add(transaction);
                JSONFunctionality.write_transactions(transactions);
            }

            int order_number(JSONTransactionList transactions)
            {
                int orderNumber;
                if (transactions.transactions.Count == 0)
                {
                    orderNumber = 1;
                }
                else
                {
                    int item = transactions.transactions[transactions.transactions.Count - 1].orderNumber;
                    orderNumber = item + 1;
                };

                return orderNumber;
            }
        }
    }
}
