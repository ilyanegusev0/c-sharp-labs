namespace ObserverPattern
{
    internal class Utils
    {
        public static void Clear(int startRow, int endRow)
        {
            for (int row = startRow; row < endRow; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, startRow);
        }
    }
}
