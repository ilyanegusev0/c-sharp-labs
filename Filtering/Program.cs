namespace Filtering
{
    delegate bool FilterPredicate(int value);
    internal class Program
    {
        static void Main(string[] args)
        {
            FilterPredicate fp;

            int[] numbers = GetRandomArray(10, -50, 50);
            Console.WriteLine("Origin array:");
            PrintArray(numbers);
            Console.WriteLine();

            fp = num => num % 2 == 0;
            Console.WriteLine("Filtered array (even numbers):");
            PrintArray(FilterArray(numbers, fp));
            Console.WriteLine();

            fp = num => num > 5;
            Console.WriteLine("Filtered array (more than 5):");
            PrintArray(FilterArray(numbers, fp));
            Console.WriteLine();

            fp = num => num % 2 != 0;
            Console.WriteLine("Filtered array (odd numbers):");
            PrintArray(FilterArray(numbers, fp));
            Console.WriteLine();
        }

        static public int[] FilterArray(int[] numbers, FilterPredicate fp)
        {
            List<int> filteredArray = new List<int>();

            foreach (int num in numbers)
            {
                if (fp(num))
                    filteredArray.Add(num);
            }

            return filteredArray.ToArray();
        }

        static public int[] GetRandomArray(int size, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = random.Next(min, max);

            return array;
        }

        static public void PrintArray(int[] numbers)
        {
            foreach (int num in numbers)
                Console.Write($"{num} ");

            Console.WriteLine();
        }
    }
}
