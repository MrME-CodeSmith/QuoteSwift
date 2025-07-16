using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class QuotesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Quote> quotes;
        Quote selectedQuote;

        SortedDictionary<string, Quote> quoteMap;
        BindingList<Business> businessList;
        BindingList<Pump> pumpList;
        Dictionary<string, Part> partMap;


        public QuotesViewModel(IDataService service)
        {
            dataService = service;
        }


        public BindingList<Quote> Quotes
        {
            get => quotes;
            private set
            {
                quotes = value;
                OnPropertyChanged(nameof(Quotes));
            }
        }

        public Quote SelectedQuote
        {
            get => selectedQuote;
            set
            {
                selectedQuote = value;
                OnPropertyChanged(nameof(SelectedQuote));
            }
        }

        public SortedDictionary<string, Quote> QuoteMap
        {
            get => quoteMap;
            private set
            {
                quoteMap = value;
                OnPropertyChanged(nameof(QuoteMap));
            }
        }

        public BindingList<Business> BusinessList
        {
            get => businessList;
            private set
            {
                businessList = value;
                OnPropertyChanged(nameof(BusinessList));
            }
        }

        public BindingList<Pump> PumpList
        {
            get => pumpList;
            private set
            {
                pumpList = value;
                OnPropertyChanged(nameof(PumpList));
            }
        }

        public Dictionary<string, Part> PartMap
        {
            get => partMap;
            private set
            {
                partMap = value;
                OnPropertyChanged(nameof(PartMap));
            }
        }

        public void LoadData()
        {
            LoadDataAsync().GetAwaiter().GetResult();
        }

        public async Task LoadDataAsync()
        {
            PartMap = await dataService.LoadPartListAsync();
            PumpList = await dataService.LoadPumpListAsync();
            BusinessList = await dataService.LoadBusinessListAsync();
            QuoteMap = await dataService.LoadQuoteMapAsync();

            Quotes = new BindingList<Quote>(QuoteMap.Values.ToList());
        }

        public void UpdateData(SortedDictionary<string, Quote> quoteMap,
                               BindingList<Business> businessList,
                               BindingList<Pump> pumpList,
                               Dictionary<string, Part> partMap)
        {
            QuoteMap = quoteMap;
            BusinessList = businessList;
            PumpList = pumpList;
            PartMap = partMap;
            Quotes = new BindingList<Quote>(QuoteMap?.Values.ToList() ?? new List<Quote>());
        }

        public void SaveChanges()
        {
            if (QuoteMap != null)
                dataService.SaveQuotes(QuoteMap);
            if (BusinessList != null)
                dataService.SaveBusinesses(BusinessList);
            if (PumpList != null)
                dataService.SavePumps(PumpList);
            if (PartMap != null)
                dataService.SaveParts(PartMap);
        }

    }
}
