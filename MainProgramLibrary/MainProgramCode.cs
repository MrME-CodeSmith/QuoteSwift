using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteSwift
{
    public static class MainProgramCode
    {
        //Get Last Quote
        public static Quote GetLastQuote(SortedDictionary<string, Quote> quotes)
        {
            if (quotes != null && quotes.Count > 0)
            {
                Quote latest = quotes.First().Value;
                DateTime dt = latest.QuoteCreationDate;

                foreach (var quote in quotes.Values.Skip(1))
                {
                    if (quote.QuoteCreationDate.Date > dt)
                    {
                        dt = quote.QuoteCreationDate.Date;
                        latest = quote;
                    }
                }

                return latest;
            }

            return null;
        }

        /** Parse String Inputs: */

        // Parse Float:
        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
            return temp;
        }

        // Parse Decimal:
        public static decimal ParseDecimal(string t)
        {
            decimal.TryParse(t, out decimal temp);
            return temp;
        }

        // Parse Boole:
        public static bool ParseBoolean(string t)
        {
            bool.TryParse(t, out bool temp);
            return temp;
        }

        // Parse Int:
        public static int ParseInt(string t)
        {
            int.TryParse(t, out int temp);
            return temp;
        }

        /*************************/

    }
}
