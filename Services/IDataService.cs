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
    }
}
