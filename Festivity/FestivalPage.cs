using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace Festivity
{
    class FestivalPage
    {
        public static void festival_page()
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            int Option = 0;
            string[] ConsoleOptions = new string[] { "Order Ticket", "Back" };

            while (true)
            {
                //Displays the text in the console.
                Console.Clear();
                foreach (var festival in Festivals.Festivals)
                {
                    string line = "----------------------------------------------------------------------";
                    string thickLine = "======================================================================";
                    string festivalName = festival.name + " #" + festival.id;
                    string festivalAddress = festival.address + ", " + festival.location;
                    string festivalDate = festival.date + ", " + festival.time;
                    Console.WriteLine(thickLine);
                    Console.WriteLine(festivalName);
                    Console.WriteLine(festivalAddress);
                    Console.WriteLine(festivalDate);
                    Console.WriteLine(line);
                    Console.WriteLine(festival.description);
                    Console.WriteLine(thickLine);
                }

                //Makes the keys light up when you select them.
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

                // When Enter key is pressed execute selected option.
                if (KeyPressed.Key == ConsoleKey.Enter)
                {
                    switch (Option)
                    {
                        case 0: // Ticket order option
                            Console.Clear();
                            //Ticket order
                            Thread.Sleep(10000);
                            break;
                        case 1: // Back option
                            Console.Clear();
                            Program.Main(new string[] { });
                            Thread.Sleep(10000);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
