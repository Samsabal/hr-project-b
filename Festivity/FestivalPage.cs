using Newtonsoft.Json;
using System;
using System.IO;

namespace Festivity
{
    class FestivalPage
    {
        string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
        JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

        void festival()
        {
            foreach (var festival in Festivals.Festivals)
            {
                string _ = " ";
                string Lijn = "-----------------------------------";
                string DikkeLijn = "===================================";
                Console.WriteLine(DikkeLijn);
                Console.WriteLine(festival.Name, _, festival.Id);
                Console.WriteLine(festival.Address, _, festival.Location);
                Console.WriteLine(festival.Date, _, festival.Time);
                Console.WriteLine(Lijn);
                Console.WriteLine(festival.Description);
                Console.WriteLine(DikkeLijn);
            }
        }
    }

}
