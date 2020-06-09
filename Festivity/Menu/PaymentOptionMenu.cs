﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class PaymentOptionMenu : MenuBuilder
    {
        public List<MenuOption> Build()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("IDeal", () =>
                {
                    Transaction.DisplayManager.Complete();
                }),
                new MenuOption("PayPal", () =>
                {
                    Transaction.DisplayManager.Complete();
                }),
                new MenuOption("Creditcard", () =>
                {
                    Transaction.DisplayManager.Complete();
                }),
                new MenuOption("Cancel Order", () =>
                {
                    Transaction.DisplayManager.Complete();
                })
            };

            return newMenuOptions;
        }
    }
}