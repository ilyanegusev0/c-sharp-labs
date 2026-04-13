using System.Text.Json;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string OUTPUT_FILE = "animals.json";

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            List<Animal> animals = new List<Animal>()
            {
                new Cat("Garfield", 9),
                new Dog("Sif", 0.75)
            };

            string json;

            if (!File.Exists(OUTPUT_FILE))
            {
                json = JsonSerializer.Serialize(animals, options);
                File.WriteAllText(OUTPUT_FILE, json);
            }

            json = File.ReadAllText(OUTPUT_FILE);
            List<Animal> deserializedAnimals = JsonSerializer.Deserialize<List<Animal>>(json, options) ?? new List<Animal>();

            Console.WriteLine($"ANIMALS ({deserializedAnimals.Count}):");
            foreach (var animal in deserializedAnimals)
            {
                switch (animal)
                {
                    case Cat cat:
                        Console.WriteLine($"- {cat}");
                        break;
                    case Dog dog:
                        Console.WriteLine($"- {dog}");
                        break;
                    default:
                        Console.WriteLine($"- {animal}");
                        break;
                }
            }
        }
    }
}