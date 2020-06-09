using System;

namespace Festivity.Festival
{
    internal class FestivalTableDrawer
    {
        public static void Draw()
        {
            if (LoggedInAccount.hasFestivals())
            {
                MenuBuilder.Loop = true;
                do
                {
                    string Table = FestivalTableBuilder.ConvertToString(FestivalTableBuilder.BuildTableList());
                    Console.WriteLine(Table);
                    Menu.Draw(FestivalMenus.SelectFestival());
                } while (MenuBuilder.Loop);
                MenuBuilder.Loop = true;
            }
            else
            {
                ErrorMessage.NoFestivalsError();
                Console.Clear();
            }
        }
    }
}