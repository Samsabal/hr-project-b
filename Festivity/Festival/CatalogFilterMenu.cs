using Festivity.Utils;
using Festivity.Festival;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal static class CatalogFilterMenu
    {
        public static List<MenuOption> CatalogFilterMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Sort by name", () =>
                {
                    CatalogPage.FestivalArray = SortingFunctions.SortName(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Sort by date", () =>
                {
                    CatalogPage.FestivalArray = SortingFunctions.SortDate(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Sort by price", () =>
                {
                    CatalogPage.FestivalArray = SortingFunctions.SortPrice(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Sort by availability", () =>
                {
                    CatalogPage.FestivalArray = SortingFunctions.SortAvailability(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Filter by name", () =>
                {
                    string namesearch = Console.ReadLine();
                    CatalogPage.FestivalArray = FilterFunctions.FilterName(CatalogPage.FestivalArray, namesearch);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Filter by genre", () =>
                {
                    CatalogPage.FestivalArray = FilterFunctions.FilterGenre(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Filter by loctaion", () =>
                {
                    CatalogPage.FestivalArray = FilterFunctions.FilterLocation(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Clear by filters", () =>
                {
                    CatalogPage.FestivalArray = JSONFunctions.GetFestivals().Festivals.ToArray();
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                }),
                new MenuOption("Return to catalog", () =>
                {
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogSetup();
                    CatalogPage.CatalogMain();
                })
            };
            return newMenuOptions;
        }
    }
}