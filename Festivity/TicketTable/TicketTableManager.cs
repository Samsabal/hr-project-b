namespace Festivity
{
    internal class TicketTableManager
    {
        public static void Initiate()
        {
            if (TicketTableListBuilder.Build())
            {
                DrawTicketTable.CreateTable();
                DrawTicketTable.DrawTicketTablePage();
            }
        }
    }
}