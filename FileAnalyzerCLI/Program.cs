namespace FileAnalyzerCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Using: analyzer.exe <directory_path>");
                return;
            }

            string path = args[0];

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory doesn't exist.");
                return;
            }

            try
            {
                int folderCount = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Length;

                string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                int fileCount = files.Length;

                long totalSize = files.Sum(f => new FileInfo(f).Length);

                FileInfo? largestFile = files
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(fi => fi.Length)
                    .FirstOrDefault();

                Console.WriteLine($"Folders: {folderCount}\n" +
                    $"Files: {fileCount}\n" +
                    $"Total size: {Math.Round(totalSize / 1024.0 / 1024.0, 2)} MB");

                if (largestFile != null)
                    Console.WriteLine($"Largest file: {largestFile.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
