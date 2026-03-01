using System.Collections;

namespace BuiltInDelegates
{

    internal class Program
    {
        static public Func<double, double, double> calculate;
        static public Predicate<string> filter;

        static void Main(string[] args)
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

        static public void PrintArray(IEnumerable items)
        {
            foreach (var item in items)
                Console.Write($"{item}, ");

            Console.WriteLine();
        }
    }
}
