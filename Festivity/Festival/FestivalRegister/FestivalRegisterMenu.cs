using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalRegisterMenu : MenuBuilder
    {
        public static List<TicketModel> savedTicketList = new List<TicketModel>();

        public List<MenuOption> FestivalRegisterMenuBuilder(FestivalModel festival)
        {
            int PadRightValue = 30;
            int PadLeftValue = 38;
            JSONFestivalList festivalList = JSONFunctions.GetFestivals();
            JSONTicketList ticketList = JSONFunctions.GetTickets();

            List<MenuOption> newMenuOptions = new List<MenuOption>
                {
                    new MenuOption(" Name:".PadRight(PadRightValue) + $"{festival.FestivalName}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputFestivalName(festival);
                    }),
                    new MenuOption(" Date:".PadRight(PadRightValue) + $"{festival.FestivalDate.ToShortDateString()}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputFestivalDate(festival);
                        FestivalReader.ModifyUpdateDateByTime(festival);
                    }),
                    new MenuOption(" Starting Time:".PadRight(PadRightValue) + $"{festival.FestivalStartingTime}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputStartingTime(festival);
                    }),
                    new MenuOption("End Time:".PadRight(PadRightValue) + $"{festival.FestivalEndTime}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputEndTime(festival);
                    }),
                    new MenuOption(" Adress: ".PadRight(PadRightValue-20) + $"{festival.FestivalLocation}".PadLeft(PadLeftValue+20), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputFestivalAdress(festival);
                    }),
                    new MenuOption(" Description".PadRight(PadRightValue) + $"{festival.FestivalDescription}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.ModifyFestivalDescription(festival);
                    }),
                    new MenuOption(" Age Restriction".PadRight(PadRightValue) + $"{festival.FestivalAgeRestriction}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.ModifyFestivalAgeRestriction(festival);
                    }),
                    new MenuOption(" Genre".PadRight(PadRightValue) + $"{festival.FestivalGenre}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputGenre(festival);
                    }),
                    new MenuOption(" Cancel Time".PadRight(PadRightValue) + $"{festival.FestivalCancelTime}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        FestivalReader.InputCancelTime(festival);
                    }),
                    new MenuOption(" Tickets\n".PadRight(PadRightValue), () =>
                    {
                        Console.Clear();
                        savedTicketList = FestivalReader.InputFestivalTickets(savedTicketList);
                    }),
                    new MenuOption(" Save Festival", () =>
                    {
                        Console.Clear();
                        foreach (TicketModel ticket in savedTicketList)
                        {
                            ticketList.Tickets.Add(ticket);
                        }
                        JSONFunctions.WriteTickets(ticketList);

                        festivalList.Festivals.Add(festival);
                        JSONFunctions.WriteFestivals(festivalList);
                        Menu.OptionReset();
                        Program.Main();
                    }),
                    new MenuOption(" Cancel Festival Registration\n", () =>
                    {
                        Console.Clear();
                        Menu.OptionReset();
                        Program.Main();
                    })
                };

            return newMenuOptions;
        }
    }
}