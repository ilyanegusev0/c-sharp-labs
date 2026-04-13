namespace Task5
{
    internal class Dog : Animal
    {
        public double BarkVolume { get; set; }

        public Dog(string name, double barkVolume) : base(name)
        {
            BarkVolume = barkVolume;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} | BARK-VOLUME: {BarkVolume}";
        }
    }
}
