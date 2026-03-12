namespace Cleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int deletedFiles = 0;
            long totalSize = 0;

            Console.Write("Path to cache-directory: ");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("\nDirectory doesn't exist.");
                return;
            }

            Console.Write("\nDo you want to clear this directory? (Y/N)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    break;
                case ConsoleKey.N:
                    return;
            }
            try
            {
                foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    FileInfo fi = new FileInfo(file);
                    deletedFiles++;
                    totalSize += fi.Length;
                    fi.Delete();
                }

                Console.WriteLine("\n\nREPORT:\n" +
                    $" Deleted files: {deletedFiles}\n" +
                    $" Total size: {totalSize} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
