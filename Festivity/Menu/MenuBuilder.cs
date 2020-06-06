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
                    UserRegisterPage.CreateUser();
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
                    Menu.option = 0;
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
                    Menu.option = 0;
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
                    Menu.option = 0;
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
                        CatalogPage.selectedFestival = CatalogPage.festivalArray[i].FestivalID;
                        FestivalPage.ShowFestivalPage(CatalogPage.festivalArray[i].FestivalID);
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
                        CatalogPage.selectedFestival = CatalogPage.festivalArray[i].FestivalID;
                        FestivalPage.ShowFestivalPage(CatalogPage.festivalArray[i].FestivalID);
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
    }
}