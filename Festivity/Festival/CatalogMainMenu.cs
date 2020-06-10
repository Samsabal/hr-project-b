using Festivity.Festival;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class CatalogMainMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> CatalogMainMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            int lastpage = CatalogPage.FestivalArray.Length / CatalogPage.FestivalsPerPage;

            if (CatalogPage.CurrentPage == lastpage)
            {
                for (int i = 0; i < CatalogPage.FestivalArray.Length % CatalogPage.FestivalsPerPage; i++)
                {
                    newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle($". Select festival: {CatalogPage.FestivalArray[i + CatalogPage.CurrentPage * CatalogPage.FestivalsPerPage].FestivalName} ."), () =>
                    {
                        Console.Clear();
                        SelectedFestival.Festival = CatalogPage.FestivalArray[Menu.Option + CatalogPage.FestivalsPerPage * CatalogPage.CurrentPage];
                        Menu.OptionReset();
                        FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
                    }));
                }
            }
            else
            {
                for (int i = 0; i < CatalogPage.FestivalsPerPage; i++)
                {
                    newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle($". Select festival: {CatalogPage.FestivalArray[i + CatalogPage.CurrentPage * CatalogPage.FestivalsPerPage].FestivalName} ."), () =>
                    {
                        Console.Clear();
                        SelectedFestival.Festival = CatalogPage.FestivalArray[Menu.Option + CatalogPage.FestivalsPerPage * CatalogPage.CurrentPage];
                        Menu.OptionReset();
                        FestivalPage.Handler.Display(SelectedFestival.Festival.FestivalID);
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Next page ."), () =>
            {
                if ((CatalogPage.CurrentPage + 1) * CatalogPage.FestivalsPerPage < CatalogPage.FestivalArray.Length)
                {
                    Menu.OptionReset();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CurrentPage++;
                }
            }));
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Previous page ."), () =>
            {
                if (CatalogPage.CurrentPage > 0)
                {
                    Menu.OptionReset();
                    ConsoleHelperFunctions.ClearCurrentConsole();
                    CatalogPage.CurrentPage--;
                }
            }));
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Filter festivals ."), () =>
            {
                Menu.OptionReset();
                CatalogPage.CurrentCatalogNavigation = "filter";
                Console.Clear();
            }));
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Exit to main menu ."), () =>
            {
                Menu.OptionReset();
                Console.Clear();
                Program.Main();
            }));

            return newMenuOptions;
        }
    }
}