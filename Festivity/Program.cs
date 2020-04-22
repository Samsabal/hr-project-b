using Newtonsoft.Json;
using System;
using System.Threading;
using System.IO;

namespace Festivity
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(150, 35);
            MenuFunction.menu(new string[] { "Register", "Login", "Festivals", "Register festival", "Exit", "Festival Page" });
        }
    }
}


