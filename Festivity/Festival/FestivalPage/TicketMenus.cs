﻿using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class TicketMenus : MenuBuilder
    {
        private static UIElements UI = new UIElements("Festivals");
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
                UI.PathLine();
                UI.InfoLine("Wat moet heir komen dan hoertje");
                UI.Pom("Change Festival Informatoin");
                new FestivalMenus().ChangeFestival(festival);
                Loop = false;
            }
                ));
            return newMenuOptions;
        }

        public List<MenuOption> ChangeTicket(TicketModel ticket)
        {
            int PadRightValue = 30;
            int PadLeftValue = 38;
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption($" Name:".PadRight(PadRightValue) + $"{ticket.TicketName}".PadLeft(PadLeftValue), () =>
                {
                    ticket.EditName();
                }),
                new MenuOption($" Description:".PadRight(PadRightValue) + $"{ticket.TicketDescription}".PadLeft(PadLeftValue), () =>
                {
                    ticket.EditDescription();
                }),
                new MenuOption($" Price:".PadRight(PadRightValue) + $"{ticket.TicketPrice}".PadLeft(PadLeftValue), () =>
                {
                    ticket.EditPrice();
                }),
                new MenuOption($" Max tickets:".PadRight(PadRightValue) + $"{ticket.MaxTickets}".PadLeft(PadLeftValue), () =>
                {
                    ticket.EditMaxTickets();
                }),
                new MenuOption($" Max tickets per person:".PadRight(PadRightValue) + $"{ticket.MaxTicketsPerPerson}".PadLeft(PadLeftValue), () =>
                {
                    ticket.EditMaxTicketsPerPerson();
                }),
                new MenuOption(" Save changes", () =>
                {
                    Menu.OptionReset();
                    JSONFunctions.UpdateTicket(ticket);
                    Console.Clear();
                    Loop = false;
                }),
                new MenuOption(" Return to tickets", () =>
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