using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Festivity
{
    class MenuFunction
    {

        public static int option;

        public static void menu(string[] consoleOptions, Festival[] festivals = null, Ticket[] tickets = null)
        {
            /// 1. Add your option as string in consoleOptions argument.
            /// 2. Add your extra "option" as a new case inside the switch statement with the correct function.
            if (festivals != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("Select festival: {0}", festivals[i].festivalName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = 5; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
            }

            else if (tickets != null)
            {
                for (int i = 0; i < TicketBuy.ticketListLength; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("Order ticket: {0}", tickets[i].ticketName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = TicketBuy.ticketListLength; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
            }


            else
            {
                for (int i = 0; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
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
                switch (consoleOptions[option])
                {
                    case "Register": // Register option
                        Console.Clear();
                        RegisterPage.register_page();
                        Thread.Sleep(10000);
                        break;
                    case "Login": // Login option
                        Console.Clear();
                        LoginPage.login_page();
                        Thread.Sleep(10000);
                        break;
                    case "Festivals": // Festival option
                        Console.Clear();
                        CatalogPage.catalog_main();
                        Thread.Sleep(5000);
                        break;
                    case "Register festival": // Festival register
                        Console.Clear();
                        FestivalRegister.festival_register();
                        Thread.Sleep(5000);
                        break;
                    case "Exit": // Exit option
                        Environment.Exit(0);
                        Console.Clear();
                        break;
                    case "Festival Page":
                        Console.Clear();
                        FestivalPage.festival_page(1);
                        Thread.Sleep(5000);
                        break;
                    case "Sort by name":
                        CatalogPage.festivalArray = CatalogPageFilter.sort_name(CatalogPage.festivalArray, CatalogPage.arraySize);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        break;
                    case "Sort by date":
                        CatalogPage.festivalArray = CatalogPageFilter.sort_date(CatalogPage.festivalArray, CatalogPage.arraySize);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        break;
                    case "Return":
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.catalog_main();
                        break;
                    case "Next page":
                        if (CatalogPage.currentPage * 5 + 5 < CatalogPage.arraySize)
                        {
                            CatalogPage.currentPage++;
                        }
                        break;
                    case "Previous page":
                        if (CatalogPage.currentPage > 0)
                        {
                            CatalogPage.currentPage--;
                        }
                        break;
                    case "I am an Organisator":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        RegisterPage.userAccountType = 1;
                        break;
                    case "I am a Visitor":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        RegisterPage.userAccountType = 2;
                        break;
                    case "Yes, I want to recieve a newsletters":
                        RegisterPage.newsLetter = 1;
                        break;
                    case "No, I don't want to recieve a newsletters":
                        RegisterPage.newsLetter = 2;
                        break;
                    case "Yes, I accept the terms and conditions":
                        RegisterPage.userTerms = 1;
                        break;
                    case "Exit to Main Menu":
                        Console.Clear();
                        Program.Main(new string[] { });
                        break;
                    case "festival1":
                        if (festivals[0].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = 1;
                            FestivalPage.festival_page(festivals[0].festivalId);
                        }
                        break;
                    case "festival2":
                        if (festivals[1].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = 2;
                            FestivalPage.festival_page(festivals[1].festivalId);
                        }
                        break;
                    case "festival3":
                        if (festivals[2].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = 3;
                            FestivalPage.festival_page(festivals[2].festivalId);
                        }
                        break;
                    case "festival4":
                        if (festivals[3].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = 4;
                            FestivalPage.festival_page(festivals[3].festivalId);
                        }
                        break;
                    case "festival5":
                        if (festivals[4].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = 5;
                            FestivalPage.festival_page(festivals[4].festivalId);
                        }
                        break;
                    case "Filter festivals":
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
                        TicketBuy.ticket_buy(CatalogPage.selectedFestival);
                        break;
                    case "Return to Festival Page":
                        Console.Clear();
                        FestivalPage.festival_page(CatalogPage.selectedFestival);
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
            Console.Clear();

        }
    }
}
