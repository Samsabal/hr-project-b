using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalGenreMenu : MenuBuilder
    {
        public static List<MenuOption> GenreMenuBuilder(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Techno", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Techno");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Drum & Bass");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Pop");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Rock");
                    FestivalRegister.Handler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Hip-Hop", () =>
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
                new MenuOption("Techno", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Techno");
                    Loop = false;
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Drum & Bass");
                    Loop = false;
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Pop");
                    Loop = false;
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Rock");
                    Loop = false;
                }),
                new MenuOption("Hip-Hop", () =>
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