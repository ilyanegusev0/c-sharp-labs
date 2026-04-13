namespace Task3
{
    internal class Author
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Author(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public void AddBook(params Book[] book)
        {
            Books.AddRange(book);
        }

        public void Show()
        {
            Console.WriteLine($"{Name}\n" +
                $"{new string('-', 50)}\n" +
                $"BOOKS ({Books.Count}):");

            foreach (var book in Books)
                Console.WriteLine($"- {book.Title}");
        }
    }
}
