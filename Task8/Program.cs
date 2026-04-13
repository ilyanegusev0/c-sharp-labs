using System.Text.Json;

namespace Task8
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

            Player player = new Player("John Marston");

            string json;

            if (!File.Exists(OUTPUT_FILE))
            {
                json = JsonSerializer.Serialize(player, options);
                File.WriteAllText(OUTPUT_FILE, json);
            }

            try
            {
                json = File.ReadAllText(OUTPUT_FILE);
                Player? deserializedPlayer = JsonSerializer.Deserialize<Player>(json, options);

                Console.WriteLine($"Player: {deserializedPlayer.Name}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON-file is corrupted. Recreating the player with default data...");

                Player defaultPlayer = new Player("Player");

                Console.WriteLine($"Player: {defaultPlayer.Name}");
            }
        }
    }
}