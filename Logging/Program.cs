namespace Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.LogHandler = msg => Console.WriteLine(msg);
            logger.Log("It's a normal message.");

            logger.LogHandler = msg => Console.WriteLine(msg.ToUpper());
            logger.Log("It's a message in upper case.");
        }
    }
}
