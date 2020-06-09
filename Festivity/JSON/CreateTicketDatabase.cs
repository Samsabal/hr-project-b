using System.IO;

namespace Festivity.JSON
{
    internal class CreateTicketDatabase
    {
        public static string Check()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"TicketDatabase.json");
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