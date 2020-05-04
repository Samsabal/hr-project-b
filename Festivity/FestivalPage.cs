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
                            MenuFunction.option = 0;
                            while (true)
                            {
                                string line = "----------------------------------------------------------------------";
                                string thickLine = "======================================================================";
                                Console.WriteLine(thickLine);
                                Console.WriteLine("#" + festival.festivalId + " " + festival.festivalName);
                                Console.WriteLine(thickLine);
                                Console.WriteLine(festival.festivalLocation.city + ", " + festival.festivalLocation.country);
                                Console.WriteLine(festival.festivalLocation.streetName + " " + festival.festivalLocation.streetNumber + ", " + festival.festivalLocation.zipCode);
                                Console.WriteLine(line);
                                Console.WriteLine(festival.festivalDate.day + "/" + festival.festivalDate.month + "/" + festival.festivalDate.year);
                                Console.WriteLine("Starts at " + festival.festivalStartingTime + " and ends on " + festival.festivalEndTime + ".");
                                Console.WriteLine("You need to be at least " + festival.festivalAgeRestriction + " years old in order to enter.");
                                Console.WriteLine(line);
                                Console.WriteLine("Bier Bende"); //Needs to be retrieved from the userDatabase.
                                Console.WriteLine(festival.festivalDescription);
                                Console.WriteLine(thickLine);
                                Console.WriteLine("Ticket Info:");
                                Console.WriteLine("Hier komt de ticket info/table."); //Ticket info needs to be retrieved here.
                                Console.WriteLine(thickLine);
                                MenuFunction.menu(new string[] { "Order Ticket", "Return to Catalog", "Exit to Main Menu" });
                            }
                        }
                    }
                }
            }
        }
    }
}
