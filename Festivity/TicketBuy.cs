using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class TicketBuy
    {
        private static int ticketAmount;
        private static int currentFestivalId;
        public static List<Ticket> currentTicketList { get; private set; }
        private static int indexTicket;

        private static JSONTicketList tickets = JSONFunctionality.get_tickets();
        private static JSONTransactionList transactions =JSONFunctionality.get_transactions();

        private static void update_current_festival_tickets(int festivalId)
        {
            currentTicketList = new List<Ticket>();
            // Gets all Tickets related to the current Festival
            foreach (var ticket in tickets.tickets)
            {
                if (festivalId == ticket.festivalId)
                {
                    currentTicketList.Add(ticket);
                }
            }
        }

        public static void ticket_show()
        {
            currentFestivalId = CatalogPage.selectedFestival;

            update_current_festival_tickets(currentFestivalId);

            MenuFunction.option = 0;

            while (true)
            {
                List<string> menuOptionsList = new List<string>();
                string line = "----------------------------------------------------------------------";

                // Displays the Tickets for the current Festival
                foreach (var ticket in currentTicketList)
                {
                    Console.WriteLine(ticket.ticketName);
                    Console.WriteLine("Description: " + ticket.ticketDescription);
                    Console.WriteLine("Price: " + ticket.ticketPrice + " euros");
                    Console.WriteLine(line);
                    menuOptionsList.Add("Buy Ticket:" + ticket.ticketId);
                }

                menuOptionsList.Add("Return to Festival Page");
                menuOptionsList.Add("Exit to Main Menu");
                MenuFunction.menu(menuOptionsList.ToArray(), currentTicketList.ToArray());
            }
        }

        public static void ticket_confirmation(int index)
        {
            indexTicket = index;
            Console.WriteLine("How many tickets would you like to buy?");
            ticketAmount = ticket_amount();
            transaction_overview(indexTicket, ticketAmount);

            ConsoleKey response;
            do
            {
                Console.WriteLine("Confirm Order? [y/n]");
                response = Console.ReadKey(true).Key;
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            if (response == ConsoleKey.Y)
            {
                payment_option();
            }
            if (response == ConsoleKey.N)
            {
                Console.Clear();
                ticket_show();
            }
            Console.Clear();
        }

        public static void ticket_buy()
        {
            write_to_database(get_selected_ticket(indexTicket));
            Console.WriteLine("Ordered Succesfully!");
            Thread.Sleep(2000);
            Console.Clear();
            FestivalPage.festival_page(CatalogPage.selectedFestival);
        }

        private static Ticket get_selected_ticket(int option)
        {
            return currentTicketList[option];
        }

        private static void write_to_database(Ticket ticket)
        {
            DateTime now = DateTime.Now;
            string timeStamp = "" + now;

            Transaction transaction = new Transaction
            {
                transactionID = transaction_id(transactions),
                festivalID = (int)CatalogPage.selectedFestival,
                ticketID = ticket.ticketId,
                buyerID = (int)UserLoginPage.currentUserId,
                ticketAmount = ticketAmount,
                orderDate = timeStamp
            };

            transactions.transactions.Add(transaction);
            JSONFunctionality.write_transactions(transactions);
        }

        private static int transaction_id(JSONTransactionList transactions)
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

        private static int ticket_amount()
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

        public static int get_ticket_list_length()
        {
            return currentTicketList.ToArray().Length;
        }

        private static void payment_option()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Choose your payment method:");
                MenuFunction.menu(new string[] { "iDEAL", "Paypal", "Creditcard", "Cancel Order" });
            }
        }

        public static void transaction_overview(int index, int amount)
        {
            Console.Clear();
            Ticket selectedTicket = get_selected_ticket(index);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Transaction Information");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(amount + " x " + selectedTicket.ticketName);
            Console.WriteLine(selectedTicket.ticketDescription);
            Console.WriteLine("€" + selectedTicket.ticketPrice + " / Ticket");
            Console.WriteLine("Total: €" + (Convert.ToInt32(selectedTicket.ticketPrice) * amount));
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}