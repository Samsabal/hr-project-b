using System;

namespace Festivity.AccountLogin
{
    internal class Reader
    {
        public static string GetEmailInput()
        {
            
            Console.Write(" Enter Email: ");
            string input = Console.ReadLine();
            RegexUtils.MakesUserQuitIfCalled(input);
            return input;
        }

        public static string GetPasswordInput()
        {
            Console.Write(" Enter Password: ");
            string input = Console.ReadLine();
            RegexUtils.MakesUserQuitIfCalled(input);
            return input;
        }
    }
}