using System.Text.Json;

namespace FinallyTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = File.ReadAllText("../../../settings.json");

            using JsonDocument doc = JsonDocument.Parse(jsonString);

            JsonElement root = doc.RootElement;
            string connectionString = root.GetProperty("DefaultConnection").GetString();


        }
    }
}
