using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public interface IDataService
    {
        Dictionary<string, Part> LoadPartList();
        BindingList<Pump> LoadPumpList();
        BindingList<Business> LoadBusinessList();
        SortedDictionary<string, Quote> LoadQuoteMap();

        Task<Dictionary<string, Part>> LoadPartListAsync();
        Task<BindingList<Pump>> LoadPumpListAsync();
        Task<BindingList<Business>> LoadBusinessListAsync();
        Task<SortedDictionary<string, Quote>> LoadQuoteMapAsync();

        void SaveParts(Dictionary<string, Part> parts);
        void SavePumps(BindingList<Pump> pumps);
        void SaveBusinesses(BindingList<Business> businesses);
        void SaveQuotes(SortedDictionary<string, Quote> quotes);
    }
}
