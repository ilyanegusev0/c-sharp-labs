namespace Task2
{
    internal class FileLogger
    {
        private readonly string _logFile;

        public FileLogger(string file)
        {
            _logFile = file;
        }

        public void OnMessageSent(object sender, MessageEventArgs args)
        {
            string logEntry = $"[{args.Date}] {args.Sender}: {args.Text}";

            using (StreamWriter writer = new StreamWriter(_logFile, true))
            {
                writer.WriteLine(logEntry);
            }
        }
    }
}
