using System;

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
                    break;
                case "Three":
                    Console.WriteLine(LineStringInMiddleWith($"< Home:{PathOne}:{PathTwo} >"));
                    break;
                default:
                    ErrorMessage.WriteLine("Draw Error");
                    break;
            }
        }

        public void InfoLine(string message)
        {
            Console.WriteLine(SpaceStringInMiddle(message));
        }

        public void Pom(string message)
        {
            Console.WriteLine(LineStringInMiddleWith($"[ {message} ]"));
        }

        public void WhiteLinePom(string message)
        {
            Console.WriteLine();
            Console.WriteLine(LineStringInMiddleWith($"[ {message} ]"));
        }

        public string SpaceStringInMiddle(string middle)
        {
            return new string(' ', LENGTH - middle.Length / 2) + middle + new string(' ', LENGTH - middle.Length / 2) + "\n";
        }

        public string LineStringInMiddleWith(string middle)
        {
            return new string('-', LENGTH - middle.Length / 2) +  middle +  new string('-', LENGTH - middle.Length / 2) + "\n";
        }

        public void Header()
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

        public void TicketTablePathLine()
        {
            switch (Size)
            {
                case "One":
                    Console.WriteLine(TicketTableLineStringInMiddleWith("< Home >"));
                    break;
                case "Two":
                    Console.WriteLine(TicketTableLineStringInMiddleWith($"< Home:{PathOne} >"));
                    break;
                case "Three":
                    Console.WriteLine(TicketTableLineStringInMiddleWith($"< Home:{PathOne}:{PathTwo} >"));
                    break;
                default:
                    ErrorMessage.WriteLine("Draw Error");
                    break;
            }
        }

        public string TicketTableLineStringInMiddleWith(string middle)
        {
            return new string('-', LENGTH - middle.Length / 2) + middle + new string('-', LENGTH - middle.Length / 2) + "\n";
        }
    }
}
