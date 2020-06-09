using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class FestivalRegisterMenu
    {
        public static List<TicketModel> savedTicketList = new List<TicketModel>();

        public List<MenuOption> FestivalRegisterMenuBuilder(FestivalModel festival)
        {
            int currentValueStartingPoint = 30;

            JSONFestivalList festivalList = JSONFunctions.GetFestivals();
            JSONTicketList ticketList = JSONFunctions.GetTickets();

            List<MenuOption> newMenuOptions = new List<MenuOption>
                {
                    new MenuOption("Festival Name:".PadRight(currentValueStartingPoint) + $"{festival.FestivalName}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputFestivalName(festival);
                    }),
                    new MenuOption("Festival Date:".PadRight(currentValueStartingPoint) + $"{festival.FestivalDate.ToShortDateString()}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputFestivalDate(festival);
                        FestivalReader.ModifyUpdateDateByTime(festival);
                    }),
                    new MenuOption("Starting Time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalStartingTime}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputStartingTime(festival);
                    }),
                    new MenuOption("End Time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalEndTime}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputEndTime(festival);
                    }),
                    new MenuOption("Festival Adress: ".PadRight(currentValueStartingPoint) + $"{festival.FestivalLocation}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputFestivalAdress(festival);
                    }),
                    new MenuOption("Festival Description".PadRight(currentValueStartingPoint) + $"{festival.FestivalDescription}", () =>
                    {
                        Console.Clear();
                        FestivalReader.ModifyFestivalDescription(festival);
                    }),
                    new MenuOption("Age Restriction".PadRight(currentValueStartingPoint) + $"{festival.FestivalAgeRestriction}", () =>
                    {
                        Console.Clear();
                        FestivalReader.ModifyFestivalAgeRestriction(festival);
                    }),
                    new MenuOption("Festival Genre".PadRight(currentValueStartingPoint) + $"{festival.FestivalGenre}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputGenre(festival);
                    }),
                    new MenuOption("Cancel Time".PadRight(currentValueStartingPoint) + $"{festival.FestivalCancelTime}", () =>
                    {
                        Console.Clear();
                        FestivalReader.InputCancelTime(festival);
                    }),
                    new MenuOption("Tickets".PadRight(currentValueStartingPoint), () =>
                    {
                        Console.Clear();
                        savedTicketList = FestivalReader.InputFestivalTickets(savedTicketList);
                    }),
                    new MenuOption("Save Festival", () =>
                    {
                        Console.Clear();
                        foreach (TicketModel ticket in savedTicketList)
                        {
                            ticketList.Tickets.Add(ticket);
                        }
                        JSONFunctions.WriteTickets(ticketList);

                        festivalList.Festivals.Add(festival);
                        JSONFunctions.WriteFestivals(festivalList);
                        Program.Main();
                    }),
                    new MenuOption("Cancel Festival Registration", () =>
                    {
                        Console.Clear();
                        Program.Main();
                    })
                };

            return newMenuOptions;
        }
    }
}