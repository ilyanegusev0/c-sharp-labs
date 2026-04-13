namespace Task5
{
    internal class Cat : Animal
    {
        public int Lives { get; set; }

        public Cat(string name, int lives) : base(name)
        {
            Lives = lives;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} | LIVES: {Lives}";
        }
    }
}
