using System;

namespace Festivity.Festival
{
    public class PageManager
    {
        public static void Display(int festivalId) // Displays the festival page
        {
            foreach (var festival in JSONFunctionality.GetFestivals().Festivals)
            {
                if (festival.FestivalID == festivalId)
                {
                    Menu.OptionReset();
                    while (true)
                    {
                        Console.WriteLine("======================================================================");
                        Console.WriteLine(festival.FestivalName);

                        Writer.FestivalOrganiser(festival);

                        Writer.Festival(festival); // Writes the current Festival

                        Transaction.TicketListBuilder.Set(festivalId);

                        Writer.Tickets(); // Writes the corresponding Tickets from the current Festival
                    }
                }
            }
        }
    }
}