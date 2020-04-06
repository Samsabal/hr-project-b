using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Festivity
{
    public class CatalogPage
    {
        static int Option;
        static Festival[] testArray;

        // Class containing everything relevant to the catalog page in the console
        public static void catalog_main()
        {
            // Placeholder festivals till JSON festival file is working

            Festival test1 = new Festival("Rotterdamse Rave", "Leukste techno feest van Rotterdam", new Date(31, 03, 2020), 18, new Address("Nederland", "Rotterdam", "1234GK", "Utrechtsesingel", "25"), "normaal/vip", 1);
            Festival test2 = new Festival("Soenda", "Op een na leukste techno feest van Rotterdam", new Date(1, 04, 2020), 18, new Address("Nederland", "Rotterdam", "1235GK", "Utrechtselaan", "26"), "normaal/vip", 2);
            Festival test3 = new Festival("Into the woods", "Op twee na leukste techno feest van Rotteram", new Date(2, 04, 2020), 18, new Address("Nederland", "Rotterdam", "1236GK", "Utrechtsesingel", "25"), "normaal/vip", 3);
            Festival test4 = new Festival("ADE", "Op drie na leukste techno feest van Rotterdam", new Date(3, 04, 2020), 18, new Address("Nederland", "Rotterdam", "1237GK", "Utrechtselaan", "26"), "normaal/vip", 4);
            Festival test5 = new Festival("Atomic", "Minst leuke techno feest van Rotterdam", new Date(3, 04, 2020), 18, new Address("Nederland", "Rotterdam", "1237GK", "Utrechtselaan", "26"), "normaal/vip", 5);
            testArray = new Festival[] { test1, test2, test3, test4, test5 };

            Option = 0;

            // Makes sure the console keeps refreshing, allowing input

            while (true)
            {
                Console.Clear();
                show_festivals();
                catalog_navigate();
            }
        }

        // Function that shows the currently selected festivals in the console
        public static void show_festivals()
        {
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Festival name: " + testArray[i].Name);
                Console.WriteLine("Description: " + testArray[i].description);
                Console.WriteLine("Date: " + testArray[i].date.to_string());
                Console.WriteLine("Location: " + testArray[i].festivalLocation.City);
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        // Function handling the navigation and selection of options in the catalog page
        public static void catalog_navigate()
        {
            string[] ConsoleOptions = new string[]{"Select festival " + testArray[0].Name, "Select festival " +
                testArray[1].Name, "Select festival " + testArray[2].Name, "Select festival " + testArray[3].Name,
                "Select festival " + testArray[4].Name, "Next page", "Previous page", "Exit" };

            for (int i = 0; i < ConsoleOptions.Length; i++)
            {
                if (Option == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine("{0}.{1}", i, ConsoleOptions[i]);
                if (Option == i)
                {
                    Console.ResetColor();
                }
            }

            var KeyPressed = Console.ReadKey();
            // When DownArrow key is pressed go down.
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {
                if (Option != ConsoleOptions.Length - 1)
                {
                    Option++;
                }
            }
            // When UpArrow key is pressed go up.
            else if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                if (Option != 0)
                {
                    Option--;
                }
            }

            else if (KeyPressed.Key == ConsoleKey.Escape)
            {
                Program.Main(new string[] { });
            }

            // Placeholder for option selection switch statement
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                switch (Option)
                {
                    case 0: // Register option
                        Thread.Sleep(10000);
                        break;
                    case 1: // Login option
                        Thread.Sleep(10000);
                        break;
                    case 2: // Festival option
                        Thread.Sleep(10000);
                        break;
                    case 3: // Exit option
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
