using System.Collections.Generic;
using System.ComponentModel;

namespace QuoteSwift
{
    public interface IDataService
    {
        Dictionary<string, Part> LoadPartList();
        BindingList<Pump> LoadPumpList();
        BindingList<Business> LoadBusinessList();
        SortedDictionary<string, Quote> LoadQuoteMap();

        void SaveParts(Dictionary<string, Part> parts);
        void SavePumps(BindingList<Pump> pumps);
        void SaveBusinesses(BindingList<Business> businesses);
        void SaveQuotes(SortedDictionary<string, Quote> quotes);
    }
}
