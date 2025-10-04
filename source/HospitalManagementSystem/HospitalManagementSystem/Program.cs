using System.Text;

namespace HospitalManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(1251);
            Console.OutputEncoding = Encoding.GetEncoding(1251);

            HospitalDemo hospitalDemo = new HospitalDemo();
            hospitalDemo.Run();
        }
    }
}