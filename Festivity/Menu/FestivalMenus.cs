using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    class FestivalMenus : MenuBuilder
    {
        public static List<MenuOption> SelectFestival()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();

            foreach (FestivalModel festival in festivals.Festivals)
            {
                if (LoggedInAccount.GetID() == festival.FestivalOrganiserID)
                {
                    newMenuOptions.Add(new MenuOption($"Edit festival: {festival.FestivalName}", () =>
                    {
                        Menu.OptionReset();
                        Console.Clear();
                        do { Menu.Draw(ChangeFestival(festival)); }
                        while (Loop);
                        Loop = true;
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption("Return to main menu: ", () =>
            {
                Console.Clear();
                Loop = false;
            }));
            return newMenuOptions;
        }

        public static List<MenuOption> ChangeFestival(FestivalModel festival)
        {
            int currentValueStartingPoint = 30;
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption($"Festival name:".PadRight(currentValueStartingPoint) + $"{festival.FestivalName}", () =>
                {
                    Console.Clear();
                    Modifier.InputFestivalName(festival);
                }),
                new MenuOption($"Festival date:".PadRight(currentValueStartingPoint) + $"{festival.FestivalDate.ToShortDateString()}", () =>
                {
                    Console.Clear();
                    Modifier.InputFestivalDate(festival);
                }),
                new MenuOption($"Starting time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalStartingTime.ToShortTimeString()}", () =>
                {
                    Console.Clear();
                    Modifier.InputStartingTime(festival);
                }),
                new MenuOption($"End time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalEndTime.ToShortTimeString()}", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Modifier.InputEndTime(festival);
                }),
                new MenuOption($"Festival address:".PadRight(currentValueStartingPoint) + $"{festival.FestivalLocation}", () =>
                {
                    Console.Clear();
                    Modifier.InputFestivalAdress(festival);
                }),
                new MenuOption($"Festival description:".PadRight(currentValueStartingPoint) + $"{festival.SetDescriptionLength(50)}", () =>
                {
                    Console.Clear();
                    Modifier.ModifyFestivalDescription(festival);
                }),
                new MenuOption($"Age restriction:".PadRight(currentValueStartingPoint) + $"{festival.FestivalAgeRestriction}", () =>
                {
                    Console.Clear();
                    Modifier.ModifyFestivalAgeRestriction(festival);
                }),
                new MenuOption($"Festival genre:".PadRight(currentValueStartingPoint) + $"{festival.FestivalGenre}", () =>
                {
                    Console.Clear();
                    Loop = true;
                    do {Menu.Draw(FestivalGenreMenu.GenreMenuModify(festival)); }
                    while(Loop);
                    Loop = true;
                }),
                new MenuOption($"Cancel time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalCancelTime}", () =>
                {
                    Console.Clear();
                    Modifier.InputCancelTime(festival);
                }),
                new MenuOption("Tickets", () =>
                {
                    Console.Clear();
                    Loop = true;
                    do { Menu.Draw(TicketMenus.SelectTicket(festival)); }
                    while(Loop);
                    Loop = true;
                }),
                new MenuOption("Save festival", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    JSONFunctionality.UpdateFestival(festival);
                    festival.FestivalStatus = "Changed";
                    Loop = false;
                }),
                new MenuOption("Cancel festival modification", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Loop = false;
                }),
            };
            return newMenuOptions;
        }


    }
}
