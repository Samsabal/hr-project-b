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
                        Writer.FestivalName(festival);

                        Writer.FestivalOrganiser(festival);

                        Writer.FestivalAge(festival);

                        Utils.DescriptionParts();

                        Writer.Festival(festival);

                        Transaction.TicketListBuilder.Set(festivalId);

                        Writer.Tickets();

                        Menu.Draw(new FestivalPageMenu().FestivalPageMenuBuilder());
                    }
                }
            }
        }
    }
}