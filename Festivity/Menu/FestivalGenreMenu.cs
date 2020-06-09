using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalGenreMenu : MenuBuilder
    {
        public List<MenuOption> GenreMenuBuilder(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Techno", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Techno");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Drum & Bass");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Pop");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Rock");
                    RegisterHandler.ShowFestivalRegister(festival);
                }),
                new MenuOption("Hip-Hop", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Hip-Hop");
                    RegisterHandler.ShowFestivalRegister(festival);
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
                    Modifier.SetFestivalGenre(festival, "Techno");
                    Loop = false;
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Drum & Bass");
                    Loop = false;
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Pop");
                    Loop = false;
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Rock");
                    Loop = false;
                }),
                new MenuOption("Hip-Hop", () =>
                {
                    Console.Clear();
                    Modifier.SetFestivalGenre(festival, "Hip-Hop");
                    Loop = false;
                }),
            };
            return newMenuOptions;
        }
    }
}