namespace Analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "story.txt";
            string outputFile = "report.txt";

            int lineCount = 0;
            int wordCount = 0;
            int charCount = 0;

            Console.WriteLine($"Reading of file '{inputFile}'...");
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCount++;
                    charCount += line.Length;

                    string[] words = line.Split(' ');
                    wordCount += words.Length;
                }
            }

            Console.WriteLine($"Writing to file '{outputFile}'...");
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                sw.WriteLine($"Number of lines: {lineCount}");
                sw.WriteLine($"Number of words: {wordCount}");
                sw.WriteLine($"Number of characters: {charCount}");
            }
        }
    }
}
