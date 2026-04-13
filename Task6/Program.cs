using System.Text.Json;

namespace Task6
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

            Player player = new Player("Arthur Morgan");

            player.Inventory.Add("Arthur's Hat", "Carcano Rifle", "Chewing Tobacco", "Gold Bar");

            string json;

            if (!File.Exists(OUTPUT_FILE))
            {
                json = JsonSerializer.Serialize(player, options);
                File.WriteAllText(OUTPUT_FILE, json);
            }

            json = File.ReadAllText(OUTPUT_FILE);
            Player? deserializedPlayer = JsonSerializer.Deserialize<Player>(json, options);

            deserializedPlayer.Inventory ??= new Inventory();

            Console.WriteLine($"{deserializedPlayer.Name}\n" +
                $"{new string('-', 50)}\n" +
                $"INVENTORY ({deserializedPlayer.Inventory.Items.Count} items):");

            foreach (var item in deserializedPlayer.Inventory.Items)
                Console.WriteLine($"- {item}");
        }
    }
}
