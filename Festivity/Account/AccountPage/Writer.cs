using Festivity.Account;
using System;

namespace Festivity.AccountPage
{
    internal class Writer
    {
        public static void AccountPage()
        {
            do
            {
                Console.WriteLine("Your account Information: ");
                Console.WriteLine();
                Console.WriteLine($"    {LoggedInModel.User.FirstName} {LoggedInModel.User.LastName}");
                Console.WriteLine($"    {LoggedInModel.User.userAddress.StreetName} {LoggedInModel.User.userAddress.StreetNumber}");
                Console.WriteLine($"    {LoggedInModel.User.userAddress.ZipCode} {LoggedInModel.User.userAddress.City}");
                Console.WriteLine($"    {LoggedInModel.User.Email}");
                Console.WriteLine();
                if (LoggedInModel.User.AccountType == 1)
                {
                    Console.WriteLine($"    Total amount earned: {Utils.AmountEarned()} Euro");
                }
                Console.WriteLine();
                Menu.Draw(new AccountPageMenu().Build());
            }
            while (Menu.Loop);
        }

        public static void ChangeInfoPage()
        {
            Console.WriteLine("     Your account Information: ");
            Console.WriteLine();
            Console.WriteLine($"1.  Firstname:              {LoggedInModel.User.FirstName}");
            Console.WriteLine($"2.  Lastname:               {LoggedInModel.User.LastName}");
            Console.WriteLine($"3.  Email:                  {LoggedInModel.User.Email}");

            if (LoggedInModel.User.AccountType == 1) // Organiser
            {
                Console.WriteLine($"4.  Street address:         {LoggedInModel.User.userAddress.StreetName} {LoggedInModel.User.userAddress.StreetNumber}");
                Console.WriteLine($"5.  City:                   {LoggedInModel.User.userAddress.City}");
                Console.WriteLine($"6.  ZipCode:                {LoggedInModel.User.userAddress.ZipCode}");
                Console.WriteLine($"7.  Country:                {LoggedInModel.User.userAddress.Country}");
                Console.WriteLine($"8.  Company name:           {LoggedInModel.User.CompanyName}");
                Console.WriteLine($"9.  Company phonenumber:    {LoggedInModel.User.CompanyPhoneNumber}");
                Console.WriteLine();
            }
            if (LoggedInModel.User.AccountType == 2) // Visitor
            {
                Console.WriteLine($"4.  Street address:         {LoggedInModel.User.userAddress.StreetName} {LoggedInModel.User.userAddress.StreetNumber}");
                Console.WriteLine($"5.  City:                   {LoggedInModel.User.userAddress.City}");
                Console.WriteLine($"6.  ZipCode:                {LoggedInModel.User.userAddress.ZipCode}");
                Console.WriteLine($"7.  Country:                {LoggedInModel.User.userAddress.Country}");
                Console.WriteLine($"8.  Phonenumber:            {LoggedInModel.User.PhoneNumber}");
                Console.WriteLine();
            }
        }
    }
}