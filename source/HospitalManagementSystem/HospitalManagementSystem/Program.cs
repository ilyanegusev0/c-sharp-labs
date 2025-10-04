using System.Text;

namespace HospitalManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HospitalDemo demo = new HospitalDemo();
            demo.Run();

            Console.Write("\nНатисніть будь-яку клавішу для виходу... ");
            Console.ReadKey();
        }
    }
}