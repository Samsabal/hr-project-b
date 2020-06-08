using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class TicketMenus : MenuBuilder
    {
        public static List<MenuOption> SelectTicket(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            foreach (Ticket ticket in festival.GetTickets())
            {
                newMenuOptions.Add(new MenuOption($"Edit ticket: {ticket.TicketName}", () =>
                {
                    Menu.OptionReset();
                    Console.Clear();
                    Loop = true;
                    do { Menu.Draw(ChangeTicket(ticket)); }
                    while (Loop);
                    Loop = true;
                }));
            }
            newMenuOptions.Add(new MenuOption($"Return to {festival.FestivalName}", () =>
            {
                Menu.OptionReset();
                Console.Clear();
                FestivalMenus.ChangeFestival(festival);
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
                    Menu.OptionReset();
                    JSONFunctionality.UpdateTicket(ticket);
                    Console.Clear();
                    Loop = false;
                }),
                new MenuOption("Return to tickets", () =>
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
