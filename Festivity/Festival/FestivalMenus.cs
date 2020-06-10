using Festivity.FestivalRegister;
using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalMenus
    {
        public List<MenuOption> SelectFestival()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            JSONFestivalList festivals = JSONFunctions.GetFestivals();

            foreach (FestivalModel festival in festivals.Festivals)
            {
                if (LoggedInModel.GetID() == festival.FestivalOrganiserID)
                {
                    newMenuOptions.Add(new MenuOption($"Edit festival: {festival.FestivalName}", () =>
                    {
                        Console.Clear();
                        do { Menu.Draw(ChangeFestival(festival)); }
                        while (Menu.IsLooping);
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption("Return to main menu", () =>
            {
                Console.Clear();
                Program.Main();
            }));
            return newMenuOptions;
        }

        public List<MenuOption> ChangeFestival(FestivalModel festival)
        {
            int currentValueStartingPoint = 30;
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption($"Festival name:".PadRight(currentValueStartingPoint) + $"{festival.FestivalName}", () =>
                {
                    Console.Clear();
                    FestivalReader.InputFestivalName(festival);
                }),
                new MenuOption($"Festival date:".PadRight(currentValueStartingPoint) + $"{festival.FestivalDate.ToShortDateString()}", () =>
                {
                    Console.Clear();
                    FestivalReader.InputFestivalDate(festival);
                }),
                new MenuOption($"Starting time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalStartingTime.ToShortTimeString()}", () =>
                {
                    Console.Clear();
                    FestivalReader.InputStartingTime(festival);
                }),
                new MenuOption($"End time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalEndTime.ToShortTimeString()}", () =>
                {
                    Console.Clear();
                    FestivalReader.InputEndTime(festival);
                }),
                new MenuOption($"Festival address:".PadRight(currentValueStartingPoint) + $"{festival.FestivalLocation}", () =>
                {
                    Console.Clear();
                    FestivalReader.InputFestivalAdress(festival);
                }),
                new MenuOption($"Festival description:".PadRight(currentValueStartingPoint) + $"{festival.SetDescriptionLength(50)}", () =>
                {
                    Console.Clear();
                    FestivalReader.ModifyFestivalDescription(festival);
                }),
                new MenuOption($"Age restriction:".PadRight(currentValueStartingPoint) + $"{festival.FestivalAgeRestriction}", () =>
                {
                    Console.Clear();
                    FestivalReader.ModifyFestivalAgeRestriction(festival);
                }),
                new MenuOption($"Festival genre:".PadRight(currentValueStartingPoint) + $"{festival.FestivalGenre}", () =>
                {
                    Console.Clear();
                    do {Menu.Draw(new FestivalGenreMenu().GenreMenuModify(festival)); }
                    while(Menu.IsLooping);
                }),
                new MenuOption($"Cancel time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalCancelTime}", () =>
                {
                    Console.Clear();
                    FestivalReader.InputCancelTime(festival);
                }),
                new MenuOption("Tickets", () =>
                {
                    Console.Clear();
                    do { Menu.Draw(new TicketMenus().SelectTicket(festival)); }
                    while(Menu.IsLooping);
                }),
                new MenuOption("\nSave changes", () =>
                {
                    Console.Clear();
                    JSONFunctions.UpdateFestival(festival);
                    festival.FestivalStatus = "Changed";
                }),
                new MenuOption("Cancel", () =>
                {
                    Console.Clear();
                    Program.Main();
                }),
            };
            return newMenuOptions;
        }
    }
}