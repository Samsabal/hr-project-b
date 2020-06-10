using Festivity.FestivalRegister;
using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalMenus : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> SelectFestival()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            JSONFestivalList festivals = JSONFunctions.GetFestivals();

            foreach (FestivalModel festival in festivals.Festivals)
            {
                if (LoggedInModel.GetID() == festival.FestivalOrganiserID)
                {
                    newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle($". Edit festival: {festival.FestivalName} ."), () =>
                    {
                        Menu.OptionReset();
                        Console.Clear();
                        do { Menu.Draw(ChangeFestival(festival)); }
                        while (Loop);
                        Loop = true;
                    }));
                }
            }
            newMenuOptions.Add(new MenuOption(UI.SpaceStringInMiddle(". Return to main menu ."), () =>
            {
                Console.Clear();
                Loop = false;
            }));
            return newMenuOptions;
        }

        public List<MenuOption> ChangeFestival(FestivalModel festival)
        {
            int PadRightValue = 30;
            int PadLeftValue = 38;
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption($" Name:".PadRight(PadRightValue) + $"{festival.FestivalName}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.InputFestivalName(festival);
                }),
                new MenuOption($" Date:".PadRight(PadRightValue) + $"{festival.FestivalDate.ToShortDateString()}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.InputFestivalDate(festival);
                }),
                new MenuOption($" Starting time:".PadRight(PadRightValue) + $"{festival.FestivalStartingTime.ToShortTimeString()}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.InputStartingTime(festival);
                }),
                new MenuOption($" End time:".PadRight(PadRightValue) + $"{festival.FestivalEndTime.ToShortTimeString()}".PadLeft(PadLeftValue), () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    FestivalReader.InputEndTime(festival);
                }),
                new MenuOption($" Address:".PadRight(PadRightValue) + $"{festival.FestivalLocation}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.InputFestivalAdress(festival);
                }),
                new MenuOption($" Description:".PadRight(PadRightValue) + $"{festival.SetDescriptionLength(50)}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.ModifyFestivalDescription(festival);
                }),
                new MenuOption($" Age restriction:".PadRight(PadRightValue) + $"{festival.FestivalAgeRestriction}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.ModifyFestivalAgeRestriction(festival);
                }),
                new MenuOption($" Genre:".PadRight(PadRightValue) + $"{festival.FestivalGenre}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Loop = true;
                    do {Menu.Draw(FestivalGenreMenu.GenreMenuModify(festival)); }
                    while(Loop);
                    Loop = true;
                }),
                new MenuOption($" Cancel time:".PadRight(PadRightValue) + $"{festival.FestivalCancelTime}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    FestivalReader.InputCancelTime(festival);
                }),
                new MenuOption(" Tickets", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    Loop = true;
                    do { Menu.Draw(new TicketMenus().SelectTicket(festival)); }
                    while(Loop);
                    Loop = true;
                }),
                new MenuOption("\n Save changes", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    JSONFunctions.UpdateFestival(festival);
                    festival.FestivalStatus = " Changed";
                    Loop = false;
                }),
                new MenuOption(" Cancel", () =>
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