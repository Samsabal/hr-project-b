using Festivity.Account;
using System;

namespace Festivity.FestivalTable
{
    internal class Drawer
    {
        private static UIElements UI = new UIElements("Festival Table");
        public static void Draw()
        {
            if (LoggedInModel.hasFestivals())
            {
                MenuBuilder.Loop = true;
                do
                {
                    UI.PathLine();
                    string Table = Builder.ConvertToString(Builder.BuildTableList());
                    Console.WriteLine(Table);
                    UI.Pom("Choose festival to edit");
                    Menu.Draw(new FestivalMenus().SelectFestival());
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