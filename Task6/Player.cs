namespace Task6
{
    internal class Player
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new Inventory();
        }
    }
}
