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
                    Console.Clear();
                }),
                new MenuOption("Sort by date", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortDate(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    Console.Clear();
                }),
                new MenuOption("Sort by price", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortPrice(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    Console.Clear();
                }),
                new MenuOption("Sort by availability", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = SortingFunctions.SortAvailability(CatalogPage.FestivalArray);
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    Console.Clear();
                }),
                new MenuOption("Filter by name", () =>
                {
                    Menu.OptionReset();
                    Console.Write("\nPlease input the name you want to search for\n");
                    CatalogPage.FestivalArray = FilterFunctions.FilterName(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    Console.Clear();
                }),
                new MenuOption("Filter by genre", () =>
                {
                    Menu.OptionReset();
                    Console.Write("\nPlease input the genre you want to search for\n");
                    CatalogPage.FestivalArray = FilterFunctions.FilterGenre(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    Console.Clear();
                }),
                new MenuOption("Filter by location", () =>
                {
                    Menu.OptionReset();
                    Console.Write("\nPlease input the location you want to search for\n");
                    CatalogPage.FestivalArray = FilterFunctions.FilterLocation(CatalogPage.FestivalArray, Console.ReadLine());
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;                   
                    Console.Clear();
                }),
                new MenuOption("Clear by filters", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.FestivalArray = JSONFunctions.GetFestivals().Festivals.ToArray();
                    CatalogPage.CurrentCatalogNavigation = "main";
                    CatalogPage.CurrentPage = 0;
                    Console.Clear();
                }),
                new MenuOption("Return to catalog", () =>
                {
                    Menu.OptionReset();
                    CatalogPage.CurrentCatalogNavigation = "main";
                    Console.Clear();
                    CatalogPage.CatalogMain();
                })
            };
            return newMenuOptions;
        }
    }
}