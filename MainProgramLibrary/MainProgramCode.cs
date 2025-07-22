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
    }
}
