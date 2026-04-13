using System.Text.Json.Serialization;

namespace Task3
{
    internal class Book
    {
        public string Title { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

        public Book(string title, Author author)
        {
            Title = title;
            Author = author;
        }
    }
}