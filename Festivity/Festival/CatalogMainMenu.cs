using Festivity.Festival;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class CatalogMainMenu
    {
        public List<MenuOption> CatalogMainMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            int lastpage = CatalogPage.FestivalArray.Length / 5;

            if (CatalogPage.CurrentPage == lastpage)
            {
                FestivalModel[] smallArray = CatalogPage.FestivalArray[(CatalogPage.CurrentPage * 5)..(CatalogPage.CurrentPage * 5 + CatalogPage.FestivalArray.Length % 5)];
                foreach (FestivalModel f in smallArray)
                {
                    newMenuOptions.Add(new MenuOption($"Select festival: {f.FestivalName}", () =>
                    {
                        Console.Clear();
                        SelectedFestival.Festival = f;
                        FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
                    }));
                }
            }
            else
            {
                FestivalModel[] smallArray = CatalogPage.FestivalArray[(CatalogPage.CurrentPage * 5)..(CatalogPage.CurrentPage * 5 + 5)];
                foreach (FestivalModel f in smallArray)
                {
                    newMenuOptions.Add(new MenuOption($"Select festival: {f.FestivalName}", () =>
                    {
                        Console.Clear();
                        SelectedFestival.Festival = f;
                        FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption("Next page", () =>
            {
                if (CatalogPage.CurrentPage * 5 + 5 < CatalogPage.FestivalArray.Length)
                {
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CurrentPage++;
                }
            }));
            newMenuOptions.Add(new MenuOption("Previous page", () =>
            {
                if (CatalogPage.CurrentPage > 0)
                {
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CurrentPage--;
                }
            }));
            newMenuOptions.Add(new MenuOption("Filter festivals", () =>
            {
                CatalogPage.CurrentCatalogNavigation = "filter";
                Console.Clear();
            }));
            newMenuOptions.Add(new MenuOption("Exit to main menu", () =>
            {
                Console.Clear();
                Program.Main();
            }));

            return newMenuOptions;
        }
    }
}