using System;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace Festivity
{


    public class CatalogPage
    {
        static int Option;
        static Festival[] testArray;

        // Class containing everything relevant to the catalog page in the console
        public static void catalog_main()
        {

            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            int arraySize = 0;
            foreach (var festival in Festivals.Festivals)
            {
                arraySize++;
            }

            Festival[] festivalArray = new Festival[arraySize];

            int festivalNumber = 0;
            foreach (var festival in Festivals.Festivals)
            {
                festivalArray[festivalNumber] = new Festival(festival.Id, festival.Name, festival.Location, festival.Date, festival.Time);
                festivalNumber++;
            }
            Option = 0;

            // Makes sure the console keeps refreshing, allowing input

            while (true)
            {
                Console.Clear();
                show_festivals(Festivals);
                catalog_navigate();
            }
        }

        // Function that shows the currently selected festivals in the console
        private static void show_festivals(JSONFestivalList Festivals)
        {
           
            foreach (var festival in Festivals.Festivals)
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(festival.Name);
                //Console.WriteLine(festival.Description);
                Console.WriteLine(festival.Date);
                Console.WriteLine(festival.Location);
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
    