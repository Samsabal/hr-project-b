using System;

namespace Festivity.Transaction
{
    class InputReader
    {
        public static int TicketAmount()
        {
            string userInput;
            Console.WriteLine("How many tickets would you like to buy? ");
            do { userInput = InputLoopString(); }
            while (!NumberCheck(userInput, 1, 10));
            return Int32.Parse(userInput);
        }

        public static void PaymentOption()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Choose your payment method:");
                MenuFunction.Menu(new string[] { "iDEAL", "Paypal", "Creditcard", "Cancel Order" });
            }
        }

        public static bool ConfirmTransaction()
        {
            ConsoleKey input;
            Console.WriteLine("Confirm Order? [y/n]");
            do { input = InputLoopKey();}
            while (YesOrNoCheck(input) );

            Console.Clear();
            return input == ConsoleKey.Y;
        }

        private static bool NumberCheck(string value, int min, int max)
        {
            if (Int32.TryParse(value, out int result))
            {
                if (result >= min && result <= max)
                {
                    return true;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input, please  try again");
                Console.ResetColor();
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input, please  try again");
            Console.ResetColor();
            return false;
        }

        private static bool YesOrNoCheck(ConsoleKey input)
        {
            if (input != ConsoleKey.Y && input != ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input, please type 'y' or 'n'");
                Console.ResetColor();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string InputLoopString()
        {
            string userInput;
            userInput = Console.ReadLine();
            return userInput;
        }

        private static ConsoleKey InputLoopKey()
        {
            ConsoleKey userInput;
            userInput = Console.ReadKey(true).Key;
            return userInput;
        }

    }
}
