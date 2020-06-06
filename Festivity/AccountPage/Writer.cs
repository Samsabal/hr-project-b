using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.AccountPage
{
    class Writer
    {
        public static void AccountPage()
        {
            MenuFunction.option = 0;
            while (true)
            {
                Console.WriteLine("Your account Information: ");
                Console.WriteLine();
                Console.WriteLine($"    {LoggedInAccount.User.FirstName} {LoggedInAccount.User.LastName}");
                Console.WriteLine($"    {LoggedInAccount.User.userAddress.StreetName} {LoggedInAccount.User.userAddress.StreetNumber}");
                Console.WriteLine($"    {LoggedInAccount.User.userAddress.ZipCode} {LoggedInAccount.User.userAddress.City}");
                Console.WriteLine($"    {LoggedInAccount.User.Email}");
                Console.WriteLine();
                if (LoggedInAccount.User.AccountType == 1)
                {
                    Console.WriteLine($"    Total amount earned: {Utils.AmountEarned()} Euro's");
                }
                Console.WriteLine();
                MenuFunction.Menu(new string[] { "Change user information", "Change password", "Preference for e-mails", "Exit to Main Menu" });
            }
        }

        public static void ChangeInfoPage()
        {
            Console.WriteLine("     Your account Information: ");
            Console.WriteLine();
            Console.WriteLine($"1.  Firstname:              {LoggedInAccount.User.FirstName}");
            Console.WriteLine($"2.  Lastname:               {LoggedInAccount.User.LastName}");
            Console.WriteLine($"3.  Email:                  {LoggedInAccount.User.Email}");

            if (LoggedInAccount.User.AccountType == 1) // Organisator
            {
                Console.WriteLine($"4.  Street address:         {LoggedInAccount.User.userAddress.StreetName} {LoggedInAccount.User.userAddress.StreetNumber}");
                Console.WriteLine($"5.  City:                   {LoggedInAccount.User.userAddress.City}");
                Console.WriteLine($"6.  ZipCode:                {LoggedInAccount.User.userAddress.ZipCode}");
                Console.WriteLine($"7.  Country:                {LoggedInAccount.User.userAddress.Country}");
                Console.WriteLine($"8.  Company name:           {LoggedInAccount.User.CompanyName}");
                Console.WriteLine($"9.  Company phonenumber:    {LoggedInAccount.User.CompanyPhoneNumber}");
                Console.WriteLine();
            }
            if (LoggedInAccount.User.AccountType == 2) // Visitor
            {
                Console.WriteLine($"4.  Street address:         {LoggedInAccount.User.userAddress.StreetName} {LoggedInAccount.User.userAddress.StreetNumber}");
                Console.WriteLine($"5.  City:                   {LoggedInAccount.User.userAddress.City}");
                Console.WriteLine($"6.  ZipCode:                {LoggedInAccount.User.userAddress.ZipCode}");
                Console.WriteLine($"7.  Country:                {LoggedInAccount.User.userAddress.Country}");
                Console.WriteLine($"8.  Phonenumber:            {LoggedInAccount.User.PhoneNumber}");
                Console.WriteLine();
            }
        }
    }
}
