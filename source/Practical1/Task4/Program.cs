namespace Task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Print side (A): ");
            double.TryParse(Console.ReadLine(), out double a);
            Console.Write("Print side (B): ");
            double.TryParse(Console.ReadLine(), out double b);
            Console.Write("Print side (C): ");
            double.TryParse(Console.ReadLine(), out double c);

            Console.WriteLine();

            if (IsValidTriangle(a, b, c))
                Console.WriteLine("The triangle is exists.");

            else
                Console.WriteLine("The triangle doesn't exist.");

            Console.WriteLine();

            Console.WriteLine($"Type: {GetTriangleType(a, b, c)}");
            Console.WriteLine($"Perimeter: {GetPerimeter(a, b, c)}");
            Console.WriteLine($"Area: {GetArea(a, b, c)}");
        }
        public static bool IsValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                return false;

            else if (a + b < c || b + c < a || a + c < b)
                return false;

            else
                return true;
        }

        public static double GetPerimeter(double a, double b, double c)
        {
            return a + b + c;
        }

        public static double GetArea(double a, double b, double c)
        {
            double s = (a + b + c) / 2.0;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public static string GetTriangleType(double a, double b, double c)
        {
            if (a == b && b == c && a == c)
                return "рівносторонній";

            else if (a == b || b == c || a == c)
                return "рівнобедрений";

            else if (Math.Abs(a * a + b * b - c * c) < 0.0001)
                return "прямокутний";

            else
                return "довільний";
        }
    }
}
