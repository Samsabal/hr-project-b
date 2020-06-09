using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalGenreMenu
    {
        public List<MenuOption> GenreMenuBuilder(FestivalModel festival)
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
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Drum & Bass");
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Pop");
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Rock");
                }),
                new MenuOption("Hip-Hop", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Hip-Hop");
                }),
            };
            return newMenuOptions;
        }
    }
}