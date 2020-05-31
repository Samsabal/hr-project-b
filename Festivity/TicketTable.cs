using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace Festivity
{
    internal class TicketTable
    {
        private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
        private static readonly JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

        public static void TicketTablePage()
        {
            Console.WriteLine("testtetststsetsett");
            Thread.Sleep(2000);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Program.Main(); //new string[] { }

            foreach (var user in users.Users)
            {
            }
            MenuFunction.Menu(new string[] { "Change user information", "Change password", "Preference for e-mails", "Exit to Main Menu" });
            //foreach (var transaction in Transaction.transactions)
            //{
            //    if (transaction.buyerID == UserLoginPage.currentUserId)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("Your account Information: ");
            //        Console.WriteLine();
            //        Console.WriteLine($"    {user.firstName} {user.lastName}");
            //        Console.WriteLine($"    {user.userAddress.streetName} {user.userAddress.streetNumber}");
            //        Console.WriteLine($"    {user.userAddress.zipCode} {user.userAddress.city}");
            //        Console.WriteLine($"    {user.email}");
            //        Console.WriteLine("");
            //        MenuFunction.menu(new string[] { "Change user information", "Change password", "Preference for e-mails", "Exit to Main Menu" });
            //    }
            //}
        }
    }
}