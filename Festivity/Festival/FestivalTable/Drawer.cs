using Festivity.Account;
using System;

namespace Festivity.FestivalTable
{
    internal class Drawer
    {
        public static void Draw()
        {
            if (LoggedInModel.hasFestivals())
            {

                do
                {
                    string Table = Builder.ConvertToString(Builder.BuildTableList());
                    Console.WriteLine(Table);
                    Menu.Draw(new FestivalMenus().SelectFestival());
                } while (Menu.IsLooping);
            }
            else
            {
                ErrorMessage.NoFestivalsError();
                Console.Clear();
            }
        }
    }
}