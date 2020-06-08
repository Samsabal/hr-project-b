using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class CatalogMainMenu : MenuBuilder
    {
        public static List<MenuOption> CatalogMainMenuBuilder()
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
                        Menu.OptionReset();
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
    }
}
