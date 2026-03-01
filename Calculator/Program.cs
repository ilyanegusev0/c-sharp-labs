namespace Calculator
{
    delegate double MathOperation(double a, double b);

    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperation mo;

            double a = 5;
            double b = 10;

            Console.WriteLine("Math operations with  delegate MathOperation:");

            mo = Add;
            Console.WriteLine($"Add({a}, {b}): {mo(a, b)}");

            mo = Subtract;
            Console.WriteLine($"Subtract({a}, {b}): {mo(a, b)}");

            mo = Multiply;
            Console.WriteLine($"Multiply({a}, {b}): {mo(a, b)}");

            mo = Divide;
            Console.WriteLine($"Divide({a}, {b}): {mo(a, b)}");
        }

        static public double Add(double a, double b)
        {
            return a + b;
        }
        static public double Subtract(double a, double b)
        {
            return a - b;
        }
        static public double Multiply(double a, double b)
        {
            return a * b;
        }
        static public double Divide(double a, double b)
        {
            return a / b;
        }
    }
}
