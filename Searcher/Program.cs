namespace Searcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Path to directory: ");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("\nDirectory doesn't exist.");
                return;
            }

            FileInfo largestFile = null;

            try
            {
                foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    FileInfo fi = new FileInfo(file);

                    if (largestFile == null || fi.Length > largestFile.Length)
                        largestFile = fi;
                }

                if (largestFile != null)
                {
                    Console.WriteLine("\nLARGEST FILE:\n" +
                        $"Name: {largestFile.Name}\n" +
                        $"Size: {largestFile.Length} bytes\n" +
                        $"Path: {largestFile.FullName}");
                }
                else
                {
                    Console.WriteLine("There are no files in directory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
