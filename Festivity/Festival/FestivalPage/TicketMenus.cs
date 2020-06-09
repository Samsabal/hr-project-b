using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class TicketMenus : MenuBuilder
    {
        public List<MenuOption> SelectTicket(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            foreach (TicketModel ticket in festival.GetTickets())
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
                new FestivalMenus().ChangeFestival(festival);
                Loop = false;
            }
                ));
            return newMenuOptions;
        }

        public List<MenuOption> ChangeTicket(TicketModel ticket)
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
                    JSONFunctions.UpdateTicket(ticket);
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