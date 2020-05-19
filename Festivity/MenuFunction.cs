using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Festivity
{
    class MenuFunction
    {

        public static int option;

        public static void menu(string[] consoleOptions, object[] objects = null)
        {
            /// 1. Add your option as string in consoleOptions argument.
            /// 2. (optional) Add a second array that contains objects to display dynamic names of options in objects argument.
            /// 3. Add your extra "option" as a new case inside the switch statement with the correct function.
            if (objects == null)
            {
                {
                    for (int i = 0; i < consoleOptions.Length; i++)
                    {
                        if (option == i)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        Console.WriteLine("{0}", consoleOptions[i]);
                        if (option == i)
                        {
                            Console.ResetColor();
                        }
                    }
                }
            }

            else if (objects[0].GetType() == typeof(Festivity.Festival))
            {

                for (int i = 0; i < 5; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Festival tempfestival = (Festival)objects[i];

                    Console.WriteLine("Select festival: {0}", tempfestival.festivalName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = 5; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
            }

            else if (objects[0].GetType() == typeof(Festivity.Ticket))
            {
                for (int i = 0; i < TicketBuy.ticketListLength; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Ticket tempticket = (Ticket)objects[i];

                    Console.WriteLine("Order ticket: {0}", tempticket.ticketName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = TicketBuy.ticketListLength; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
            }


            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (option != consoleOptions.Length - 1)
                {
                    option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (option != 0)
                {
                    option--;
                }
            }

            // When Enter key is pressed execute selected option.
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                Console.CursorVisible = true;
                switch (consoleOptions[option])
                {
                    case "Register": // "Register" option home screen
                        Console.Clear();
                        UserRegisterPage.register_page();
                        break;
                    case "Login": // "Login" option home screen
                        Console.Clear();
                        UserLoginPage.login_page();
                        break;
                    case "Festivals": // "Festival catalog" option home screen
                        Console.Clear();
                        CatalogPage.catalog_main();
                        Thread.Sleep(1000);
                        break;
                    case "Register festival": // "Register festival" option home screen
                        Console.Clear();
                        FestivalRegister.festival_register();
                        Thread.Sleep(1000);
                        break;
                    case "Exit": // "Exit" option home screen
                        Environment.Exit(0);
                        Console.Clear();
                        break;
                    // !!!! TEMPORARY OPTION !!!!
                    case "Festival Page":
                        Console.Clear();
                        FestivalPage.festival_page(1);
                        Thread.Sleep(1000);
                        break;
                    case "Sort by name": // "Sort by name" option on catalog page filter/sort screen
                        CatalogPage.festivalArray = CatalogPageFilter.sort_name(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        break;
                    case "Sort by date": // "Sort by date" option on catalog page filter/sort screen
                        CatalogPage.festivalArray = CatalogPageFilter.sort_date(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        break;
                    case "Return to catalog": // "Return to catalog" option on catalog page filter/sort screen
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.catalog_main();
                        break;
                    case "Next page": // "Next page" option on catalog page screen
                        if (CatalogPage.currentPage * 5 + 5 < CatalogPage.arraySize)
                        {
                            CatalogPage.currentPage++;
                        }
                        break;
                    case "Previous page": // "Previous page" option on catalog page screen
                        if (CatalogPage.currentPage > 0)
                        {
                            CatalogPage.currentPage--;
                        }
                        break;
                    case "I am an Organisator":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        UserRegisterPage.userAccountType = 1;
                        break;
                    case "I am a Visitor":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        UserRegisterPage.userAccountType = 2;
                        break;
                    case "Yes, I want to recieve a newsletters":
                        UserRegisterPage.newsLetter = 1;
                        break;
                    case "No, I don't want to recieve a newsletters":
                        UserRegisterPage.newsLetter = 2;
                        break;
                    case "Yes, I accept the terms and conditions":
                        UserRegisterPage.userTerms = 1;
                        break;
                    case "Exit to Main Menu": // "Exit to Main Menu" option on any relevant screen
                        Console.Clear();
                        Program.Main(new string[] { });
                        break;
                    case "festival1": // First festival option in the catalog screen
                        Festival festival1 = (Festival)objects[0];
                        if (festival1.festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festival1.festivalId);
                        }
                        break;
                    case "festival2": // Second festival option in the catalog screen
                        Festival festival2 = (Festival)objects[1];
                        if (festival2.festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festival2.festivalId);
                        }
                        break;
                    case "festival3": // Third festival option in the catalog screen
                        Festival festival3 = (Festival)objects[2];
                        if (festival3.festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festival3.festivalId);
                        }
                        break;
                    case "festival4": // Fourth festival option in the catalog screen
                        Festival festival4 = (Festival)objects[3];
                        if (festival4.festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festival4.festivalId);
                        }
                        break;
                    case "festival5": // Fifth festival option in the catalog screen
                        Festival festival5 = (Festival)objects[4];
                        if (festival5.festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festival5.festivalId);
                        }
                        break;
                    case "Filter festivals": // Filter festivals option on the main CatalogPage screen
                        option = 0;
                        CatalogPage.currentCatalogNavigation = "filter";
                        break;
                    case "Return to Catalog":
                        Console.Clear();
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.catalog_main();
                        break;
                    case "Order Tickets":
                        Console.Clear();
                        CatalogPage.activeScreen = false;
                        if (UserLoginPage.currentUserId == 0)
                        {
                            UserLoginPage.user_login(1);
                        }
                        TicketBuy.ticket_buy(CatalogPage.selectedFestival);
                        break;
                    case "Return to Festival Page":
                        Console.Clear();
                        FestivalPage.festival_page(CatalogPage.selectedFestival);
                        break;
                    case "Login to your Account":
                        Console.Clear();
                        UserLoginPage.userLoginChoice = 1;
                        UserLoginPage.user_login();
                        break;
                    case "Forgot password":
                        Console.Clear();
                        UserLoginPage.userLoginChoice = 2;
                        UserLoginPage.forgot_password();
                        break;
                    case "Logout":
                        Console.Clear();
                        Console.WriteLine("Successfully logged out!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        UserLoginPage.currentUserId = 0;
                        Program.Main(new string[] { });
                        break;
                    case "Account":
                        Console.Clear();
                        UserAccountPage.account_page();
                        break;
                    case "Change user information":
                        Console.Clear();
                        UserAccountPage.account_change_info();
                        break;
                    case "Preference for e-mails":
                        Console.Clear();
                        UserAccountPage.account_email_prefference();
                        break;
                    case "Change password":
                        Console.Clear();
                        UserAccountPage.change_password();
                        break;
                    default:
                        if (consoleOptions[option].StartsWith("Order Ticket"))
                        {

                            Match ticketId = Regex.Match(consoleOptions[option], @"(?<=:)[^\]]+");

                            TicketBuy.ticket_buy_selected(Int32.Parse(ticketId.Value));
                        }
                        break;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}