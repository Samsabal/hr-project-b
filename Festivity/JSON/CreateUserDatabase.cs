using System.IO;

namespace Festivity.JSON
{
    class CreateUserDatabase
    {
        public static string Check()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"UserDatabase.json");
            if (!File.Exists(path))
            {
                using StreamWriter file = File.CreateText(path);
                file.WriteLine("{");
                file.WriteLine("  \"users\": []");
                file.WriteLine("}");
            }
            return path;
        }
    }
}
