using System.IO;

namespace Festivity.JSON
{
    class CreateUserDatabase
    {
        public static string Check()
        {
            string[] paths = { Directory.GetCurrentDirectory(), "UserDatabase.json" };
            string path = Path.Combine(paths);
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
