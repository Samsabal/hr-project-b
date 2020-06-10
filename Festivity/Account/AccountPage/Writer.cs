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
                UI.PathLine();
                UI.InfoLine("Your account Information: ");
                UI.Pom("Account");
                Console.WriteLine($" Name:                   {LoggedInModel.User.FirstName} {LoggedInModel.User.LastName}");
                Console.WriteLine($" Address:                {LoggedInModel.User.userAddress.StreetName} {LoggedInModel.User.userAddress.StreetNumber}");
                Console.WriteLine($"                         {LoggedInModel.User.userAddress.ZipCode} {LoggedInModel.User.userAddress.City}");
                Console.WriteLine($" Email:                  {LoggedInModel.User.Email}");
                

                if (LoggedInModel.User.AccountType == 2)
                {
                    Console.WriteLine($" Phone Number:           {LoggedInModel.User.PhoneNumber}");
                }

                Console.WriteLine();
                if (LoggedInModel.User.AccountType == 1)
                {
                    Console.WriteLine($" Company name:           {LoggedInModel.User.CompanyName}");
                    Console.WriteLine($" Contactperson:          {LoggedInModel.User.ContactPerson}");
                    Console.WriteLine($" Phone Number:           {LoggedInModel.User.CompanyPhoneNumber}");
                    Console.WriteLine($" IBAN:                   {LoggedInModel.User.CompanyIBAN}");
                    Console.WriteLine();
                    Console.WriteLine($" Total amount earned:    \u20AC{Utils.AmountEarned():F2}");
                }
                        
                Console.WriteLine();
                UI.Line();
                Console.WriteLine();
                Menu.Draw(new AccountPageMenu().Build());
            }
        }
    }
}