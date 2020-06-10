using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class TicketMenus
    {
        public List<MenuOption> SelectTicket(FestivalModel festival)
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>();
            foreach (TicketModel ticket in festival.GetTickets())
            {
                newMenuOptions.Add(new MenuOption($"Edit ticket: {ticket.TicketName}", () =>
                {
                    Console.Clear();
                    do { Menu.Draw(ChangeTicket(ticket)); }
                    while (Menu.IsLooping);

                }));
            }
            newMenuOptions.Add(new MenuOption($"Return to {festival.FestivalName}", () =>
            {
                Console.Clear();
                Menu.Draw(new FestivalMenus().ChangeFestival(festival));
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
                    JSONFunctions.UpdateTicket(ticket);
                    Console.Clear();
                }),
                new MenuOption("Return to tickets", () =>
                {
                    Console.Clear();
                }),
            };

            return newMenuOptions;
        }
    }
}