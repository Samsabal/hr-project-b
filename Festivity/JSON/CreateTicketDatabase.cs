using System.IO;

namespace Festivity.JSON
{
    class CreateTicketDatabase
    {
        public static string Check()
        {
            string[] paths = { Directory.GetCurrentDirectory(), "TicketDatabase.json" };
            string path = Path.Combine(paths);
            if (!File.Exists(path))
            {
                using StreamWriter file = File.CreateText(path);
                file.WriteLine("{");
                file.WriteLine("  \"tickets\": []");
                file.WriteLine("}");
            }
            return path;
        }
    }
}
