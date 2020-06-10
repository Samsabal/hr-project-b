using System.Collections.Generic;

namespace Festivity
{
    internal class PaymentOptionMenu : MenuBuilder
    {
        public List<MenuOption> Build()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption("IDeal", () =>
                {
                    Transaction.Handler.Complete();
                }),
                new MenuOption("PayPal", () =>
                {
                    Transaction.Handler.Complete();
                }),
                new MenuOption("Creditcard", () =>
                {
                    Transaction.Handler.Complete();
                }),
                new MenuOption("Cancel Order", () =>
                {
                    Transaction.Handler.Complete();
                })
            };

            return newMenuOptions;
        }
    }
}