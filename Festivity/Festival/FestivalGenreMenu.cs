using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalGenreMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> GenreMenuBuilder(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Techno ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Techno");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Drum & Bass ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Drum & Bass");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Pop ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Pop");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Rock ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Rock");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Hip-Hop ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Hip-Hop");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
            };

            return newMenuOptions;
        }

        public static List<MenuOption> GenreMenuModify(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Techno ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Techno");
                    Loop = false;
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Drum & Bass ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Drum & Bass");
                    Loop = false;
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Pop ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Pop");
                    Loop = false;
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Rock ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Rock");
                    Loop = false;
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Hip-Hop ."), () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Hip-Hop");
                    Loop = false;
                }),
            };
            return newMenuOptions;
        }
    }
}