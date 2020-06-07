namespace Festivity.AccountPage
{
    internal class Reader
    {
        public static int AccountOption()
        {
            string userInput;

            do { userInput = Utils.InputLoop("Enter the number and press <Enter>: "); }
            while (!Utils.IsValidAccountChange(userInput, Utils.GetOptionAmount()));

            return int.Parse(userInput);
        }
    }
}