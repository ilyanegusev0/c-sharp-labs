using System.Text.Json;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string OUTPUT_FILE = "player.json";

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Player player = new Player("Geralt of Rivia", 20);

            string json;

            if (!File.Exists(OUTPUT_FILE))
            {
                json = JsonSerializer.Serialize(player, options);
                File.WriteAllText(OUTPUT_FILE, json);
            }

            json = File.ReadAllText(OUTPUT_FILE);
            Player? deserializedPlayer = JsonSerializer.Deserialize<Player>(json, options);

            if (deserializedPlayer.Level == 0)
                deserializedPlayer.Level = 1;

            Console.WriteLine($"Player: {deserializedPlayer.Name}\n" +
                $"{new string('-', 50)}\n" +
                $"LEVEL: {deserializedPlayer.Level}");
        }
    }
}
