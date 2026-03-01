namespace Validation
{
    delegate bool Validator(string value);

    public class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {
            Validator nameValidator = GetValidator(3);
            Validator passwordValidator = GetValidator(8);

            Console.WriteLine("Input value with custom validators:\n");

            string login = null;
            while (login == null)
            {
                Console.Write("Login: ");

                string input = Console.ReadLine();

                if (nameValidator(input))
                    login = input;
                else
                    Console.WriteLine("Login must be more than 3 symbols.\n");
            }
            Console.WriteLine();

            string password = null;
            while (password == null)
            {
                Console.Write("Password: ");

                string input = Console.ReadLine();

                if (passwordValidator(input))
                    password = input;
                else
                    Console.WriteLine("Login must be more than 8 symbols.\n");
            }
            Console.WriteLine();

            Console.WriteLine("Your data:\n" +
                $"Login: {login}\n" +
                $"Password: {password}");
        }

        static Validator GetValidator(int minLength)
        {
            return value => value.Length > minLength;
        }
    }
}
