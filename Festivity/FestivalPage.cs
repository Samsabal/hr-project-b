using Newtonsoft.Json;
using System;
using System.IO;

namespace Festivity
{
    class FestivalPage
    {
        static void festival_page_main(string[] args)
        {
            string PATH_FESTIVAL = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"FestivalsDatabase.json");
            JSONFestivalList Festivals = JsonConvert.DeserializeObject<JSONFestivalList>(File.ReadAllText(PATH_FESTIVAL));

            foreach (var festival in Festivals.Festivals)
            {
                Console.WriteLine(festival.Id);
            }
        }

    }

}
