using System.IO;

namespace Festivity.JSON
{
    class CreateFestivalDatabase
    {
        public static string Check()
        {
            string[] paths = { Directory.GetCurrentDirectory(), "FestivalDatabase.json" };
            string path = Path.Combine(paths);
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
