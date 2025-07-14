using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewBusinessAddressesViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;

        public event PropertyChangedEventHandler PropertyChanged;

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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
