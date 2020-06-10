namespace Festivity.TicketTable
{
    internal class Handler
    {
        private static UIElements UI = new UIElements("Ticket Table");
        public static void Initiate()
        {
            if (Builder.Build())
            {
                Drawer.CreateTable();
                Drawer.DrawTicketTablePage();
            }
        }
    }
}