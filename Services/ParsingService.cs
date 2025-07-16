namespace QuoteSwift
{
    public static class ParsingService
    {
        public static int ParseInt(string input)
        {
            return int.TryParse(input, out var result) ? result : 0;
        }

        public static decimal ParseDecimal(string input)
        {
            return decimal.TryParse(input, out var result) ? result : 0m;
        }

        public static float ParseFloat(string input)
        {
            return float.TryParse(input, out var result) ? result : 0f;
        }

        public static bool ParseBoolean(string input)
        {
            return bool.TryParse(input, out var result) && result;
        }
    }
}
