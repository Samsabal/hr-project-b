using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class UIElements
    {
        public static void GoddelijkeDunneLijn()
        {
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public static void MenuLijn()
        {
            Console.WriteLine("---------------------------< Homepage >------------------------------");
        }

        public static void PrintUI()
        {
            GoddelijkeDunneLijn();
            Console.WriteLine("               ______        _   _       _ _         ");
            Console.WriteLine("              |  ____|      | | (_)     (_) |        ");
            Console.WriteLine("              | |__ ___  ___| |_ ___   ___| |_ _   _ ");
            Console.WriteLine("              |  __/ _ \\/ __| __| \\ \\ / / | __| | | |");
            Console.WriteLine("              | | |  __/\\__ \\ |_| |\\ V /| | |_| |_| |");
            Console.WriteLine("              |_|  \\___||___/\\__|_| \\_/ |_|\\__|\\__, |");
            Console.WriteLine("                                                __/ |");
            Console.WriteLine("                                               |___/ ");
            MenuLijn();
            Console.WriteLine();
        }

        public static string StringInMiddle(string middle)
        {
            int lenght = 33;
            //Console.Write(new string('-', 50 - middle.Length));
            //Console.Write(middle);
            //Console.Write(new string('-', 50 - middle.Length)+ "\n");
            return new string(' ', lenght - middle.Length / 2) + middle + new string(' ', lenght - middle.Length / 2) + "\n";
        }
    }
}
