using Festivity.Utils;
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
            else if (objects[0].GetType() == typeof(Festival))
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Festival tempfestival = (Festival)objects[i];

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
            else if (objects[0].GetType() == typeof(Ticket))
            {
                for (int i = 0; i < TicketBuy.GetTicketListLength(); i++)
                {
                    ConsoleHelperFunctions.ClearCurrentConsoleLine();
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Ticket tempticket = (Ticket)objects[i];

                    Console.WriteLine("Buy Ticket: {0}", tempticket.TicketName);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }

                for (int i = TicketBuy.GetTicketListLength(); i < consoleOptions.Length; i++)
                {
                    ConsoleHelperFunctions.ClearCurrentConsoleLine();
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
                ConsoleHelperFunctions.ClearCurrentConsoleLine();
            }
            else
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
                        UserLoginPage.LoginPage();
                        break;

                    case "Festivals": // "Festival catalog" option home screen
                        Console.Clear();
                        CatalogPage.CatalogMain();
                        Thread.Sleep(1000);
                        break;

                    case "Register festival": // "Register festival" option home screen
                        Console.Clear();
                        option = 0;
                        FestivalRegister.activeScreen = true;
                        FestivalRegister.currentRegisterSelection = "Main";
                        FestivalRegister.ShowFestivalRegister();
                        Thread.Sleep(1000);
                        break;

                    case "Exit": // "Exit" option home screen
                        Environment.Exit(0);
                        Console.Clear();
                        break;
                    // !!!! TEMPORARY OPTION !!!!
                    case "Festival Page":
                        Console.Clear();
                        FestivalPage.ShowFestivalPage(1);
                        Thread.Sleep(1000);
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
                        AccountRegistration.Registration.SetNewsLetter(1);
                        break;

                    case "No, I don't want to recieve newsletters":
                        AccountRegistration.Registration.SetNewsLetter(2);
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

                    case "Festival Name":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Festival Name";
                        break;

                    case "Festival Date":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Festival Date";
                        break;

                    case "Starting Time":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Starting Time";
                        break;

                    case "End Time":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "End Time";
                        break;

                    case "Festival Adress":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Festival Adress";
                        break;

                    case "Festival Description":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Festival Description";
                        break;

                    case "Age restriction":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Age Restriction";
                        break;

                    case "Festival Genre":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Festival Genre";
                        break;

                    case "Tickets":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Tickets";
                        break;

                    case "Save Festival":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Save Festival";
                        break;

                    case "Cancel Time":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Cancel Time";
                        break;

                    case "Cancel Festival Registration":
                        Console.Clear();
                        FestivalRegister.currentRegisterSelection = "Cancel Festival Registration";
                        break;

                    case "Order Tickets":
                        Console.Clear();
                        if (LoggedInAccount.IsLoggedIn())
                        {
                            TicketBuy.TicketShow();
                        }
                        else
                        {
                            UserLoginPage.UserLogin(1);
                        }
                        break;

                    case "Return to Festival Page":
                        Console.Clear();
                        FestivalPage.ShowFestivalPage(SelectedFestival.festival.FestivalID);
                        break;

                    case "Login to your Account":
                        Console.Clear();
                        UserLoginPage.userLoginChoice = 1;
                        UserLoginPage.UserLogin();
                        break;

                    case "Forgot password":
                        Console.Clear();
                        UserLoginPage.userLoginChoice = 2;
                        UserLoginPage.ForgotPassword();
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

                    case "Techno":
                        FestivalRegister.festivalGenre = "Techno";
                        FestivalRegister.currentRegisterSelection = "Main";
                        break;

                    case "Drum & Bass":
                        FestivalRegister.festivalGenre = "Drum & Bass";
                        FestivalRegister.currentRegisterSelection = "Main";
                        break;

                    case "Pop":
                        FestivalRegister.festivalGenre = "Pop";
                        FestivalRegister.currentRegisterSelection = "Main";
                        break;

                    case "Rock":
                        FestivalRegister.festivalGenre = "Rock";
                        FestivalRegister.currentRegisterSelection = "Main";
                        break;

                    case "Hip-Hop":
                        FestivalRegister.festivalGenre = "Hip-Hop";
                        FestivalRegister.currentRegisterSelection = "Main";
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
                        TicketBuy.ShowTicketBuy();
                        break;

                    case "Paypal":
                        Console.Clear();
                        TicketBuy.ShowTicketBuy();
                        break;

                    case "Creditcard":
                        Console.Clear();
                        TicketBuy.ShowTicketBuy();
                        break;

                    case "Cancel Order":
                        Console.Clear();
                        TicketBuy.TicketShow();
                        break;

                    default:
                        if (consoleOptions[option].StartsWith("Buy Ticket"))
                        {
                            Console.Clear();
                            TicketBuy.TicketConfirmation(option);
                        }
                        else if (consoleOptions[option].StartsWith("Select festival"))
                        {
                            Festival tempfestival = (Festival) objects[option];
                            Console.Clear();
                            SelectedFestival.festival = tempfestival;
                            FestivalPage.ShowFestivalPage(tempfestival.FestivalID);
                        }
                        break;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}