using System.Collections.Generic;
using System.ComponentModel;

namespace QuoteSwift
{
    public class FileDataService : IDataService
    {
        public Dictionary<string, Part> LoadPartList()
        {
            byte[] bytes = MainProgramCode.RetreiveData("Parts.json");
            return bytes != null && bytes.Length > 0 ? MainProgramCode.DeserializePartList(bytes) : new Dictionary<string, Part>();
        }

        public BindingList<Pump> LoadPumpList()
        {
            byte[] bytes = MainProgramCode.RetreiveData("PumpList.json");
            return bytes != null && bytes.Length > 0 ? new BindingList<Pump>(MainProgramCode.DeserializePumpList(bytes)) : new BindingList<Pump>();
        }

        public BindingList<Business> LoadBusinessList()
        {
            byte[] bytes = MainProgramCode.RetreiveData("BusinessList.json");
            return bytes != null && bytes.Length > 0 ? new BindingList<Business>(MainProgramCode.DeserializeBusinessList(bytes)) : new BindingList<Business>();
        }

        public SortedDictionary<string, Quote> LoadQuoteMap()
        {
            byte[] bytes = MainProgramCode.RetreiveData("QuoteList.json");
            return bytes != null && bytes.Length > 0 ? MainProgramCode.DeserializeQuoteList(bytes) : new SortedDictionary<string, Quote>();
        }

        public void SaveParts(Dictionary<string, Part> parts)
        {
            MainProgramCode.SerializePartList(parts);
        }

        public void SavePumps(BindingList<Pump> pumps)
        {
            MainProgramCode.SerializePumpList(pumps);
        }

        public void SaveBusinesses(BindingList<Business> businesses)
        {
            MainProgramCode.SerializeBusinessList(businesses);
        }

        public void SaveQuotes(SortedDictionary<string, Quote> quotes)
        {
            MainProgramCode.SerializeQuoteList(quotes);
        }
    }
}
