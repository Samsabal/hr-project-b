namespace Festivity.FestivalPage
{
    public class Handler
    {
        public static void Display(int festivalId) // Displays the festival page
        {
            foreach (var festival in JSONFunctions.GetFestivals().Festivals)
            {
                if (festival.FestivalID == festivalId)
                {
                    do
                    {
                        Writer.FestivalName(festival);

                        Writer.FestivalOrganiser(festival);

                        Writer.FestivalAge(festival);

                        Builder.DescriptionParts();

                        Writer.Festival(festival);

                        Transaction.TicketListBuilder.Set(festivalId);

                        Writer.Tickets();

                        Menu.Draw(new FestivalPageMenu().FestivalPageMenuBuilder());
                    }
                    while (Menu.Loop);
                }
            }
        }
    }
}