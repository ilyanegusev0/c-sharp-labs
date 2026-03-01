namespace Multicasting
{
    delegate void NotificationHandler(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationHandler nh;


            nh = SendEmail;
            nh += SendSMS;

            Console.WriteLine("Two methods with one delegate NotificationHandler:");

            nh("Hello!");
        }

        static public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
        static public void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
