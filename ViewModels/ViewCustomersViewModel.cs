using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class ViewCustomersViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewCustomersViewModel(IDataService service)
        {
            dataService = service;
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
            Businesses = dataService.LoadBusinessList();
            QuoteMap = dataService.LoadQuoteMap();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
