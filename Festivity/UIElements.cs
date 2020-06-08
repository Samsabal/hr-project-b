using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class UIElements
    {
        private string PathOne;
        private string PathTwo;
        private string Size;
        private int LENGTH = 34;

        public UIElements() 
        {
            Size = "One";
        }
        public UIElements(string p1)
        {
            PathOne = p1;
            Size = "Two";
        }
        public UIElements(string p1, string p2)
        {
            PathOne = p1;
            PathTwo = p2;
            Size = "Three";
        }

        // Draw Line
        // Draw Page - External
        // Draw Path
        // Draw Menu
        // Draw Line - External

        public void Line()
        {
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public  void PathLine()
        {
            switch (Size)
            {
                case "One":
                    Console.WriteLine(LineStringInMiddleWith("< Home >"));
                    break;
                case "Two":
                    Console.WriteLine(LineStringInMiddleWith($"< Home:{PathOne} >"));
                    //Console.WriteLine($"--------------------------< Home:{PathOne} >--------------------------");
                    break;
                case "Three":
                    Console.WriteLine(LineStringInMiddleWith($"< Home:{PathOne}:{PathTwo} >"));
                    //Console.WriteLine($"Home > {PathOne} > {PathTwo}");
                    break;
                default:
                    ErrorMessage.WriteLine("Draw Error");
                    break;
            }
        }

        public void Draw()
        {
            Line();
            PathLine();
        }

        public string SpaceStringInMiddle(string middle)
        {
            return new string(' ', LENGTH - middle.Length / 2) + middle + new string(' ', LENGTH - middle.Length / 2) + "\n";
        }

        public string LineStringInMiddleWith(string middle)
        {
            return new string('-', LENGTH - middle.Length / 2) +  middle +  new string('-', LENGTH - middle.Length / 2) + "\n";
        }

        public void DrawMainMenu()
        {
            Line();
            Console.WriteLine("               ______        _   _       _ _         ");
            Console.WriteLine("              |  ____|      | | (_)     (_) |        ");
            Console.WriteLine("              | |__ ___  ___| |_ ___   ___| |_ _   _ ");
            Console.WriteLine("              |  __/ _ \\/ __| __| \\ \\ / / | __| | | |");
            Console.WriteLine("              | | |  __/\\__ \\ |_| |\\ V /| | |_| |_| |");
            Console.WriteLine("              |_|  \\___||___/\\__|_| \\_/ |_|\\__|\\__, |");
            Console.WriteLine("                                                __/ |");
            Console.WriteLine("                                               |___/ ");
            PathLine();
        }
    }
}
