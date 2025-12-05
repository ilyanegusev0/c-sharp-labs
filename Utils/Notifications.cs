namespace Utils
{
    public class Notifications
    {
        public static void ShowError(string message)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ResetColor();

            Console.Write("Press any key to continue... ");
            Console.ReadKey();
        }

        public static void ShowWarning(string message)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"WARNING: {message}");
            Console.ResetColor();

            Console.Write("Press any key to continue... ");
            Console.ReadKey();
        }

        public static void ShowSuccess(string message)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS: {message}");
            Console.ResetColor();

            Console.Write("Press any key to continue... ");
            Console.ReadKey();
        }
    }
}
