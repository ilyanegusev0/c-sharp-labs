namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string LOG_FILE = "logPD25.txt";

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger(LOG_FILE);

            publisher.MessageSent += logger.OnMessageSent;

            Console.Write("Input your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter messages (empty line to stop):");
            while (true)
            {
                Console.Write("> ");
                string message = Console.ReadLine();

                if (string.IsNullOrEmpty(message))
                    break;

                publisher.Send(name, message);
            }
        }
    }
}
