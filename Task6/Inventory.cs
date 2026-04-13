namespace Task6
{
    internal class Inventory
    {
        public List<string> Items {  get; set; }

        public Inventory()
        {
            Items = new List<string>();
        }

        public void Add(params string[] item)
        {
            Items.AddRange(item);
        }
    }
}
