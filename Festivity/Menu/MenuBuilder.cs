using Festivity.FestivalRegister;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class MenuBuilder
    {
        public static bool Loop;
        public static List<Ticket> savedTicketList = new List<Ticket>();

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
                    do {Menu.Draw(GenreMenuModify(festival)); }
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
                    do { Menu.Draw(SelectTicket(festival)); }
                    while(Loop);
                    Loop = true;
                }),
                new MenuOption("Save festival", () =>
                {
                    Console.Clear();
                    JSONFunctionality.UpdateFestival(festival);
                    festival.FestivalStatus = "Changed";
                }),
                new MenuOption("Cancel festival modification", () =>
                {
                    Console.Clear();
                    Loop = false;
                }),
            };
            return newMenuOptions;
        }

        public static List<MenuOption> SelectTicket(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            foreach (Ticket ticket in festival.GetTickets())
            {
                newMenuOptions.Add(new MenuOption($"Edit ticket: {ticket.TicketName}", () =>
                {
                    Console.Clear();
                    Loop = true;
                    do { Menu.Draw(ChangeTicket(ticket)); }
                    while (Loop);
                    Loop = true;
                }));
            }
            newMenuOptions.Add(new MenuOption($"Return to {festival.FestivalName}", () =>
            {
                Console.Clear();
                ChangeFestival(festival);
                Loop = false;
            }
                ));
            return newMenuOptions;
        }

        public static List<MenuOption> ChangeTicket(Ticket ticket)
        {

            int currentValueStartingPoint = 30;
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption($"Ticket name:".PadRight(currentValueStartingPoint) + $"{ticket.TicketName}", () =>
                {
                    ticket.EditName();
                }),
                new MenuOption($"Ticket description:".PadRight(currentValueStartingPoint) + $"{ticket.TicketDescription}", () =>
                {
                    ticket.EditDescription();
                }),
                new MenuOption($"Ticket price:".PadRight(currentValueStartingPoint) + $"{ticket.TicketPrice}", () =>
                {
                    ticket.EditPrice();
                }),
                new MenuOption($"Max tickets to sell:".PadRight(currentValueStartingPoint) + $"{ticket.MaxTickets}", () =>
                {
                    ticket.EditMaxTickets();
                }),
                new MenuOption($"Max tickets per person:".PadRight(currentValueStartingPoint) + $"{ticket.MaxTicketsPerPerson}", () =>
                {
                    ticket.EditMaxTicketsPerPerson();
                }),
                new MenuOption("Save changes", () =>
                {
                    JSONFunctionality.UpdateTicket(ticket);
                    Console.Clear();
                    Loop = false;
                }),
                new MenuOption("Return to tickets", () =>
                {
                    Console.Clear();
                    Loop = false;
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