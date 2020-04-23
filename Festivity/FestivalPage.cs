using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace Festivity
{
    public class FestivalPage
    {
        public static void festival_page(int festivalId)
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            if (false) //Needs to contain an age check
            {
                Console.WriteLine("Sorry but you are too young to enter this festival.");
            }
            else
            {
                foreach (var festival in Festivals.festivals)
                {
                    if (festival.festivalId == festivalId)
                    {
                        while (true)
                        {
                            string line = "----------------------------------------------------------------------";
                            string thickLine = "======================================================================";
                            Console.WriteLine(thickLine);
                            Console.WriteLine("#" + festival.festivalId + " " + festival.festivalName);
                            Console.WriteLine(festival.festivalLocation.city + ", " + festival.festivalLocation.country);
                            Console.WriteLine(festival.festivalLocation.streetName + " " + festival.festivalLocation.streetNumber);
                            Console.WriteLine(line);
                            Console.WriteLine(festival.festivalDate.to_string());
                            Console.WriteLine("Begint om " + festival.festivalStartingTime + " en eindigt om " + festival.festivalEndTime + ".");
                            Console.WriteLine("Je moet minimaal " + festival.festivalAgeRestriction + " jaar oud zijn om binnen te komen.");
                            Console.WriteLine(line);
                            Console.WriteLine("Bier Bende");//Moet uit userdatabase worden gehaald
                            Console.WriteLine(festival.festivalDescription);
                            Console.WriteLine(thickLine);
                        }
                    }
                }
            }
        }
    }
}
