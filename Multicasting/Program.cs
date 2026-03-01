namespace Multicasting
{
    delegate void NotificationHandler(string message);

    public class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {
            NotificationHandler nh;


            nh = SendEmail;
            nh += SendSMS;

            Console.WriteLine("Two methods with one delegate NotificationHandler:");

            nh("Hello!");
        }

        static void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
        static void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
