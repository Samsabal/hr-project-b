﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity
{
    class MenuFunction
    {

        public static int option;

        public static void menu(string[] consoleOptions, Festival[] festivals = null)
        {
            /// 1. Add your option as string in consoleOptions argument.
            /// 2. Add your extra "option" as a new case inside the switch statement with the correct function.
            
            Console.CursorVisible = false;
            
            if (festivals == null)
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

            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
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
                    case "Register": // Register option
                        Console.Clear();
                        UserRegisterPage.register_page();
                        break;
                    case "Login": // Login option
                        Console.Clear();
                        UserLoginPage.login_page();
                        break;
                    case "Festivals": // Festival option
                        Console.Clear();
                        CatalogPage.catalog_main();
                        Thread.Sleep(1000);
                        break;
                    case "Register festival": // Festival register
                        Console.Clear();
                        FestivalRegister.festival_register();
                        Thread.Sleep(1000);
                        break;
                    case "Exit": // Exit option
                        Environment.Exit(0);
                        Console.Clear();
                        break;
                    case "Festival Page":
                        Console.Clear();
                        FestivalPage.festival_page(1);
                        Thread.Sleep(1000);
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
                    case "Exit to Main Menu":
                        Console.Clear();
                        Program.Main(new string[] { });
                        break;
                    case "festival1":
                        if (festivals[0].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festivals[0].festivalId);
                        }
                        break;
                    case "festival2":
                        if (festivals[1].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festivals[1].festivalId);
                        }
                        break;
                    case "festival3":
                        if (festivals[2].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festivals[2].festivalId);
                        }
                        break;
                    case "festival4":
                        if (festivals[3].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
                            FestivalPage.festival_page(festivals[3].festivalId);
                        }
                        break;
                    case "festival5":
                        if (festivals[4].festivalId != -1)
                        {
                            Console.Clear();
                            CatalogPage.activeScreen = false;
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
                        break;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
