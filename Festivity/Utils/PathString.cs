using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Utils
{
    class PathString
    {
        private string PathOne;
        private string PathTwo;
        private string Size;

        public PathString(string p1)
        {
            PathOne = p1;
            Size = "Two";
        }

        public PathString(string p1, string p2)
        {
            PathOne = p1;
            PathTwo = p2;
            Size = "Three";
        }

        public void Draw()
        {
            DrawDikkeLine();
            switch (Size)
            {
                case "Two":
                    Console.WriteLine($"--------------------------< Home:{PathOne} >--------------------------");
                    break;
                case "Three":
                    Console.WriteLine($"Home > {PathOne} > {PathTwo}");
                    break;
                default:
                    ErrorMessage.WriteLine("Draw Error");
                    break;
            }
            DrawDikkeLine();
        }
        private void  DrawDikkeLine()
        {
            Console.WriteLine($"                                    ");
        }
    }
}


