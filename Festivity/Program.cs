using System;

namespace Festivity
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.SetWindowSize(150, 35);
                MenuFunction.menu(new string[] { "Register", "Login", "Festival catalog", "Register festival", "Exit", "Festival Page" });
            }
        }
    }
}


