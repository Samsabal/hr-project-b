using System.IO;

namespace Festivity.JSON
{
    internal class CreateFestivalDatabase
    {
        public static string Check()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"FestivalDatabase.json");
            if (!File.Exists(path))
            {
                using StreamWriter file = File.CreateText(path);
                file.WriteLine("{");
                file.WriteLine("  \"festivals\": []");
                file.WriteLine("}");
            }
            return path;
        }
    }
}