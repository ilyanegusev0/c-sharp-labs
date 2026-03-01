namespace Connector
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ShowSection("Task #1. Calculator:", '-', 100, Calculator.Program.Run);
            ShowSection("Task #2. Multicasting:", '-', 100, Multicasting.Program.Run);
            ShowSection("Task #3. Filtering:", '-', 100, Filtering.Program.Run);
            ShowSection("Task #4. BuiltInDelegates:", '-', 100, BuiltInDelegates.Program.Run);
            ShowSection("Task #5. Logging:", '-', 100, Logging.Program.Run);
            ShowSection("Task #6. Validation:", '-', 100, Validation.Program.Run);
        }

        static void ShowSection(string header, char sym, int count, Action action)
        {
            Console.WriteLine(header);
            Console.WriteLine(new string(sym, count));
            action.Invoke();
            Console.WriteLine("\n\n");
        }
    }
}
