using Festivity.Utils;
using Festivity.Festival;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class CatalogFilterMenu : MenuBuilder
    {
        public List<MenuOption> CatalogFilterMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Sort by name", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortName(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by date", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortDate(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by price", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortPrice(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Sort by availability", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortAvailability(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by name", () =>
                {
                    Menu.OptionReset();
                    string namesearch = Console.ReadLine();
                    CatalogPage.FestivalArray = FilterFunctions.FilterName(CatalogPage.FestivalArray, namesearch);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by genre", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = FilterFunctions.FilterGenre(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Filter by loctaion", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = FilterFunctions.FilterLocation(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Clear by filters", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = JSONFunctions.GetFestivals().Festivals.ToArray();
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    ConsoleHelperFunctions.ClearCurrentConsole();
                }),
                new MenuOption("Return to catalog", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.CurrentCatalogNavigation = "main";
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CatalogMain();
                })
            };
            return newMenuOptions;
        }
    }
}