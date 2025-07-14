using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuoteSwift
{
    public class QuotesViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        BindingList<Quote> quotes;
        Quote selectedQuote;

        SortedDictionary<string, Quote> quoteMap;
        BindingList<Business> businessList;
        BindingList<Pump> pumpList;
        Dictionary<string, Part> partMap;

        public event PropertyChangedEventHandler PropertyChanged;

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
            PartMap = dataService.LoadPartList();
            PumpList = dataService.LoadPumpList();
            BusinessList = dataService.LoadBusinessList();
            QuoteMap = dataService.LoadQuoteMap();

            Quotes = new BindingList<Quote>(QuoteMap.Values.ToList());
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            QuoteMap = newPass.PassQuoteMap;
            BusinessList = newPass.PassBusinessList;
            PartMap = newPass.PassPartList;
            PumpList = newPass.PassPumpList;
            Quotes = new BindingList<Quote>(QuoteMap?.Values.ToList() ?? new List<Quote>());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
