using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TransactionReader
    {
        public static int TicketAmountInput()
        {
            int userInput;
            Console.WriteLine("How many tickets would you like to buy?");

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

        public static void PaymentOptionInput()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Choose your payment method:");
                MenuFunction.Menu(new string[] { "iDEAL", "Paypal", "Creditcard", "Cancel Order" });
            }
        }

        public static bool ConfirmTransactionInput()
        {
            bool response = false;
            ConsoleKey input;
            do
            {
                Console.WriteLine("Confirm Order? [y/n]");
                input = Console.ReadKey(true).Key;
            } while (input != ConsoleKey.Y && input != ConsoleKey.N);
            if (input == ConsoleKey.Y)
            {
                response = true;
                TransactionReader.PaymentOptionInput();
                // Go to payment option
            }
            if (input == ConsoleKey.N)
            {
                response = false;
                Console.Clear();
                // Go back to main menu
            }
            Console.Clear();
            return response;
        }
    }
}
