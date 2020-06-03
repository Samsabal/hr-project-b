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
                for (int i = 0; i < 5; i++)
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
            else if (objects[0].GetType() == typeof(Ticket))
            {
                for (int i = 0; i < TransactionBuilder.GetTicketListLength(); i++)
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

                for (int i = TransactionBuilder.GetTicketListLength(); i < consoleOptions.Length; i++)
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
                        UserRegisterPage.CreateUser();
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
                        CatalogPage.festivalArray = CatalogPageFilter.SortName(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Sort by date":
                        CatalogPage.festivalArray = CatalogPageFilter.SortDate(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;
                    case "Sort by price":
                        CatalogPage.festivalArray = CatalogPageFilter.SortPrice(CatalogPage.festivalArray);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;
                    case "Filter by festival name":
                        string namesearch = Console.ReadLine();
                        CatalogPage.festivalArray = CatalogPageFilter.FilterName(CatalogPage.festivalArray, namesearch);
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Filter by genre":
                        CatalogPage.festivalArray = CatalogPageFilter.FilterGenre(CatalogPage.festivalArray, Console.ReadLine());
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Filter by location (City/Street)":
                        CatalogPage.festivalArray = CatalogPageFilter.FilterLocation(CatalogPage.festivalArray, Console.ReadLine());
                        CatalogPage.currentCatalogNavigation = "main";
                        CatalogPage.currentPage = 0;
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        break;

                    case "Clear filters":
                        CatalogPageFilter.ClearFilters();
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
                            ConsoleHelperFunctions.ClearCurrentConsole();
                            CatalogPage.currentPage++;
                        }
                        break;

                    case "Previous page": // "Previous page" option on catalog page screen
                        if (CatalogPage.currentPage > 0)
                        {
                            ConsoleHelperFunctions.ClearCurrentConsole();
                            CatalogPage.currentPage--;
                        }
                        break;

                    case "I am an Organisator":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        UserRegisterPage.SetAccountType(1);
                        break;

                    case "I am a Visitor":
                        //Console.Clear();
                        //Console.WriteLine("\nAre you an Organisator or Visitor? ");
                        UserRegisterPage.SetAccountType(2);
                        break;

                    case "Yes, I want to recieve newsletters":
                        UserRegisterPage.SetNewsLetter(1);
                        break;

                    case "No, I don't want to recieve newsletters":
                        UserRegisterPage.SetNewsLetter(2);
                        break;

                    case "Exit to Main Menu": // "Exit to Main Menu" option on any relevant screen
                        option = 0;
                        Console.Clear();
                        Program.Main(); //new string[] { }
                        break;

                    case "festival1": // First festival option in the catalog screen
                        Festival festival1 = (Festival)objects[0];
                        if (festival1.FestivalID != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = festival1.FestivalID;
                            FestivalPage.ShowFestivalPage(festival1.FestivalID);
                        }
                        break;

                    case "festival2": // Second festival option in the catalog screen
                        Festival festival2 = (Festival)objects[1];
                        if (festival2.FestivalID != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = festival2.FestivalID;
                            FestivalPage.ShowFestivalPage(festival2.FestivalID);
                        }
                        break;

                    case "festival3": // Third festival option in the catalog screen
                        Festival festival3 = (Festival)objects[2];
                        if (festival3.FestivalID != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = festival3.FestivalID;
                            FestivalPage.ShowFestivalPage(festival3.FestivalID);
                        }
                        break;

                    case "festival4": // Fourth festival option in the catalog screen
                        Festival festival4 = (Festival)objects[3];
                        if (festival4.FestivalID != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = festival4.FestivalID;
                            FestivalPage.ShowFestivalPage(festival4.FestivalID);
                        }
                        break;

                    case "festival5": // Fifth festival option in the catalog screen
                        Festival festival5 = (Festival)objects[4];
                        if (festival5.FestivalID != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            CatalogPage.selectedFestival = festival5.FestivalID;
                            FestivalPage.ShowFestivalPage(festival5.FestivalID);
                        }
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
                        CatalogPage.activeScreen = false;
                        if (LoggedInAccount.User.AccountID == 0)
                        {
                            UserLoginPage.UserLogin(1);
                        }
                        DrawBuyTicketPage.Draw();
                        break;

                    case "Return to Festival Page":
                        Console.Clear();
                        FestivalPage.ShowFestivalPage(CatalogPage.selectedFestival);
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
                        UserAccountPage.AccountPage();
                        break;

                    case "Change user information":
                        Console.Clear();
                        UserAccountPage.AccountChangeInfo();
                        break;

                    case "Preference for e-mails":
                        Console.Clear();
                        UserAccountPage.AccountEmailPrefference();
                        break;

                    case "Change password":
                        Console.Clear();
                        UserAccountPage.ChangePassword();
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
                        TransactionManager.TransactionComplete();
                        break;

                    case "Paypal":
                        Console.Clear();
                        TransactionManager.TransactionComplete();
                        break;

                    case "Creditcard":
                        Console.Clear();
                        TransactionManager.TransactionComplete();
                        break;

                    case "Cancel Order":
                        Console.Clear();
                        DrawBuyTicketPage.Draw();
                        break;

                    default:
                        if (consoleOptions[option].StartsWith("Buy Ticket"))
                        {
                            Console.Clear();
                            TransactionManager.Initiate(option);
                        }
                        break;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}