using System.IO;

namespace Festivity.JSON
{
    class CreateTransactionDatabase
    {
        public static string Check()
        {
            string[] paths = { Directory.GetCurrentDirectory(), "TransactionDatabase.json" };
            string path = Path.Combine(paths);
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
