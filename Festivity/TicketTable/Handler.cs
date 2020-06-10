namespace Festivity.TicketTable
{
    internal class Handler
    {
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