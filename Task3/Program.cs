using System.Text.Json;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string OUTPUT_FILE = "books.json";

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Author andrzeySapkowski = new Author("Andrzej Sapkowski");

            Book theWitcherTheLastWish = new Book("The Witcher: The Last Wish", andrzeySapkowski);
            Book theWitcherSwordOfDestiny = new Book("The Witcher: Sword of Destiny", andrzeySapkowski);

            andrzeySapkowski.AddBook(theWitcherTheLastWish, theWitcherSwordOfDestiny);

            string json;

            if (!File.Exists(OUTPUT_FILE))
            {
                json = JsonSerializer.Serialize(andrzeySapkowski, options);
                File.WriteAllText(OUTPUT_FILE, json);
            }

            json = File.ReadAllText(OUTPUT_FILE);
            Author? deserializerAuthor = JsonSerializer.Deserialize<Author>(json, options);

            deserializerAuthor.Show();
        }
    }
}
