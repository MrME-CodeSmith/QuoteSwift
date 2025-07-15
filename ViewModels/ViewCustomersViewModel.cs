using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class ViewCustomersViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;


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

    }
}
