namespace Utils
{
    public class InputEx
    {
        public static bool TryParse(string? s, out int result, int defaultValue)
        {
            if (!int.TryParse(s, out result))
            {
                result = defaultValue;
                return false;
            }

            return true;
        }
    }
}
