using System;

namespace Festivity.Festival
{
    class FestivalTableDrawer
    {
        public static void Draw()
        {
            while (true)
            {
                string Table = FestivalTableBuilder.ConvertToString(FestivalTableBuilder.BuildTableList());
                Console.WriteLine(Table);
                Menu.Draw(MenuBuilder.SelectFestival());
            }
        }
    }
}
