using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class TicketBuy
    {
        private static int ticketAmount;
        private static int currentFestivalId;
        private static List<Ticket> CurrentTicketList { get; set; }
        private static int indexTicket;

        private static readonly JSONTransactionList transactionList =JSONFunctionality.GetTransactions();

        private static void SetCurrentFestivalTickets(int festivalId)
        {
            CurrentTicketList = new List<Ticket>();
            
            foreach (var ticket in JSONFunctionality.GetTickets().Tickets)
            {
                if (festivalId == ticket.FestivalID)
                {
                    CurrentTicketList.Add(ticket);
                }
            }
        }

        public static void TicketShow()
        {
            currentFestivalId = CatalogPage.selectedFestival;

            SetCurrentFestivalTickets(currentFestivalId);

            MenuFunction.option = 0;

            while (true)
            {
                List<string> menuOptionsList = new List<string>();
                string line = "----------------------------------------------------------------------";

                // Displays the Tickets for the current Festival
                foreach (var ticket in CurrentTicketList)
                {
                    Console.WriteLine(ticket.TicketName);
                    Console.WriteLine("Description: " + ticket.TicketDescription);
                    Console.WriteLine("Price: " + ticket.TicketPrice + " euros");
                    Console.WriteLine(line);
                    menuOptionsList.Add("Buy Ticket:" + ticket.TicketID);
                }

                menuOptionsList.Add("Return to Festival Page");
                menuOptionsList.Add("Exit to Main Menu");
                MenuFunction.Menu(menuOptionsList.ToArray(), CurrentTicketList.ToArray());
            }
        }

        public static void TicketConfirmation(int index)
        {
            indexTicket = index;
            Console.WriteLine("How many tickets would you like to buy?");
            ticketAmount = TicketAmountInput();
            TransactionOverview(indexTicket, ticketAmount);

            ConsoleKey response;
            do
            {
                Console.WriteLine("Confirm Order? [y/n]");
                response = Console.ReadKey(true).Key;
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            if (response == ConsoleKey.Y)
            {
                PaymentOption();
            }
            if (response == ConsoleKey.N)
            {
                Console.Clear();
                TicketShow();
            }
            Console.Clear();
        }

        public static void ShowTicketBuy()
        {
            WriteToDatabase(GetSelectedTicket(indexTicket));
            Console.WriteLine("Ordered Succesfully!");
            Thread.Sleep(2000);
            Console.Clear();
            FestivalPage.ShowFestivalPage(CatalogPage.selectedFestival);
        }

        private static Ticket GetSelectedTicket(int option)
        {
            return CurrentTicketList[option];
        }

        private static void WriteToDatabase(Ticket ticket)
        {
            DateTime now = DateTime.Now;
            string timeStamp = "" + now;

            Transaction transaction = new Transaction
            {
                TransactionID = GetTransactionID(),
                FestivalID = (int)CatalogPage.selectedFestival,
                TicketID = ticket.TicketID,
                BuyerID = LoggedInAccount.GetID(),//(int)UserLoginPage.currentUserID, 
                TicketAmount = ticketAmount,
                OrderDate = timeStamp
            };

            transactionList.Transactions.Add(transaction);
            JSONFunctionality.WriteTransactions(transactionList);
        }

        private static int GetTransactionID()
        {
            int transactionID;
            if (transactionList.Transactions.Count == 0)
            {
                transactionID = 1;
            }
            else
            {
                int item = transactionList.Transactions[^1].TransactionID;
                transactionID = item + 1;
            };

            return transactionID;
        }

        private static int TicketAmountInput()
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
                return TicketAmountInput();
            }
        }

        public static int GetTicketListLength()
        {
            return CurrentTicketList.ToArray().Length;
        }

        private static void PaymentOption()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Choose your payment method:");
                MenuFunction.Menu(new string[] { "iDEAL", "Paypal", "Creditcard", "Cancel Order" });
            }
        }

        public static void TransactionOverview(int index, int amount)
        {
            Console.Clear();
            Ticket selectedTicket = GetSelectedTicket(index);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Transaction Information");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(amount + " x " + selectedTicket.TicketName);
            Console.WriteLine(selectedTicket.TicketDescription);
            Console.WriteLine("€" + selectedTicket.TicketPrice + " / Ticket");
            Console.WriteLine("Total: €" + (Convert.ToInt32(selectedTicket.TicketPrice) * amount));
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}
