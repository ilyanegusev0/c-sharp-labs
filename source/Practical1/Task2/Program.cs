namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = GenerateRandomArray(10, 1, 100);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine("\n");

            Console.WriteLine($"Sum: {GetSum(arr)}");
            Console.WriteLine($"Average: {GetAverage(arr)}");
            Console.WriteLine($"Min: {GetMin(arr)}");
            Console.WriteLine($"Max: {GetMax(arr)}");
        }

        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            int[] array = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        public static int GetSum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double GetAverage(int[] array)
        {
            return GetSum(array) / array.Length;
        }

        public static int GetMin(int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static int GetMax(int[] array)
        {
            int max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}
