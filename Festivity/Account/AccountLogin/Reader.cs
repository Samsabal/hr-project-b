using System;

namespace Festivity.AccountLogin
{
    internal class Reader
    {
        public static string GetEmailInput()
        {
            Console.Write("Enter Email: ");
            return Console.ReadLine();
        }

        public static string GetPasswordInput()
        {
            Console.Write("Enter Password: ");
            return Console.ReadLine();
        }
    }
}