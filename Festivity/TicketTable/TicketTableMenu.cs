using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class TicketTableMenu : MenuBuilder
    {
        public List<MenuOption> TicketTableMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption( "Exit to Main Menu", () =>
                {
                    Console.Clear();
                    Menu.OptionReset();
                    Program.Main();
                }),
                new MenuOption("Refund Ticket", () =>
                {
                    Menu.OptionReset();
                    TicketTable.Refund.InitiateRefund();
                })
            };
            return newMenuOptions;
        }
    }
}