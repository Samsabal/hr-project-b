using System.IO;

namespace Festivity.JSON
{
    internal class CreateTransactionDatabase
    {
        public static string Check()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Database", @"TransactionDatabase.json");
            if (!File.Exists(path))
            {
                using StreamWriter file = File.CreateText(path);
                file.WriteLine("{");
                file.WriteLine("  \"transactions\": []");
                file.WriteLine("}");
            }
            return path;
        }
    }
}