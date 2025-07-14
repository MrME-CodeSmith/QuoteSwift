using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class CreateQuoteViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        Dictionary<string, Part> partList;
        BindingList<Pump> pumps;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;

        public event PropertyChangedEventHandler PropertyChanged;

        public CreateQuoteViewModel(IDataService service)
        {
            dataService = service;
        }

        public IDataService DataService => dataService;

        public Dictionary<string, Part> PartList
        {
            get => partList;
            private set
            {
                partList = value;
                OnPropertyChanged(nameof(PartList));
            }
        }

        public BindingList<Pump> Pumps
        {
            get => pumps;
            private set
            {
                pumps = value;
                OnPropertyChanged(nameof(Pumps));
            }
        }

        public BindingList<Business> Businesses
        {
            get => businesses;
            private set
            {
                businesses = value;
                OnPropertyChanged(nameof(Businesses));
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

        public void LoadData()
        {
            PartList = dataService.LoadPartList();
            Pumps = dataService.LoadPumpList();
            Businesses = dataService.LoadBusinessList();
            QuoteMap = dataService.LoadQuoteMap();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
