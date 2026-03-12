using TableFlex.Core;
using TableFlex.Renderers;

namespace Inspector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TableRenderer tr = new TableRenderer();

            Console.Write("Path to directory: ");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("\nDirectory doesn't exist.");
                return;
            }

            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            Console.WriteLine($"\nDIRECTORIES ({dirs.Length}):");
            foreach (var dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                Console.WriteLine($" - {dirInfo.Name}\\");
            }

            Console.WriteLine($"\nFILES ({files.Length}):");
            Table filesTable = new Table();
            filesTable.SetHeader("NAME", "SIZE", "DATE");
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                filesTable.AddRow(fileInfo.Name, $"{fileInfo.Length} bytes", fileInfo.CreationTime);
            }
            Console.WriteLine(tr.Render(filesTable));
        }
    }
}
