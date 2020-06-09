using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class TicketTableMenu
    {
        public List<MenuOption> GenreMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption( "Exit to Main Menu", () =>
                {
                    Console.Clear();
                    Program.Main();
                }),
                new MenuOption("Refund Ticket", () =>
                {
                    TicketTable.Refund.InitiateRefund();
                })
            };
            return newMenuOptions;
        }
    }
}