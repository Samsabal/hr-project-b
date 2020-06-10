using Festivity.Account;
using System;

namespace Festivity.AccountPage
{
    internal class Writer
    {
        private static UIElements UI = new UIElements("Account");
        public static void AccountPage()
        {
            while (true)
            {
                UI.InfoLine("Your account Information: ");
                UI.Pom("Account");
                Console.WriteLine();
                Console.WriteLine($" {LoggedInModel.User.FirstName} {LoggedInModel.User.LastName}");
                Console.WriteLine($" {LoggedInModel.User.userAddress.StreetName} {LoggedInModel.User.userAddress.StreetNumber}");
                Console.WriteLine($" {LoggedInModel.User.userAddress.ZipCode} {LoggedInModel.User.userAddress.City}");
                Console.WriteLine($" {LoggedInModel.User.Email}");
                Console.WriteLine();
                if (LoggedInModel.User.AccountType == 1)
                {
                    Console.WriteLine($" Total amount earned: {Utils.AmountEarned()} Euro");
                }
                Console.WriteLine();
                UI.Line();
                Console.WriteLine();
                Menu.Draw(new AccountPageMenu().Build());
            }
        }
    }
}