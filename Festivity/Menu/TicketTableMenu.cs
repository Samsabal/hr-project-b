using System;
using System.Collections.Generic;

namespace Festivity
{
    class TicketTableMenu : MenuBuilder
    {
        public static List<MenuOption> GenreMenuBuilder()
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
                    RefundTicket.InitiateRefund();
                })
            };
            return newMenuOptions;
        }
    }
}
