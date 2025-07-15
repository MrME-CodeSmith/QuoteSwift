using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewBusinessAddressesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;


        public ViewBusinessAddressesViewModel(IDataService service)
        {
            dataService = service;
        }

        public IDataService DataService => dataService;

        public BindingList<Business> Businesses
        {
            get => businesses;
            private set
            {
                businesses = value;
                OnPropertyChanged(nameof(Businesses));
            }
        }

        public void LoadData()
        {
            Businesses = dataService.LoadBusinessList();
        }

    }
}
