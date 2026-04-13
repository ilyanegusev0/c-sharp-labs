namespace Task2
{
    internal class Student
    {
        private static Random _random = new Random();

        public string Name { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            AverageScore = _random.Next(500, 1000) / 10.0;
        }
    }
}
