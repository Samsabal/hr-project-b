using Festivity.FestivalRegister;
using Festivity.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class MenuBuilder
    {
        public static List<Ticket> savedTicketList = new List<Ticket>();
        public static List<MenuOption> MainMenu()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Register", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountRegistration.Manager.InitateUserRegistration();
                }),
                new MenuOption("Login", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountLogin.LoginManager.InitiateLoginPage();
                }),
                new MenuOption("Festivals", () =>
                {
                    Menu.OptionReset();
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
                    Menu.OptionReset();
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("My Account", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Manager.DrawPage();
                }),
                new MenuOption("My Tickets", () =>
                {
                    Menu.OptionReset();
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
                    Menu.OptionReset();
                    Console.Clear();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Register Festivals", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    FestivalModel festival = new FestivalModel { FestivalID = RegisterHandler.SetFestivalId(JSONFunctionality.GetFestivals()) };
                    RegisterHandler.ActiveScreen = true;
                    RegisterHandler.InitiateFestivalRegister(festival);
                }),
                new MenuOption("My Account", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    AccountPage.Manager.DrawPage();
                }),
                new MenuOption("My Tickets", () =>
                {
                    Menu.OptionReset();
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
                    Program.Main();
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
                        Menu.OptionReset();
                        Console.Clear();
                        SelectedFestival.festival = CatalogPage.festivalArray[Menu.Option + CatalogPage.currentPage * 5];
                        Festival.PageManager.Display(SelectedFestival.festival.FestivalID);
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
                        SelectedFestival.festival = CatalogPage.festivalArray[Menu.Option + CatalogPage.currentPage * 5];
                        Festival.PageManager.Display(SelectedFestival.festival.FestivalID);
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption("Next page", () =>
            {
                if (CatalogPage.currentPage * 5 + 5 < CatalogPage.festivalArray.Length)
                {
                    Menu.OptionReset();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.currentPage++;
                }
            }));
            newMenuOptions.Add(new MenuOption("Previous page", () =>
            {
                if (CatalogPage.currentPage > 0)
                {
                    Menu.OptionReset();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.currentPage--;
                }
            }));
            newMenuOptions.Add(new MenuOption("Filter festivals", () =>
            {
                Menu.OptionReset();
                CatalogPage.currentCatalogNavigation = "filter";
                Console.Clear();
            }));
            newMenuOptions.Add(new MenuOption("Exit to main menu", () =>
            {
                Menu.OptionReset();
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
                    Menu.OptionReset();
                    CatalogPage.festivalArray = SortingFunctions.SortName(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by date", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.festivalArray = SortingFunctions.SortDate(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by price", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.festivalArray = SortingFunctions.SortPrice(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by availability", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.festivalArray = SortingFunctions.SortAvailability(CatalogPage.festivalArray);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by name", () =>
                {
                    Menu.OptionReset();
                    string namesearch = Console.ReadLine();
                    CatalogPage.festivalArray = FilterFunctions.FilterName(CatalogPage.festivalArray, namesearch);
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by genre", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.festivalArray = FilterFunctions.FilterGenre(CatalogPage.festivalArray, Console.ReadLine());
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by loctaion", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.festivalArray = FilterFunctions.FilterLocation(CatalogPage.festivalArray, Console.ReadLine());
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Clear by filters", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.festivalArray = JSONFunctionality.GetFestivals().Festivals.ToArray();
                    CatalogPage.currentCatalogNavigation = "main";
                    CatalogPage.currentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Return to catalog", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.currentCatalogNavigation = "main";
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                })
            };
            return newMenuOptions;
        }

        public static List<MenuOption> FestivalRegisterMenu(FestivalModel festival)
        {
            int currentValueStartingPoint = 30;

            JSONFestivalList festivalList = JSONFunctionality.GetFestivals();
            JSONTicketList ticketList = JSONFunctionality.GetTickets();

            List<MenuOption> newMenuOptions = new List<MenuOption>
                {
                    new MenuOption("Festival Name:".PadRight(currentValueStartingPoint) + $"{festival.FestivalName}", () =>
                    {
                        Console.Clear();
                        Modifier.InputFestivalName(festival);
                    }),
                    new MenuOption("Festival Date:".PadRight(currentValueStartingPoint) + $"{festival.FestivalDate.ToShortDateString()}", () =>
                    {
                        Console.Clear();
                        Modifier.InputFestivalDate(festival);
                    }),
                    new MenuOption("Starting Time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalStartingTime}", () =>
                    {
                        Console.Clear();
                        Modifier.InputStartingTime(festival);
                    }),
                    new MenuOption("End Time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalEndTime}", () =>
                    {
                        Console.Clear();
                        Modifier.InputEndTime(festival);
                        if (festival.FestivalEndTime < festival.FestivalStartingTime)
                            {
                                festival.FestivalEndTime.AddDays(1);
                            }
                    }),
                    new MenuOption("Festival Adress: ".PadRight(currentValueStartingPoint) + $"{festival.FestivalLocation}", () =>
                    {
                        Console.Clear();
                        Modifier.InputFestivalAdress(festival);
                    }),
                    new MenuOption("Festival Description".PadRight(currentValueStartingPoint) + $"{festival.FestivalDescription}", () =>
                    {
                        Console.Clear();
                        Modifier.ModifyFestivalDescription(festival);
                    }),
                    new MenuOption("Age Restriction".PadRight(currentValueStartingPoint) + $"{festival.FestivalAgeRestriction}", () =>
                    {
                        Console.Clear();
                        Modifier.ModifyFestivalAgeRestriction(festival);
                    }),
                    new MenuOption("Festival Genre".PadRight(currentValueStartingPoint) + $"{festival.FestivalGenre}", () =>
                    {
                        Console.Clear();
                        Modifier.InputGenre(festival);
                    }),
                    new MenuOption("Cancel Time".PadRight(currentValueStartingPoint) + $"{festival.FestivalCancelTime}", () =>
                    {
                        Console.Clear();
                        Modifier.InputCancelTime(festival);
                    }),
                    new MenuOption("Tickets".PadRight(currentValueStartingPoint), () =>
                    {
                        Console.Clear();
                        savedTicketList = Modifier.InputFestivalTickets(savedTicketList);
                    }),
                    new MenuOption("Save Festival", () =>
                    {
                        Console.Clear();
                        foreach (Ticket ticket in savedTicketList)
                        {
                            ticketList.Tickets.Add(ticket);
                        }
                        JSONFunctionality.WriteTickets(ticketList);

                        festivalList.Festivals.Add(festival);
                        JSONFunctionality.WriteFestivals(festivalList);
                        Program.Main();
                        Menu.OptionReset();
                    }),
                    new MenuOption("Cancel Festival Registration", () =>
                    {
                        Console.Clear();
                        Program.Main();
                        Menu.OptionReset();
                    })
                };

            return newMenuOptions;
        }

        public static List<MenuOption> GenreMenu(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Techno", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Techno");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Drum & Bass");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Pop");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Rock");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Hip-Hop", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Hip-Hop");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
            };
            return newMenuOptions;
        }

        public static List<MenuOption> FestivalPage()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();

            foreach (var ticket in Transaction.TicketListBuilder.Get())
            {
                newMenuOptions.Add(new MenuOption("Buy Ticket: " + ticket.TicketName, () =>
                {
                    if (LoggedInAccount.IsLoggedIn())
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Menu.OptionReset();
                        Console.Clear();
                        Transaction.DisplayManager.Initiate(ticket.TicketID);
                    }
                    else
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        Menu.OptionReset();
                        Console.Clear();
                        AccountLogin.LoginManager.InitateLogin(true);
                    }
                }));
            }
            newMenuOptions.Add(new MenuOption("Return to Catalog", () =>
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Menu.OptionReset();
                Console.Clear();
                CatalogPage.currentCatalogNavigation = "main";
                CatalogPage.CatalogMain();
            }));
            newMenuOptions.Add(new MenuOption("Exit to Main Menu", () =>
            {
                ConsoleHelperFunctions.ClearCurrentConsole();
                Menu.OptionReset();
                Console.Clear();
                Program.Main();
            }));

            return newMenuOptions;
        }
    }
}