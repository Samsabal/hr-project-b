using Festivity.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MenuBuilder
    {
        public static List<MenuOption> MainMenu()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Register", () =>
                {
                    Console.Clear();
                    AccountRegistration.Manager.InitateUserRegistration();
                }),
                new MenuOption("Login", () =>
                {
                    Console.Clear();
                    UserLoginPage.LoginPage();
                }),
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Exit", () =>
                {
                    Environment.Exit(0);
                })
            };

            return newMenuOptions;
        }

        public static List<MenuOption> MainMenuUser()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("My Account", () =>
                {
                    Console.Clear();
                    UserAccountPage.AccountPage();
                }),
                new MenuOption("My Tickets", () =>
                {
                    Console.Clear();
                    TicketTableManager.Initiate();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menu.OptionReset();
                    LoggedInAccount.LogOut();
                    Program.Main(); //new string[] { }
                }),
                new MenuOption("Exit", () =>
                {
                    Environment.Exit(0);
                })
            };

            return newMenuOptions;
        }

        public static List<MenuOption> MainMenuOrganiser()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festivals", () =>
                {
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Register Festivals", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalRegister.activeScreen = true;
                    FestivalRegister.currentRegisterSelection = "Main";
                    FestivalRegister.ShowFestivalRegister();
                    Thread.Sleep(1000);
                }),
                new MenuOption("My Account", () =>
                {
                    Console.Clear();
                    UserAccountPage.AccountPage();
                }),
                new MenuOption("My festivals", () =>
                {
                    // TODO
                    Console.Clear();
                    JSONFestivalList test = JSONFunctionality.GetFestivals();
                    while(true){
                        Menu.Draw(ChangeFestival(test.Festivals.ToArray()[0]));
                    }
                }),
                new MenuOption("My Tickets", () =>
                {
                    Console.Clear();
                    TicketTableManager.Initiate();
                }),
                new MenuOption("Logout", () =>
                {
                    Console.Clear();
                    Console.WriteLine("Successfully logged out!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menu.OptionReset();
                    LoggedInAccount.LogOut();
                    Program.Main(); //new string[] { }
                }),
                new MenuOption("Exit", () =>
                {
                    Environment.Exit(0);
                })
            };

            return newMenuOptions;
        }

        public static List<MenuOption> CatalogMain()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            int lastpage = CatalogPage.festivalArray.Length / 5;

            if (CatalogPage.currentPage == lastpage)
            {
                for (int i = 0; i < CatalogPage.festivalArray.Length % 5; i++)
                {
                    newMenuOptions.Add(new MenuOption($"Select festival: {CatalogPage.festivalArray[i + CatalogPage.currentPage * 5].FestivalName}", () =>
                    {
                        Console.Clear();
                        SelectedFestival.festival = CatalogPage.festivalArray[i];
                        Festival.PageManager.Display(CatalogPage.festivalArray[i].FestivalID);
                    }));
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    newMenuOptions.Add(new MenuOption($"Select festival: {CatalogPage.festivalArray[i].FestivalName}", () =>
                    {
                        Console.Clear();
                        SelectedFestival.festival = CatalogPage.festivalArray[i];
                        Festival.PageManager.Display(CatalogPage.festivalArray[i].FestivalID);
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption("Next page", () =>
            {
                if (CatalogPage.currentPage * 5 + 5 < CatalogPage.festivalArray.Length)
                {
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.currentPage++;
                }
            }));
            newMenuOptions.Add(new MenuOption("Previous page", () =>
            {
                if (CatalogPage.currentPage > 0)
                {
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.currentPage--;
                }
            }));
            newMenuOptions.Add(new MenuOption("Filter festivals", () =>
            {
                CatalogPage.currentCatalogNavigation = "filter";
                Console.Clear();
            }));
            newMenuOptions.Add(new MenuOption("Exit to main menu", () =>
            {
                Console.Clear();
                Program.Main();
            }));

            return newMenuOptions;
        }

        public static List<MenuOption> CatalogFilter()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Sort by name", () =>
                {
                    CatalogPage.festivalArray = SortingFunctions.SortName(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by date", () =>
                {
                    CatalogPage.festivalArray = SortingFunctions.SortDate(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by price", () =>
                {
                    CatalogPage.festivalArray = SortingFunctions.SortPrice(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by availability", () =>
                {
                    CatalogPage.festivalArray = SortingFunctions.SortAvailability(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by name", () =>
                {
                    string namesearch = Console.ReadLine();
                    CatalogPage.festivalArray = FilterFunctions.FilterName(CatalogPage.festivalArray, namesearch);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by genre", () =>
                {
                    CatalogPage.festivalArray = FilterFunctions.FilterGenre(CatalogPage.festivalArray, Console.ReadLine());
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by loctaion", () =>
                {
                    CatalogPage.festivalArray = FilterFunctions.FilterLocation(CatalogPage.festivalArray, Console.ReadLine());
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Clear by filters", () =>
                {
                    CatalogPage.festivalArray = JSONFunctionality.GetFestivals().Festivals.ToArray();
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Return to catalog", () =>
                {
                    CatalogPage.currentCatalogNavigation = "main";
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                })
            };
            return newMenuOptions;
        }

        public static List<MenuOption> ChangeFestival(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption($"Festival name: {festival.FestivalName}", () =>
                {
                    Console.Clear();
                    do { festival.FestivalName = FestivalRegister.InputLoop("Fill in the name of the festival: "); }
                    while (!RegexUtils.IsValidName(festival.FestivalName));
                }),
                new MenuOption($"Festival date: {festival.FestivalDate.ToShortDateString()}", () =>
                {
                    string tempDay;
                    string tempMonth;
                    string tempYear;
                    Console.Clear();
                    Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
                    do { tempDay = FestivalRegister.InputLoop("Fill in the day: "); }
                    while (!RegexUtils.IsValidDay(tempDay));
                    do { tempMonth = FestivalRegister.InputLoop("Fill in the month: "); }
                    while (!RegexUtils.IsValidMonth(tempMonth));
                    do { tempYear = FestivalRegister.InputLoop("Fill in the year: "); }
                    while (!RegexUtils.IsValidFestivalYear(tempYear));
                    festival.FestivalDate = new DateTime(int.Parse(tempYear), int.Parse(tempMonth), int.Parse(tempDay));
                }),
                new MenuOption($"Starting time: {festival.FestivalStartingTime.ToShortTimeString()}", () =>
                {
                    //TODO
                }),
                new MenuOption($"End time {festival.FestivalStartingTime.ToShortTimeString()}", () =>
                {
                    //TODO
                }),
                new MenuOption($"Festival address: {festival.FestivalLocation}", () =>
                {
                    //TODO
                }),
                new MenuOption($"Festival description: {festival.SetDescriptionLength(50)}", () =>
                {
                    //TODO
                }),
                new MenuOption($"Age restriction: {festival.FestivalAgeRestriction}", () =>
                {
                    //TODO
                }),
                new MenuOption($"Festival genre {festival.FestivalGenre}", () =>
                {
                    //TODO
                }),
                new MenuOption($"Cancel time: {festival.FestivalCancelTime}", () =>
                {
                    //TODO
                }),
                new MenuOption("Tickets", () =>
                {
                    //TODO
                }),               
                new MenuOption("Save festival", () =>
                {
                    //TODO
                }),
                new MenuOption("Cancel festival modification", () =>
                {
                    //TODO
                }),
            };
            return newMenuOptions;
        }
    }
}