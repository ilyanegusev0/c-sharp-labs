namespace Task1
{
    delegate string TextOperation(string text);
    internal class Program
    {
        static void Main(string[] args)
        {
            const string INPUT_FILE = "textPD25.txt ";
            const string OUTPUT_FILE = "resultPD25.txt ";

            ProcessFile(INPUT_FILE, OUTPUT_FILE, ToUpperCase);
            ProcessFile(INPUT_FILE, OUTPUT_FILE, CountCharacters);
            ProcessFile(INPUT_FILE, OUTPUT_FILE, CountWords);
        }

        static void ProcessFile(string input, string output, TextOperation operation)
        {
            string[] text = File.ReadAllLines(input);

            using (StreamWriter writer = new StreamWriter(output, true))
            {
                foreach (var line in text)
                {
                    string result = operation(line);
                    writer.WriteLine(result);
                }

                writer.WriteLine();
            }
        }

        static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        static string CountCharacters(string text)
        {
            return $"Character count: {text.Length}";
        }

        static string CountWords(string text)
        {
            string[] words = text.Split(' ');
            return $"Word count: {words.Length}";
        }
    }
}
