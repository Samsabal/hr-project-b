using Festivity.Utils;
using System;

namespace Festivity.Transaction
{
    internal class Reader
    {
        public static int TicketAmount(int selectedOption)
        {
            string userInput;
            Console.WriteLine("How many tickets would you like to buy? ");
            do { userInput = General.InputLoopWithoutPrint(); }
            while (!NumberCheck(userInput, 1, TicketListBuilder.GetSelectedTicket(selectedOption).MaxTicketsPerPerson));
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
            string input;

            do { input = General.InputLoop("Confirm Order? ('yes' or 'no'): "); }
            while (!RegexUtils.IsValidYesOrNo(input));

            return AccountRegistration.Handler.IsInputYes(input);
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