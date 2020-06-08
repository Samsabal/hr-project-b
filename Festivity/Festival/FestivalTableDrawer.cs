using System;

namespace Festivity.Festival
{
    class FestivalTableDrawer
    {
        public static void Draw()
        {
            MenuBuilder.Loop = true;
            do
            {
                string Table = FestivalTableBuilder.ConvertToString(FestivalTableBuilder.BuildTableList());
                Console.WriteLine(Table);
                Menu.Draw(MenuBuilder.SelectFestival());
            } while (MenuBuilder.Loop);
            MenuBuilder.Loop = true;
        }
    }
}
