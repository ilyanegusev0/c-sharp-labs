namespace Task7
{
    internal class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public void IncreaseLevel(int steps = 1)
        {
            Level += steps;
        }
    }
}
