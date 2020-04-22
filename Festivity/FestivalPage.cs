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

            string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
            JSONUserList users = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

            foreach (var user in users.users)
            {
                foreach (var festival in Festivals.festivals)
                {
                    if (festival.festivalId == festivalId)
                    {
                        if (false) //Needs to contain an age check -> (users.birthDate - festival.festivalDate < 18)
                        {
                            Console.WriteLine("Sorry but you are too young to enter this festival.");
                        }
                        else
                        {
                            string line = "----------------------------------------------------------------------";
                            string thickLine = "======================================================================";
                            Console.WriteLine(thickLine);
                            Console.WriteLine("#" + festival.festivalId + " " + festival.festivalName);
                            Console.WriteLine(festival.festivalLocationCity + ", " + festival.festivalLocationCountry);
                            Console.WriteLine(festival.festivalLocationStreet + " " + festival.festivalLocationHouseNumber);
                            Console.WriteLine(line);
                            Console.WriteLine(festival.festivalDate);
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
