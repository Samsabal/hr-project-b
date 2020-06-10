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

        public List<MenuOption> GenreMenuModify(FestivalModel festival)
        {
            void ChangeFestivalMenu(){
                do { Menu.Draw(new FestivalMenus().ChangeFestival(festival)); }
                while (Menu.IsLooping);
            }

            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("Techno", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Techno");
                    ChangeFestivalMenu();
                }),
                new MenuOption("Drum & Bass", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Drum & Bass");
                    ChangeFestivalMenu();
                }),
                new MenuOption("Pop", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Pop");
                    ChangeFestivalMenu();
                }),
                new MenuOption("Rock", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Rock");
                    ChangeFestivalMenu();
                }),
                new MenuOption("Hip-Hop", () =>
                {
                    Console.Clear();
                    FestivalReader.SetFestivalGenre(festival, "Hip-Hop");
                    ChangeFestivalMenu();
                }),
            };
            return newMenuOptions;
        }
    }
}