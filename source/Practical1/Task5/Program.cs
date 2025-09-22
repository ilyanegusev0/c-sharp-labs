namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[][] groups = new int[5][];
            groups[0] = GenerateRandomArray(10, 0, 100);
            groups[1] = GenerateRandomArray(15, 0, 100);
            groups[2] = GenerateRandomArray(20, 0, 100);
            groups[3] = GenerateRandomArray(25, 0, 100);
            groups[4] = GenerateRandomArray(30, 0, 100);

            ShowGroupStatistics(groups);
        }

        public static void ShowGroupStatistics(int[][] groups)
        {
            int index = 0;
            foreach (int[] group in groups)
            {
                Console.WriteLine($"Group[{index}]: " +
                    $"AVG: {GetAverage(group)} | " +
                    $"MIN: {GetMin(group)} | " +
                    $"MAX: {GetMax(group)}");
                index++;
            }
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

        public static int GetSum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
