﻿using Festivity.FestivalPage;
using Festivity.Festival;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class CatalogMainMenu : MenuBuilder
    {
        public List<MenuOption> CatalogMainMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            int lastpage = CatalogPage.FestivalArray.Length / 5;

            if (CatalogPage.CurrentPage == lastpage)
            {
                for (int i = 0; i < CatalogPage.FestivalArray.Length % 5; i++)
                {
                    newMenuOptions.Add(new MenuOption($"Select festival: {CatalogPage.FestivalArray[i + CatalogPage.CurrentPage * 5].FestivalName}", () =>
                    {
                        Console.Clear();
                        SelectedFestival.Festival = CatalogPage.FestivalArray[Menu.Option + 5 * CatalogPage.CurrentPage];
                        Menu.OptionReset();
                        FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
                    }));
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    newMenuOptions.Add(new MenuOption($"Select festival: {CatalogPage.FestivalArray[i].FestivalName}", () =>
                    {
                        Console.Clear();
                        SelectedFestival.Festival = CatalogPage.FestivalArray[Menu.Option + 5 * CatalogPage.CurrentPage];
                        Menu.OptionReset();
                        FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption("Next page", () =>
            {
                if (CatalogPage.CurrentPage * 5 + 5 < CatalogPage.FestivalArray.Length)
                {
                    Menu.OptionReset();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CurrentPage++;
                }
            }));
            newMenuOptions.Add(new MenuOption("Previous page", () =>
            {
                if (CatalogPage.CurrentPage > 0)
                {
                    Menu.OptionReset();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CurrentPage--;
                }
            }));
            newMenuOptions.Add(new MenuOption("Filter festivals", () =>
            {
                Menu.OptionReset();
                CatalogPage.CurrentCatalogNavigation = "filter";
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
    }
}