using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    class MenuBuilder
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

        public static List<MenuOption> FestivalRegisterMenu()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Festival Name", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Festival Name";
                }),
                new MenuOption("Festival Date", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Festival Date";
                }),
                new MenuOption("Starting Time", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Starting Time";
                }),
                new MenuOption("End Time", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "End Time";
                }),
                new MenuOption("Festival Adress", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Festival Adress";
                }),
                new MenuOption("Festival Description", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Festival Description";
                }),
                new MenuOption("Age Restriction", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Age Restriction";
                }),
                new MenuOption("Festival Genre", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Festival Genre";
                }),
                new MenuOption("Cancel Time", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Cancel Time";
                }),
                new MenuOption("Tickets", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Tickets";
                }),
                new MenuOption("Save Festival", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Save Festival";
                }),
                new MenuOption("Cancel Festival Registration", () =>
                {
                    Console.Clear();
                    FestivalRegister.currentRegisterSelection = "Cancel Festival Registration";
                })
            };

            return newMenuOptions;
        }

        public static List<MenuOption> GenreMenu()
        {
            // Create List of menu options
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Techno", () =>
                {
                    Console.Clear();
                    FestivalRegister.festivalGenre = "Techno";
                    FestivalRegister.currentRegisterSelection = "Main";
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    FestivalRegister.festivalGenre = "Drum & Bass";
                    FestivalRegister.currentRegisterSelection = "Main";
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    FestivalRegister.festivalGenre = "Pop";
                    FestivalRegister.currentRegisterSelection = "Main";
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    FestivalRegister.festivalGenre = "Rock";
                    FestivalRegister.currentRegisterSelection = "Main";
                }),
                new MenuOption("Hip-Hop", () =>
                {
                    Console.Clear();
                    FestivalRegister.festivalGenre = "Hip-Hop";
                    FestivalRegister.currentRegisterSelection = "Main";
                }),
            };

            return newMenuOptions;
        }
    }
}
