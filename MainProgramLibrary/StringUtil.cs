using System.Text.RegularExpressions;

namespace QuoteSwift
{
    public static class StringUtil
    {
        public static string NormalizeKey(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            string trimmed = input.Trim();
            string singleSpaced = Regex.Replace(trimmed, @"\s+", " ");
            return singleSpaced.ToUpperInvariant();
        }
    }
}
