using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Festival
{
    class FestivalTableDrawer
    {
        public static void Draw()
        {
            string Table = FestivalTableBuilder.ConvertToString(FestivalTableBuilder.BuildTableList());
            Console.WriteLine(Table);
            Console.ReadKey();
        }
    }
}
