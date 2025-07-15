using System.Collections.Generic;
using System.ComponentModel;

namespace QuoteSwift
{
    public class ApplicationData
    {
        readonly IDataService dataService;

        public ApplicationData(IDataService service)
        {
            dataService = service;
        }

        public Dictionary<string, Part> PartList { get; private set; }
        public BindingList<Pump> PumpList { get; private set; }
        public BindingList<Business> BusinessList { get; private set; }
        public SortedDictionary<string, Quote> QuoteMap { get; private set; }

        public void Load()
        {
            PartList = dataService.LoadPartList();
            PumpList = dataService.LoadPumpList();
            BusinessList = dataService.LoadBusinessList();
            QuoteMap = dataService.LoadQuoteMap();
        }

        public void SaveAll()
        {
            MainProgramCode.SerializePartList(PartList);
            MainProgramCode.SerializePumpList(PumpList);
            MainProgramCode.SerializeBusinessList(BusinessList);
            MainProgramCode.SerializeQuoteList(QuoteMap);
        }
    }
}
