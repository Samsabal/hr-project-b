using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class FestivalGenreMenu : MenuBuilder
    {
        public static List<MenuOption> GenreMenuBuilder(FestivalModel festival)
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
    }
}
