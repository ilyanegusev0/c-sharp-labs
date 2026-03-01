using System.Collections;

namespace BuiltInDelegates
{
    public class Program
    {
        static Func<double, double, double> calculate;
        static Predicate<string> filter;

        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {
            double a = 5;
            double b = 10;

            Console.WriteLine("Math operations with built-in delegate Func:");

            calculate = (x, y) => x + y;
            Console.WriteLine($"Add({a}, {b}): {calculate(a, b)}");

            calculate = (x, y) => x - y;
            Console.WriteLine($"Subtract({a}, {b}): {calculate(a, b)}");

            calculate = (x, y) => x * y;
            Console.WriteLine($"Multiply({a}, {b}): {calculate(a, b)}");

            calculate = (x, y) => x / y;
            Console.WriteLine($"Divide({a}, {b}): {calculate(a, b)}");

            Console.WriteLine();

            List<string> names = new List<string>()
            {
                "Alice",
                "Andrew",
                "Benjamin",
                "Bella",
                "Charles",
                "Catherine",
                "David",
                "Diana",
                "Edward",
                "Frank"
            };

            Console.WriteLine("Origin array:");
            PrintArray(names);
            Console.WriteLine();

            filter = value => value.StartsWith('B');
            Console.WriteLine("Filtered array (starts with letter B):");
            PrintArray(names.FindAll(i => filter(i)));
        }

        static void PrintArray(IEnumerable items)
        {
            foreach (var item in items)
                Console.Write($"{item}, ");

            Console.WriteLine();
        }
    }
}
