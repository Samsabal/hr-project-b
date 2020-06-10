using System.Collections.Generic;

namespace Festivity
{
    internal class PaymentOptionMenu : MenuBuilder
    {
        private static UIElements UI = new UIElements();
        public List<MenuOption> Build()
        {
            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                new MenuOption(UI.SpaceStringInMiddle(". IDeal ."), () =>
                {
                    Transaction.Handler.Complete();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". PayPal ."), () =>
                {
                    Transaction.Handler.Complete();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Creditcard ."), () =>
                {
                    Transaction.Handler.Complete();
                }),
                new MenuOption(UI.SpaceStringInMiddle(". Cancel Order ."), () =>
                {
                    Transaction.Handler.Complete();
                })
            };

            return newMenuOptions;
        }
    }
}