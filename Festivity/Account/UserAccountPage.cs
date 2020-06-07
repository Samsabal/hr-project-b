using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class UserAccountPage
    {
        //private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"UsersDatabase.json");
        private static readonly JSONUserList userList = JSONFunctionality.GetUserList();

        private static readonly JSONFestivalList festivals = JSONFunctionality.GetFestivals();
        private static readonly JSONTicketList tickets = JSONFunctionality.GetTickets();
        private static readonly JSONTransactionList transactions = JSONFunctionality.GetTransactions();

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
                    Console.WriteLine($"    Total amount earned: {AmountEarned()} Euro's");
                }
                Console.WriteLine("");
                MenuFunction.Menu(new string[] { "Change user information", "Change password", "Preference for e-mails", "Exit to Main Menu" });
            }
        }

        public static void AccountChangeInfo()
        {
            foreach (var user in userList.Users)
            {
                if (LoggedInAccount.GetID() == user.AccountID)
                {
                    Console.WriteLine("     Your account Information: ");
                    Console.WriteLine();
                    Console.WriteLine($"1.  Firstname:              {user.FirstName}");
                    Console.WriteLine($"2.  Lastname:               {user.LastName}");
                    Console.WriteLine($"3.  Email:                  {user.Email}");

                    if (LoggedInAccount.User.AccountType == 1) // Organisator
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"4.  Street address:         {user.userAddress.StreetName} {user.userAddress.StreetNumber}");
                        Console.WriteLine($"5.  City:                   {user.userAddress.City}");
                        Console.WriteLine($"6.  ZipCode:                {user.userAddress.ZipCode}");
                        Console.WriteLine($"7.  Country:                {user.userAddress.Country}");
                        Console.WriteLine("");
                        Console.WriteLine($"8.  Company name:           {user.CompanyName}");
                        Console.WriteLine($"9.  Company phonenumber:    {user.CompanyPhoneNumber}\n");
                        Console.WriteLine("");
                    }
                    if (LoggedInAccount.User.AccountType == 2) // Festival goer
                    {
                        Console.WriteLine($"4.  Phonenumber:            {user.PhoneNumber}");
                        Console.WriteLine($"5.  Street address:         {user.userAddress.StreetName} {user.userAddress.StreetNumber}");
                        Console.WriteLine($"6.  City:                   {user.userAddress.City}");
                        Console.WriteLine($"7.  ZipCode:                {user.userAddress.ZipCode}");
                        Console.WriteLine($"8.  Country:                {user.userAddress.Country}\n");
                        Console.WriteLine("");
                    }
                    int userInput;
                    Console.Write("Enter the number and press <Enter>: ");
                    while (!int.TryParse(Console.ReadLine(), out userInput))
                    {
                        Console.Clear();
                        Console.WriteLine("You entered an invalid number");
                        Console.Write("Enter the number and press <Enter>: ");
                    }
                    if (userInput > 0 && userInput <= 8)
                    {
                        AccountChangeOrganisator(userInput);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
        }

        public static void AccountEmailPrefference()
        {
            if (LoggedInAccount.User.NewsLetter == 1)
            {
                Console.WriteLine("Do you want to stop recieving Newsletters? [Y or N].");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    Console.Clear();
                    LoggedInAccount.User.NewsLetter = 0;
                    Console.WriteLine("Preference successfully changed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else if (userInput.ToLower() != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again.");
                    AccountEmailPrefference();
                }
            }
            else if (LoggedInAccount.User.NewsLetter == 0)
            {
                Console.WriteLine("Do you want to recieve Newsletters? [Y or N]");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    Console.Clear();
                    LoggedInAccount.User.NewsLetter = 1;
                    Console.WriteLine("Preference successfully changed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else if (userInput.ToLower() != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again.");
                    AccountEmailPrefference();
                }
            }
            LoggedInAccount.UpdateDatabase();
        }

        public static void AccountChangeOrganisator(int userSelection)
        {
            string userInput;
            if (LoggedInAccount.User.AccountType == 1)
            {
                switch (userSelection)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Input new firstname: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.FirstName = userInput;
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Input new lastname: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.LastName = userInput;
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Input new email: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.Email = userInput;
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Input new streetname: ");
                        string userInput1 = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Input new streetnumber: ");
                        string userInput2 = Console.ReadLine();
                        LoggedInAccount.User.userAddress.StreetName = userInput1;
                        LoggedInAccount.User.userAddress.StreetNumber = userInput2;
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Input new city: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.userAddress.City = userInput;
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Input new zipcode: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.userAddress.ZipCode = userInput;
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Input new country: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.userAddress.Country = userInput;
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("Input new companyname: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.CompanyName = userInput;
                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("Input new companynumber: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.CompanyPhoneNumber = userInput;
                        break;

                    default:
                        break;
                }
            }
            if (LoggedInAccount.User.AccountType == 2) // Festival Goer
            {
                switch (userSelection)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Input new firstname: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.FirstName = userInput;
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Input new lastname: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.LastName = userInput;
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Input new email: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.Email = userInput;
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Input new phoneNumber: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.PhoneNumber = userInput;
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Input new streetname: ");
                        string userInput1 = Console.ReadLine();
                        Console.WriteLine("Input new streetnumber: ");
                        string userInput2 = Console.ReadLine();
                        LoggedInAccount.User.userAddress.StreetName = userInput1;
                        LoggedInAccount.User.userAddress.StreetNumber = userInput2;
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Input new city: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.userAddress.City = userInput;
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Input new zipcode: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.userAddress.ZipCode = userInput;
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("Input new country: ");
                        userInput = Console.ReadLine();
                        LoggedInAccount.User.userAddress.Country = userInput;
                        break;

                    default:
                        break;
                }
            }
            LoggedInAccount.UpdateDatabase();
        }

        public static void ChangePassword()
        {
            string userInput;
            Console.WriteLine("Input current password: ");
            userInput = Console.ReadLine();
            Console.Clear();
            if (userInput == LoggedInAccount.User.Password)
            {
                Console.WriteLine("Input new password: ");
                string userInput1 = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Input new password again: ");
                string userInput2 = Console.ReadLine();
                Console.Clear();
                if (userInput1 == userInput2)
                {
                    LoggedInAccount.User.Password = userInput2;
                    Console.WriteLine("Password successfully changed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Passwords do not match, please try again.");
                    Thread.Sleep(1000);
                    ChangePassword();
                }
            }
            else
            {
                Console.WriteLine("Invalid password, please try again.");
                Thread.Sleep(1000);
                ChangePassword();
            }
            LoggedInAccount.UpdateDatabase();
        }

        public static double AmountEarned()
        {
            List<Ticket> ticketList = new List<Ticket>();
            double amountEarned = 0.0;

            foreach (var festival in festivals.Festivals)
            {
                if (LoggedInAccount.GetID() == festival.FestivalOrganiserID)
                {
                    foreach (var ticket in tickets.Tickets)
                    {
                        if (festival.FestivalID == ticket.FestivalID)
                        {
                            ticketList.Add(ticket);
                        }
                    }
                }
            }

            foreach (var transaction in transactions.Transactions)
            {
                foreach (var organisatorTicket in ticketList)
                {
                    if (organisatorTicket.TicketID == transaction.TicketID)
                    {
                        amountEarned += organisatorTicket.TicketPrice * transaction.TicketAmount;
                    }
                }
            }
            return amountEarned;
        }
    }
}