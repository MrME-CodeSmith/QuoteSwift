using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class ApplicationData
    {
        readonly IDataService dataService;

        public ApplicationData(IDataService service)
        {
            dataService = service;
        }

        public Dictionary<string, Part> PartList { get; internal set; }
        public BindingList<Pump> PumpList { get; internal set; }
        public BindingList<Business> BusinessList { get; internal set; }
        public SortedDictionary<string, Quote> QuoteMap { get; internal set; }

        public async Task LoadAsync()
        {
            PartList = await dataService.LoadPartListAsync();
            PumpList = await dataService.LoadPumpListAsync();
            BusinessList = await dataService.LoadBusinessListAsync();
            QuoteMap = await dataService.LoadQuoteMapAsync();
        }

        public void SaveAll()
        {
            dataService.SaveParts(PartList);
            dataService.SavePumps(PumpList);
            dataService.SaveBusinesses(BusinessList);
            dataService.SaveQuotes(QuoteMap);
        }
    }
}
