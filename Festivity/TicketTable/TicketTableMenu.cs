﻿using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class TicketTableMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();

        public List<MenuOption> TicketTableMenuBuilder()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". Refund Ticket ."), () =>
                {
                    Menu.OptionReset();
                    TicketTable.Refund.InitiateRefund();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Exit to Main Menu ."), () =>
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