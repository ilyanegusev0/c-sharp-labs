namespace Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            Console.WriteLine("Show message with different rules on LogHandler:");

            logger.LogHandler = msg => Console.WriteLine(msg);
            logger.Log("It's a normal message.");

            logger.LogHandler = msg => Console.WriteLine(msg.ToUpper());
            logger.Log("It's a message in upper case.");
        }
    }
}
