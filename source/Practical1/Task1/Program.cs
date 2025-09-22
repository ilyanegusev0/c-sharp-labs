namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Input number: ");

            int.TryParse(Console.ReadLine(), out int num);

            GetMessage(num);
        }

        public static bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetMessage(int number)
        {
            if (IsEven(number))
               return "Двері відкриваються!";

            else
                return "Двері зачинені...";
        }
    }
}
