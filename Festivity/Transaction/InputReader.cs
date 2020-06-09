using Festivity.Utils;
using System;

namespace Festivity.Transaction
{
    internal class InputReader
    {
        public static int TicketAmount()
        {
            string userInput;
            Console.WriteLine("How many tickets would you like to buy? ");
            do { userInput = General.InputLoopString(); }
            while (!NumberCheck(userInput, 1, 10));
            return Int32.Parse(userInput);
        }

        public static void PaymentOption()
        {
            Console.Clear();
            Menu.OptionReset();
            while (true)
            {
                Console.WriteLine("Choose your payment method:");
                Menu.Draw(new PaymentOptionMenu().Build());
            }
        }

        public static bool ConfirmTransaction()
        {
            ConsoleKey input;
            Console.WriteLine("Confirm Order? [y/n]");
            do { input = General.InputLoopKey(); }
            while (General.YesOrNoCheck(input));

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
                ErrorMessage.WriteLine("Invalid input, please try again");
                return false;
            }
            ErrorMessage.WriteLine("Invalid input, please try again");
            return false;
        }
    }
}