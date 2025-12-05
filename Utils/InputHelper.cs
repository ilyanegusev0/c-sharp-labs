namespace Utils
{
    public class InputHelper
    {
        public static bool TryInput<T>(string header, out T result) where T : IParsable<T>
        {
            Console.Write(header);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && T.TryParse(input, null, out result))
                return true;

            result = default!;
            return false;
        }

        public static bool Validate<T>(T value, Func<T, bool> rule)
        {
            return rule(value);
        }

        public static T InputWithValidation<T>(string header, Func<T, bool> rule, string errorMessage) where T : IParsable<T>
        {
            while (true)
            {
                bool success = TryInput<T>(header, out T input);

                if (success && Validate<T>(input, rule))
                    return input;

                ConsoleEx.WriteLine(errorMessage, ConsoleColor.Red);
            }
        }
    }
}
