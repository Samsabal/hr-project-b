using System;
using System.Collections.Generic;
using System.Threading;

namespace Festivity
{
    internal class Program
    {
        public static void Main()
        {
            //string[] args
            Console.Clear();
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.SetWindowSize(150, 36);
                if (!LoggedInAccount.IsLoggedIn())
                {
                    Menu.Draw(MainMenu());
                }
                if (LoggedInAccount.IsLoggedIn())
                {
                    if (LoggedInAccount.User.AccountType == 2)
                    {
                        Menu.Draw(MainMenuUser());
                    }
                    if (LoggedInAccount.User.AccountType == 1)
                    {
                        Menu.Draw(MainMenuOrganiser());
                    }
                }
            }
        }

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

    }
}