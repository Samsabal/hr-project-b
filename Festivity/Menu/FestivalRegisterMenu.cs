using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class FestivalRegisterMenu : MenuBuilder
    {
        public static List<Ticket> savedTicketList = new List<Ticket>();

        public static List<MenuOption> FestivalRegisterMenuBuilder(FestivalModel festival)
        {
            int currentValueStartingPoint = 30;

            JSONFestivalList festivalList = JSONFunctionality.GetFestivals();
            JSONTicketList ticketList = JSONFunctionality.GetTickets();

            List<MenuOption> newMenuOptions = new List<MenuOption>
                {
                    new MenuOption("Festival Name:".PadRight(currentValueStartingPoint) + $"{festival.FestivalName}", () =>
                    {
                        Console.Clear();
                        Modifier.InputFestivalName(festival);
                    }),
                    new MenuOption("Festival Date:".PadRight(currentValueStartingPoint) + $"{festival.FestivalDate.ToShortDateString()}", () =>
                    {
                        Console.Clear();
                        Modifier.InputFestivalDate(festival);
                    }),
                    new MenuOption("Starting Time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalStartingTime}", () =>
                    {
                        Console.Clear();
                        Modifier.InputStartingTime(festival);
                    }),
                    new MenuOption("End Time:".PadRight(currentValueStartingPoint) + $"{festival.FestivalEndTime}", () =>
                    {
                        Console.Clear();
                        Modifier.InputEndTime(festival);
                        if (festival.FestivalEndTime < festival.FestivalStartingTime)
                            {
                                festival.FestivalEndTime.AddDays(1);
                            }
                    }),
                    new MenuOption("Festival Adress: ".PadRight(currentValueStartingPoint) + $"{festival.FestivalLocation}", () =>
                    {
                        Console.Clear();
                        Modifier.InputFestivalAdress(festival);
                    }),
                    new MenuOption("Festival Description".PadRight(currentValueStartingPoint) + $"{festival.FestivalDescription}", () =>
                    {
                        Console.Clear();
                        Modifier.ModifyFestivalDescription(festival);
                    }),
                    new MenuOption("Age Restriction".PadRight(currentValueStartingPoint) + $"{festival.FestivalAgeRestriction}", () =>
                    {
                        Console.Clear();
                        Modifier.ModifyFestivalAgeRestriction(festival);
                    }),
                    new MenuOption("Festival Genre".PadRight(currentValueStartingPoint) + $"{festival.FestivalGenre}", () =>
                    {
                        Console.Clear();
                        Modifier.InputGenre(festival);
                    }),
                    new MenuOption("Cancel Time".PadRight(currentValueStartingPoint) + $"{festival.FestivalCancelTime}", () =>
                    {
                        Console.Clear();
                        Modifier.InputCancelTime(festival);
                    }),
                    new MenuOption("Tickets".PadRight(currentValueStartingPoint), () =>
                    {
                        Console.Clear();
                        savedTicketList = Modifier.InputFestivalTickets(savedTicketList);
                    }),
                    new MenuOption("Save Festival", () =>
                    {
                        Console.Clear();
                        foreach (Ticket ticket in savedTicketList)
                        {
                            ticketList.Tickets.Add(ticket);
                        }
                        JSONFunctionality.WriteTickets(ticketList);

                        festivalList.Festivals.Add(festival);
                        JSONFunctionality.WriteFestivals(festivalList);
                        Menu.OptionReset();
                        Program.Main();
                    }),
                    new MenuOption("Cancel Festival Registration", () =>
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
