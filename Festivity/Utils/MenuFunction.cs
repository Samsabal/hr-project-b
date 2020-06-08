using Festivity.Account;
﻿using Festivity.Utils;
using System;
using System.Threading;

namespace Festivity
{
    internal class MenuFunction
    {
        public static int option;

        public static void Menu(string[] consoleOptions, object[] objects = null)
        {
            Console.CursorVisible = false;
            /// 1. Add your option as string in consoleOptions argument.
            /// 2. (optional) Add a second array that contains objects to display dynamic names of
            /// options in objects argument.
            /// 3. Add your extra "option" as a new case inside the switch statement with the
            /// correct function.
            if (objects == null)
            {
                {
                    for (int i = 0; i < consoleOptions.Length; i++)
                    {
                        if (option == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine("{0}", consoleOptions[i]);
                        if (option == i)
                        {
                            Console.ResetColor();
                        }
                    }
                }
            }
            else if (objects[0].GetType() == typeof(FestivalModel))
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    FestivalModel tempfestival = (FestivalModel)objects[i];

                    Console.WriteLine("Select festival: {0}", tempfestival.FestivalName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = objects.Length; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
            }
            else if (objects[0].GetType() == typeof(Ticket))
            {
                for (int i = 0; i < Transaction.TicketListBuilder.GetLength(); i++)
                {
                    ConsoleHelperFunctions.ClearCurrentConsoleLine();
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Ticket tempticket = (Ticket)objects[i];

                    Console.WriteLine("Buy Ticket: {0}", tempticket.TicketName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = Transaction.TicketListBuilder.GetLength(); i < consoleOptions.Length; i++)
                {
                    ConsoleHelperFunctions.ClearCurrentConsoleLine();
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("{0}", consoleOptions[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
                ConsoleHelperFunctions.ClearCurrentConsoleLine();
            }
            else
            {
                for (int i = 0; i < consoleOptions.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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
                        AccountRegistration.Manager.InitateUserRegistration();
                        //UserRegisterPage.CreateUser();
                        break;

                    case "Login": // "Login" option home screen
                        Console.Clear();
                        AccountLogin.LoginManager.InitiateLoginPage();
                        //UserLoginPage.LoginPage();
                        break;

                    case "Festivals": // "Festival catalog" option home screen
                        Console.Clear();
                        CatalogPage.CatalogMain();
                        Thread.Sleep(1000);
                        break;
                    case "Exit": // "Exit" option home screen
                        Environment.Exit(0);
                        Console.Clear();
                        break;
                    case "Sort by name": // "Sort by name" option on catalog page filter/sort screen
                        CatalogPage.festivalArray = SortingFunctions.SortName(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Sort by date":
                        CatalogPage.festivalArray = SortingFunctions.SortDate(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Sort by price":
                        CatalogPage.festivalArray = SortingFunctions.SortPrice(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Sort by availability":
                        CatalogPage.festivalArray = SortingFunctions.SortAvailability(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Filter by festival name":
                        string namesearch = Console.ReadLine();
                        CatalogPage.festivalArray = FilterFunctions.FilterName(CatalogPage.festivalArray, namesearch);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Filter by genre":
                        CatalogPage.festivalArray = FilterFunctions.FilterGenre(CatalogPage.festivalArray, Console.ReadLine());
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Filter by location (City/Street)":
                        CatalogPage.festivalArray = FilterFunctions.FilterLocation(CatalogPage.festivalArray, Console.ReadLine());
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Clear filters":
                        CatalogPage.festivalArray = JSONFunctionality.GetFestivals().Festivals.ToArray();
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Return to catalog": // "Return to catalog" option on catalog page filter/sort screen
                        CatalogPage.currentCatalogNavigation = "main";
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        CatalogPage.CatalogMain();
                        break;

                    case "Next page": // "Next page" option on catalog page screen
                        if (CatalogPage.currentPage * 5 + 5 < CatalogPage.festivalArray.Length)
                        {
                            option = 0;
                            ConsoleHelperFunctions.ClearCurrentConsole();
                            CatalogPage.currentPage++;
                        }
                        break;

                    case "Previous page": // "Previous page" option on catalog page screen
                        if (CatalogPage.currentPage > 0)
                        {
                            option = 0;
                            ConsoleHelperFunctions.ClearCurrentConsole();
                            CatalogPage.currentPage--;
                        }
                        break;

                    case "I am an Organisator":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        AccountRegistration.Registration.SetAccountType(1);
                        break;

                    case "I am a Visitor":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        AccountRegistration.Registration.SetAccountType(2);
                        break;

                    case "Yes, I want to recieve newsletters":
                        AccountRegistration.Registration.SetNewsLetter(true);
                        break;

                    case "No, I don't want to recieve newsletters":
                        AccountRegistration.Registration.SetNewsLetter(false);
                        break;

                    case "Exit to Main Menu": // "Exit to Main Menu" option on any relevant screen
                        option = 0;
                        Console.Clear();
                        Program.Main(); //new string[] { }
                        break;

                    case "Filter festivals": // Filter festivals option on the main CatalogPage screen
                        option = 0;
                        CatalogPage.currentCatalogNavigation = "filter";
                        Console.Clear();
                        break;

                    case "Return to Catalog":
                        Console.Clear();
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.CatalogMain();
                        break;

                    case "Order Tickets":
                        Console.Clear();
                        if (LoggedInAccount.IsLoggedIn())
                        {
                            // Transaction.DrawBuyTicketPage.Draw();
                        }
                        else
                        {
                            AccountLogin.LoginManager.InitateLogin(true);
                        }
                        break;

                    case "Login to your Account":
                        Console.Clear();
                        AccountLogin.LoginManager.InitateLogin(false);
                        //UserLoginPage.userLoginChoice = 1;
                        //UserLoginPage.UserLogin();
                        break;

                    case "Forgot password":
                        Console.Clear();
                        AccountLogin.LoginManager.InitateForgotPassword();
                        //UserLoginPage.userLoginChoice = 2;
                        //UserLoginPage.ForgotPassword();
                        break;

                    case "Logout":
                        Console.Clear();
                        Console.WriteLine("Successfully logged out!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        option = 0;
                        LoggedInAccount.LogOut();
                        Program.Main(); //new string[] { }
                        break;

                    case "My Account":
                        Console.Clear();
                        AccountPage.Manager.DrawPage();
                        break;

                    case "Change user information":
                        Console.Clear();
                        AccountPage.Manager.InitateInfoChange();
                        break;

                    case "Preference for e-mails":
                        Console.Clear();
                        Account.ChangeEmailPreference.Initate();
                        break;

                    case "Change password":
                        Console.Clear();
                        Account.ChangePassword.Initiate();
                        break;

                    case "My Tickets":
                        Console.Clear();
                        TicketTableManager.Initiate();
                        break;

                    case "Refund Ticket":
                        RefundTicket.InitiateRefund();
                        break;

                    case "iDEAL":
                        Console.Clear();
                        Transaction.DisplayManager.Complete();
                        break;

                    case "Paypal":
                        Console.Clear();
                        Transaction.DisplayManager.Complete();
                        break;

                    case "Creditcard":
                        Console.Clear();
                        Transaction.DisplayManager.Complete();
                        break;

                    case "Cancel Order":
                        Console.Clear();
                        break;

                    default:
                        if (consoleOptions[option].StartsWith("Buy Ticket"))
                        {
                            Console.Clear();
                            Transaction.DisplayManager.Initiate(option);
                        }
                        else if (consoleOptions[option].StartsWith("Select festival"))
                        {
                            FestivalModel tempfestival = (FestivalModel)objects[option];
                            Console.Clear();
                            CatalogPage.selectedFestival = tempfestival.FestivalID;
                            Festival.PageManager.Display(tempfestival.FestivalID);
                        }
                        break;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}